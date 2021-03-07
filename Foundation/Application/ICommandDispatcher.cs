using System;
using System.Collections.Generic;

namespace Foundation.Application
{
    public interface ICommandDispatcher
    {
        /// <exception cref="ArgumentException">The dispatcher is not able to dispatch the command.</exception>
        /// <exception cref="CommandHandlingException">An exception is thrown during the handling of the command.</exception>
        IEnumerable<ApplicationEvent> Dispatch<TCommand>(TCommand command);
    }
}