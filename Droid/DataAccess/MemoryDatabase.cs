using System.Collections.Generic;
using System.Linq;
using ExtendedMemory.DataAccess;
using ExtendedMemory.Helpers;
using ExtendedMemory.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(MemoryDatabase))]
namespace ExtendedMemory.DataAccess
{
    public class MemoryDatabase : IMemoryDatabase
    {
        static SQLiteConnection database;

        public static SQLiteConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteConnection(DependencyService.Get<IFileLocation>().GetLocalFilePath("MemoryDatabase.db3"));
                }
                return database;
            }
        }

        public MemoryDatabase()
        {
            database = new SQLiteConnection(DependencyService.Get<IFileLocation>().GetLocalFilePath("MemoryDatabase.db3"));
            database.CreateTable<Memory>();
        }

        public int Save(Memory item)
        {
            if (item.ID != 0)
            {
                return database.Update(item);
            }

            return database.Insert(item);
        }

        public List<Memory> Get() => database.Table<Memory>().ToList();

        public Memory Get(int id) => database.Table<Memory>().Where(i => i.ID == id).FirstOrDefault();

        public int Delete(Memory item) => database.Delete(item);
    }
}