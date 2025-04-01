using AnchorPage.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;
        private readonly IUseCaseLogger _logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            _logger.Log(command, _actor, request);
            if (!_actor.AllowedUseCases.Contains(command.Id))
                throw new UnauthorizedUseCaseException(_actor, command);

            command.Execute(request);
        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            _logger.Log(query, _actor, search);
            if (!_actor.AllowedUseCases.Contains(query.Id))
                throw new UnauthorizedUseCaseException(_actor, query);

            return query.Execute(search);
        }
    }
}
