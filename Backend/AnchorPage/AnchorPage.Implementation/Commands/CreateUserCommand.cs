using AnchorPage.Application.Commands;
using AnchorPage.Application.DataTransfer;
using AnchorPage.DataAccess;
using AnchorPage.Domain.Entities;
using AnchorPage.Implementation.Validation;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly AnchorPageContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IMapper _mapper;

        public CreateUserCommand(AnchorPageContext context, CreateUserValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Create User Command";

        public void Execute(CreateUserDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Users.Add(_mapper.Map<User>(request));
            _context.SaveChanges();
            //_context.VerificationTokens.Add(new VerificationToken { 
            //    UserId = user,
            //    Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Username + DateTime.Now)),
            //    ExpiresAt = DateTime.Now.AddMinutes(15)});
            //_context.SaveChanges();
        }
    }
}
