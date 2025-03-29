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
            var test = _configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AnchorPageContext>();
            optionsBuilder.UseSqlServer();

            return new AnchorPageContext(optionsBuilder.Options);
        }
    }
}
