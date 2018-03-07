using System.Collections.Generic;
using ExtendedMemory.Models;

namespace ExtendedMemory.DataAccess
{
    public interface IMemoryDatabase
    {
        Response<int> Save(Memory memory);

        List<Memory> Get();

        Memory Get(SearchType searchType);

        Response<int> Forget(Memory memory);
    }
}