using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Lite;
using ExtendedMemory.Models;

namespace ExtendedMemory.DataAccess
{
    public interface IMemoryDatabase
    {
        Response<string> Save(Memory memory);

        Task<Response<List<Memory>>> Get();

        Response<string> Forget(Memory memory);

        Response<List<Memory>> Get(SearchParams searchParams);
    }

    public class MemoryDatabase : IMemoryDatabase
    {
        static Database database;

        public MemoryDatabase()
        {
            Couchbase.Lite.Storage.SystemSQLite.Plugin.Register();
            database = Manager.SharedInstance.GetDatabase("extendedmemory");
        }

        public Response<string> Save(Memory memory)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (PropertyDescriptor x in TypeDescriptor.GetProperties(memory))
            {
                properties.Add(x.Name, x.GetValue(memory));
            }

            var document = database.CreateDocument();
            //document.PutProperties(Memory.MemoryToDictionary(memory));
            document.PutProperties(properties);

            Console.WriteLine($"Document ID :: {document.Id}");
            Console.WriteLine($"Learning {document.GetProperty("Text")} with location {document.GetProperty("Location")}");

            return new Response<string>
            {
                IsSuccess = true,
                Item = document.Id
            };
        }

        public async Task<Response<List<Memory>>> Get()
        {
            var memories = new List<Memory>();
            var memoriesFromDB = await database.CreateAllDocumentsQuery().RunAsync();
            foreach (var memoryRecord in memoriesFromDB)
            {
                memories.Add(Memory.DictToMemory(memoryRecord));
            }

            return new Response<List<Memory>>
            {
                IsSuccess = true,
                Item = memories
            };
        }

        public Response<string> Forget(Memory memory)
        {
            throw new NotImplementedException();
        }

        public Response<List<Memory>> Get(SearchParams searchParams)
        {
            var memories = new List<Memory>();
            var memoriesFromDB = database.CreateAllDocumentsQuery();
            var rows = memoriesFromDB.Run();

            foreach (var row in rows)
            {
                var memoryRecord = Memory.DictToMemory(row);

                if (searchParams.Memory != null && searchParams.Memory.Any() &&
                    !String.IsNullOrWhiteSpace(memoryRecord.Text) &&
                    !searchParams.Memory.Any(m => memoryRecord.Text.IndexOf(m, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    continue;
                }

                if (searchParams.People != null && searchParams.People.Any() && 
                    memoryRecord.People != null && memoryRecord.People.Any() &&
                    !memoryRecord.People.Any(p => searchParams.People.Any(s => s.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)))
                {
                    continue;
                }

                if (searchParams.Tags != null && searchParams.Tags.Any() &&
                    memoryRecord.Tags != null && memoryRecord.Tags.Any() &&
                    !memoryRecord.Tags.Any(p => searchParams.Tags.Any(s => s.IndexOf(p, StringComparison.OrdinalIgnoreCase) >= 0)))
                {
                    continue;
                }

                if (searchParams.Location != null && memoryRecord.Location != null) {
                    if (!String.IsNullOrWhiteSpace(searchParams.Location.City) &&
                        !String.IsNullOrWhiteSpace(memoryRecord.Location.City) &&
                        !searchParams.Location.City.Equals(memoryRecord.Location.City))
                    {
                        continue;
                    }
                    if (!String.IsNullOrWhiteSpace(searchParams.Location.State) &&
                        !String.IsNullOrWhiteSpace(memoryRecord.Location.State) &&
                        !searchParams.Location.State.Equals(memoryRecord.Location.State))
                    {
                        continue;
                    }
                    if (!String.IsNullOrWhiteSpace(searchParams.Location.Country) &&
                        !String.IsNullOrWhiteSpace(memoryRecord.Location.Country) &&
                        !searchParams.Location.Country.Equals(memoryRecord.Location.Country))
                    {
                        continue;
                    }
                }

                if (memoryRecord.DateTime < searchParams.FromDate || memoryRecord.DateTime > searchParams.ToDate)
                {
                    continue;
                }

                if (memoryRecord.DateTime.TimeOfDay < searchParams.FromTime || memoryRecord.DateTime.TimeOfDay > searchParams.ToTime)
                {
                    continue;
                }

                memories.Add(memoryRecord);
            }

            return new Response<List<Memory>>
            {
                IsSuccess = true,
                Item = memories
            };
        }
    }
}