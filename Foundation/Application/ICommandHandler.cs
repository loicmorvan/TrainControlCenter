namespace Foundation.Application
{
    public interface ICommandHandler<in TCommand>
    {
        ApplicationEvent[] Handle(TCommand command);
    }
}