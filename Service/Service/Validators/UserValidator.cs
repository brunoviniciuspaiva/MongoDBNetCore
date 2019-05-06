using Domain.Entities;
using FluentValidation;
using System;

namespace Service.Validators
{
    public class UserValidator: AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentException("Can't found the object.");
                    });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Is necessary to inform the CPF.")
                .NotNull().WithMessage("Is necessary to inform the CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Is necessary to inform the name.")
                .NotNull().WithMessage("Is necessary to inform the name.");
        }
    }
}
