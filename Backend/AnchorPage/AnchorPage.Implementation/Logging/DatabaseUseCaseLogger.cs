using AnchorPage.Application;
using AnchorPage.DataAccess;
using AnchorPage.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly AnchorPageContext _context;

        public DatabaseUseCaseLogger(AnchorPageContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Actor = actor.Identity,
                UseCaseName = useCase.Name,
                UseCaseData = JsonConvert.SerializeObject(useCaseData),
                CommitedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}
