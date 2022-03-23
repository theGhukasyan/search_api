using System.Collections.Generic;
using SearchAPI.Domain.Common;
using SearchAPI.Domain.Contracts;
using SearchAPI.Domain.Individuals;

namespace SearchAPI.Domain.Summaries
{
    public class Summary
    {
        public Individual Individual { get; set; }
        
        public ICollection<Contract> Contracts { get; set; }
        
        public Amount SumOfOriginalAmount { get; set; }

        public Amount SumOfInstallmentAmount { get; set; }
        
        public Amount MaxOverdueBalance { get; set; }

      
    }
}