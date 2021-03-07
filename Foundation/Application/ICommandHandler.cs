using System.Collections.Generic;

namespace Foundation.Application
{
    public interface ICommandHandler<in TCommand>
    {
        IEnumerable<ApplicationEvent> Handle(TCommand command);
    }
}