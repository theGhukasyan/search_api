using SearchAPI.DAL.Repositories;
using SearchAPI.DAL.Repositories.Individuals;

namespace SearchAPI.DAL
{
    public interface ISearchApiRepository
    {
        public IContractsRepository ContractsRepository { get; set; }
        
        public IIndividualsRepository IndividualsRepository { get; set; }
    }
}