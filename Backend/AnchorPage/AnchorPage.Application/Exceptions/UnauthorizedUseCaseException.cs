using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IApplicationActor actor, IUseCase useCase)
            : base($"Actor with an ID of {actor.Id} - {actor.Identity} tried to execute {useCase.Name}")
        {
            
        }
    }
}
