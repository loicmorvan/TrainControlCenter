using System;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.Application
{
    /// <summary>
    ///     Represents a dispatcher that calls the right handler in order to handle a command according to its type.
    /// </summary>
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDictionary<Type, object> _handlers = new Dictionary<Type, object>();

        /// <summary>
        ///     Creates a command dispatcher from a collection of handlers.
        /// </summary>
        /// <param name="commandHandlers">
        ///     A collection of handlers.
        ///     Each object inside must implement <see cref="ICommandHandler{TCommand}" />.
        ///     The generic type given in <see cref="ICommandHandler{TCommand}" /> must be unique in the collection.
        ///     This generic type will be used to select the handler to use according to the type of the command.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     One of the given objects does not implement
        ///     <see cref="ICommandHandler{TCommand}" />.
        /// </exception>
        /// <exception cref="ArgumentException">Two handlers are able to handle the same type of commands.</exception>
        public CommandDispatcher(params object[] commandHandlers)
        {
            var handlersWithCommandTypes = commandHandlers.Select(commandHandler =>
            {
                var objectType = commandHandler.GetType();

                var handlerType = TryGetCommandHandlerInterfaceType(objectType);
                if (handlerType == null)
                    throw new ArgumentException($"The given object of type {objectType} is not a command handler.",
                        nameof(commandHandlers));

                var commandType = handlerType.GetGenericArguments()[0]!;

                return (commandType, commandHandler);
            });

            foreach (var (commandType, commandHandler) in handlersWithCommandTypes)
                if (!_handlers.TryAdd(commandType, commandHandler))
                    throw new
                        ArgumentException($"Two handlers are able to handle the same type of commands {commandType}.");
        }

        /// <summary>
        ///     Dispatches a command to a handler according to its type.
        /// </summary>
        /// <param name="command">The command to dispatch to a handler.</param>
        /// <typeparam name="TCommand">The type of the command used to choose the handler to execute.</typeparam>
        /// <exception cref="ArgumentException"><typeparamref name="TCommand" /> has no handler in this dispatcher.</exception>
        /// <exception cref="CommandHandlingException">The handler threw an exception when handling the command.</exception>
        public IEnumerable<ApplicationEvent> Dispatch<TCommand>(TCommand command)
        {
            if (!_handlers.TryGetValue(typeof(TCommand), out var untypedHandler))
                throw new
                    ArgumentException($"The given command type {typeof(TCommand)} has no handler in this dispatcher.",
                        nameof(TCommand));

            var handler = (ICommandHandler<TCommand>) untypedHandler;

            try
            {
                return handler.Handle(command);
            }
            catch (Exception e)
            {
                throw new CommandHandlingException("The handler threw an exception when handling the command.", e);
            }
        }

        private Type? TryGetCommandHandlerInterfaceType(Type type)
        {
            return type.GetInterfaces()
                .FirstOrDefault(interfaceType =>
                    interfaceType.IsGenericType &&
                    interfaceType.GetGenericTypeDefinition() ==
                    typeof(ICommandHandler<>));
        }
    }
}