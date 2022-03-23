using SearchApi.Sql;

namespace SearchAPI.DAL.Repositories.Contracts
{
    public class ContractsRepository : IContractsRepository
    {
        private readonly SearchApiContext _context;
        
        public ContractsRepository(SearchApiContext context)
        {
            _context = context; 
        }
    }
}