using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchAPI.DAL;
using SearchAPI.DAL.Repositories.Individuals.Models;
using SearchAPI.Domain.Individuals;
using SearchAPI.Domain.Summaries;

namespace SearchAPI.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class IndividualsController : ControllerBase
    {
        private readonly ILogger<IndividualsController> _logger;
        private readonly ISearchApiRepository _apiRepository;
        
        public IndividualsController(ILogger<IndividualsController> logger, ISearchApiRepository apiRepository)
        {
            _logger = logger;
            _apiRepository = apiRepository;
        }

        [HttpGet("get-details/{nationalId}")]
        public async Task<Individual> GetDetailsAsync(string nationalId)
        {
            return await _apiRepository.IndividualsRepository.GetByIdWithContractsAsync(nationalId: nationalId);
        }
        
        [HttpGet("search")]
        public async Task<Summary> SearchAsync(SummarySearchFilter filter)
        {
            return await _apiRepository.IndividualsRepository.SearchAsync(filter);
        }
    }
}