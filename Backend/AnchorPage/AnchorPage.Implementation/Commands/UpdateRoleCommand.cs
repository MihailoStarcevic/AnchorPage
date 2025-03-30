using AnchorPage.Application.Commands;
using AnchorPage.Application.DataTransfer;
using AnchorPage.DataAccess;
using AnchorPage.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Commands
{
    public class UpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly AnchorPageContext _context;
        private readonly UpdateRoleValidator _validator;

        public UpdateRoleCommand(AnchorPageContext context, UpdateRoleValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Update Role Command";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = _context.Roles.Find(request.Id);

            role.Name = request.Name;
            role.Description = request.Description;
            _context.SaveChanges();
        }
    }
}
