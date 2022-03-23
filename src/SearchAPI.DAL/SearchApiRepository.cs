using SearchAPI.DAL.Repositories;
using SearchAPI.DAL.Repositories.Contracts;
using SearchAPI.DAL.Repositories.Individuals;
using SearchApi.Sql;

namespace SearchAPI.DAL
{
    public sealed class SearchApiRepository : ISearchApiRepository
    {
        public IContractsRepository ContractsRepository { get; set; }
        public IIndividualsRepository IndividualsRepository { get; set; }

        public SearchApiRepository(SearchApiContext context)
        {
            ContractsRepository = new ContractsRepository(context);
            IndividualsRepository = new IndividualsRepository(context);
        }
    }
}