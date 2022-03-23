using System;
using FluentValidation;
using SearchAPI.Domain.Individuals;

namespace SearchApi.BL.Validations.Individuals
{
    public class IndividualsValidator : AbstractValidator<Individual>
    {
        public IndividualsValidator()
        {
            RuleFor(_ => _.NationalId).NotEmpty();
            RuleFor(_ => _.Gender).NotEmpty();
            RuleFor(_ => _.DateOfBirth).NotEmpty();
            RuleFor(_ => _.FirstName).NotEmpty();
            RuleFor(_ => _.LastName).NotEmpty();

            RuleFor(_ => _.DateOfBirth).GreaterThanOrEqualTo(DateTime.UtcNow.AddYears(-18));
            RuleFor(_ => _.DateOfBirth).LessThanOrEqualTo(DateTime.UtcNow.AddYears(-99));
        }
    }
}