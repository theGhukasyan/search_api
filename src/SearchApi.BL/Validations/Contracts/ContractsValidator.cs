using System.Linq;
using FluentValidation;
using SearchAPI.Domain.Contracts;

namespace SearchApi.BL.Validations.Contracts
{
    public class ContractsValidator : AbstractValidator<Contract>
    {
        public ContractsValidator()
        {
            RuleFor(_ => _.OriginalAmount).NotEmpty();
            RuleFor(_ => _.DateOfLastPayment).NotEmpty();
            RuleFor(_ => _.NextPaymentDate).NotEmpty();
            RuleFor(_ => _.OriginalAmount).NotEmpty();
            RuleFor(_ => _.CustomerCode).NotEmpty();
            RuleFor(_ => _.PhaseOfContract).NotEmpty();
            RuleFor(_ => _.InstallmentAmount).NotEmpty();
            RuleFor(_ => _.Roles).NotEmpty();
            RuleFor(_ => _.DateAccountOpened).NotEmpty();
            
            RuleFor(_ => _.OriginalAmount.Value)
                .GreaterThan(_ => _.Roles.Sum(role => role.GuaranteeAmount.Value))
                .WithMessage("Original Amount must be greater than Guarantee Amount");
            
            RuleFor(_ => _.DateOfLastPayment)
                .GreaterThanOrEqualTo(_ => _.DateAccountOpened)
                .WithMessage("Date of Last Payment cannot be after Date Account Opened");
            
            RuleFor(_ => _.NextPaymentDate)
                .GreaterThanOrEqualTo(_ => _.DateOfLastPayment)
                .WithMessage("Date of Last Payment should be after Next Payment's Date");
        }
    }
}