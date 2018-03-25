using System.Collections.Generic;
using System.Threading.Tasks;
using ExtendedMemory.Models;

namespace ExtendedMemory.DataAccess
{
    public interface IMemoryDatabase
    {
        Response<string> Save(Memory memory);

        Task<Response<List<Memory>>> Get();

        Response<Memory> Get(SearchType searchType);

        Response<string> Forget(Memory memory);
    }
}