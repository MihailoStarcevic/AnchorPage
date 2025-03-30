using AnchorPage.Application.DataTransfer;
using AnchorPage.Application.Queries;
using AnchorPage.Application.Searches;
using AnchorPage.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Queries
{
    public class GetRolesQuery : IGetRolesQuery
    {
        private readonly AnchorPageContext _context;

        public GetRolesQuery(AnchorPageContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }

        public int Id => 1;

        public string Name => "Get Roles Query";

        public PagedResponse<RoleDto> Execute(RoleSearch search)
        {
            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Description) || !string.IsNullOrWhiteSpace(search.Description))
            {
                query = query.Where(x => (x.Description ?? "").ToLower().Contains(search.Description.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<RoleDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new RoleDto
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description ?? string.Empty
                }).ToList()
            };

            return response;
        }
    }
}
