using AnchorPage.Application.DataTransfer;
using AnchorPage.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Validation
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(AnchorPageContext context)
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username field can not be empty.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Username).Length(3, 20)
                        .WithMessage("Username must be between three and 20 characters long.")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Username)
                                .Must(name => !context.Users.Any(u => u.Username == name))
                                .WithMessage("There is already an user with that username.");
                        });
                });

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email field can't be empty.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email)
                        .Length(6, 50).WithMessage("Email must be between three and 20 characters long.")
                        .DependentRules(() =>
                        {
                            RuleFor(x => x.Email)
                                .Must(email => !context.Users.Any(u => u.Email == email))
                                .WithMessage("An account using that email address already exists.")
                                .EmailAddress();
                        });
                });

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field can't be empty.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password)
                        .MinimumLength(6).WithMessage("Password must have at least six characters.");
                });


            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("Display Name field can't be empty.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.DisplayName)
                        .Length(3, 50).WithMessage("Display name must have between three and 50 characters.");
                });
                
        }
    }
}
