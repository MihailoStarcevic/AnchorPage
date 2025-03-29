using AnchorPage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.DataAccess
{
    public class AnchorPageContext : DbContext
    {
        public AnchorPageContext(DbContextOptions<AnchorPageContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
    }
}
