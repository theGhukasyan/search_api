using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchAPI.DAL.Repositories.Common;
using SearchAPI.DAL.Repositories.Individuals.Models;
using SearchAPI.Domain.Individuals;
using SearchAPI.Domain.Summaries;

namespace SearchAPI.DAL.Repositories.Individuals
{
    public interface IIndividualsRepository : IRepository
    {
        Task<Individual> GetByIdAsync(string nationalId);

        Task<Individual> GetByIdWithContractsAsync(string nationalId);

        Task<Summary> SearchAsync(SummarySearchFilter filter);
    }
}