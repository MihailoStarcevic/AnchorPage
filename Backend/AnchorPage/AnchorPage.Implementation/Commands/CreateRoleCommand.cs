using AnchorPage.Application.Commands;
using AnchorPage.Application.DataTransfer;
using AnchorPage.DataAccess;
using AnchorPage.Domain.Entities;
using AnchorPage.Implementation.Validation;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateRoleCommand(AnchorPageContext context, CreateRoleValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Create Role command";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Roles.Add(_mapper.Map<Role>(request));
            _context.SaveChanges();
        }
    }
}
