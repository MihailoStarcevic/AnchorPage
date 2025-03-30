using AnchorPage.Application.DataTransfer;
using AnchorPage.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Application.Queries
{
    public interface IGetRolesQuery : IQuery<RoleSearch, PagedResponse<RoleDto>>
    {
    }
}
