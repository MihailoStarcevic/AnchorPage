using AnchorPage.Application.Commands;
using AnchorPage.Application.DataTransfer;
using AnchorPage.DataAccess;
using AnchorPage.Domain.Entities;
using AnchorPage.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Commands
{
    public class CreateRoleCommand : ICreateRoleCommand
    {
        private readonly AnchorPageContext _context;
        private readonly CreateRoleValidator _validator;

        public CreateRoleCommand(AnchorPageContext context, CreateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Create Role command";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
