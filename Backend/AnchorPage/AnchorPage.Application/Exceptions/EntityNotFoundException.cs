using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnchorPage.Application.Exceptions
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException(T id , Type type)
            : base($"Entity of type {type.Name} with an ID of {id} was not found.")
        {
            
        }
    }
}
