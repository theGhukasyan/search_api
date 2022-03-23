using System;
using System.Collections.Generic;
using SearchAPI.Domain.Common;
using SearchAPI.Domain.Individuals;

namespace SearchAPI.Domain.Contracts
{
    public class Contract
    {
        public string ContractCode { get; set; }
        
        public List<SubjectRole> Roles { get; set; }
        
        public Guid CustomerCode { get; set; }
        public Individual Individual { get; set; }
        
        public Amount OriginalAmount { get; set; }
        
        public Amount InstallmentAmount { get; set; }
        
        public string PhaseOfContract { get; set; }
        
        public DateTime DateOfLastPayment { get; set; }
        
        public DateTime NextPaymentDate { get; set; }
        
        public DateTime DateAccountOpened { get; set; }
    }
}