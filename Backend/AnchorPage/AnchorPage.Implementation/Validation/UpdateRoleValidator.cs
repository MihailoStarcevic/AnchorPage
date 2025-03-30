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
    public class UpdateRoleValidator : AbstractValidator<RoleDto>
    {
        public UpdateRoleValidator(AnchorPageContext context)
        {
            RuleFor(x => x.Id).Must(id => context.Roles.Any(x => x.Id == id))
                .WithMessage("A role with that ID doesn't exist.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Name).Length(2, 20).WithMessage("Name must be between 2 and 20 characters long.")
                        .NotEmpty().WithMessage("Name field can't be empty.")
                        .Must(name => !context.Roles.Any(r => r.Name == name))
                        .WithMessage("A role with that name already exists.");

                    RuleFor(x => x.Description).MaximumLength(100)
                        .WithMessage("Description can't have more than 100 characters.");
                });
        }
    }
}
