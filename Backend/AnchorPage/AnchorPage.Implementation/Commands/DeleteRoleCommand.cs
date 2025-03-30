using AnchorPage.Application.Commands;
using AnchorPage.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Commands
{
    public class DeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly AnchorPageContext _context;

        public DeleteRoleCommand(AnchorPageContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Delete Role Command";

        public void Execute(int request)
        {
            var role = _context.Roles.Find(request);

            if (role == null)
                throw new InvalidOperationException();

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}
