using System;
using System.Collections.Generic;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(MemoryDatabase))]
namespace ExtendedMemory.DataAccess
{
    public class MemoryDatabase : IMemoryDatabase
    {
        public MemoryDatabase()
        {
            // Create a singleton db object here?
        }

        public Response<int> Save(Memory memory)
        {
            throw new NotImplementedException();
        }

        public List<Memory> Get()
        {
            throw new NotImplementedException();
        }

        public Memory Get(SearchType searchType)
        {
            throw new NotImplementedException();
        }

        public Response<int> Forget(Memory memory)
        {
            throw new NotImplementedException();
        }
    }
}