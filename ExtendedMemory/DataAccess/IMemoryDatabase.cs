using System.Collections.Generic;
using ExtendedMemory.Models;

namespace ExtendedMemory.DataAccess
{
    public interface IMemoryDatabase
    {
        Response<string> Save(Memory memory);

        Response<List<Memory>> Get();

        Response<Memory> Get(SearchType searchType);

        Response<string> Forget(Memory memory);
    }
}