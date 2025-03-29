using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.DataAccess
{
    public class AnchorPageContextFactory : IDesignTimeDbContextFactory<AnchorPageContext>
    {
        private readonly IConfiguration _configuration;

        public AnchorPageContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AnchorPageContextFactory()
        {
            
        }

        public AnchorPageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnchorPageContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            return new AnchorPageContext(optionsBuilder.Options);
        }
    }
}
