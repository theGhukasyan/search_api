using System;
using SearchAPI.Domain.Common;

namespace SearchAPI.Domain.Contracts
{
    public record SubjectRole
    {
        public Guid CustomerCode { get; set; }
        
        public string RoleOfCustomer { get; set; }
        
        public Amount GuaranteeAmount { get; set; }

        public SubjectRole()
        {
        }
        
        public SubjectRole(Guid customerCode, string roleOfCustomer, Amount guaranteeAmount)
        {
            CustomerCode = customerCode;
            RoleOfCustomer = roleOfCustomer;
            GuaranteeAmount = guaranteeAmount;
        }
    }
}