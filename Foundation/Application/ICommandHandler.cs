using System.Collections.Generic;

namespace Foundation.Application
{
    public interface ICommandHandler<in TCommand>
    {
        ApplicationEvent[] Handle(TCommand command);
    }
}