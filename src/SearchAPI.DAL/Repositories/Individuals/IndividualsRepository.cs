using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SearchAPI.DAL.Extensions;
using SearchAPI.DAL.Repositories.Individuals.Models;
using SearchAPI.Domain.Common;
using SearchAPI.Domain.Contracts;
using SearchAPI.Domain.Individuals;
using SearchAPI.Domain.Summaries;
using SearchApi.Sql;


namespace SearchAPI.DAL.Repositories.Individuals
{
    public class IndividualsRepository : IIndividualsRepository
    {
        private readonly SearchApiContext _context;

        public IndividualsRepository(SearchApiContext context)
        {
            _context = context;
        }

        public async Task<Individual> GetByIdAsync(string nationalId)
        {
            return await _context.Individuals
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.NationalId == nationalId);
        }

        public async Task<Individual> GetByIdWithContractsAsync(string nationalId)
        {
            return await _context.Individuals
                .AsNoTracking()
                .Include(_ => _.Contracts)
                .FirstOrDefaultAsync(_ => _.NationalId == nationalId);
        }

        public async Task<Summary> SearchAsync(SummarySearchFilter filter)
        {
            if (filter == null) throw new Exception("Filter is not provided");
            
            var utcNow = DateTime.UtcNow;

            return await _context.Individuals
                .Include(_ => _.Contracts)
                .AsNoTracking()
                .Where(individual => individual.NationalId == filter.NationalId)
                .Select(individual => new Summary
                {
                    Individual = individual,
                    Contracts = individual.Contracts,
                    SumOfInstallmentAmount = new Amount
                    {
                        Currency = individual.Contracts.FirstOrDefault().InstallmentAmount.Currency,
                        Value = individual.Contracts.Sum(_ => _.InstallmentAmount.Value)
                    },
                    SumOfOriginalAmount = new Amount
                    {
                        Currency = individual.Contracts.FirstOrDefault().OriginalAmount.Currency,
                        Value = individual.Contracts.Sum(_ => _.OriginalAmount.Value)
                    }
                    //No information how to calculate overdue balance.
                }).FirstOrDefaultAsync();
        }
    }
}