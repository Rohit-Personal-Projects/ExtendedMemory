using System.Collections.Generic;
using ExtendedMemory.Models;

namespace ExtendedMemory.DataAccess
{
    public interface IMemoryDatabase
    {
        List<Memory> Get();

        Memory Get(int id);

        int Save(Memory item);

        int Delete(Memory item);
    }
}