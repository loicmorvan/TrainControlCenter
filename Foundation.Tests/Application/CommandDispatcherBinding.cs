using System;
using FluentAssertions;
using Foundation.Application;
using Moq;
using TechTalk.SpecFlow;

namespace Foundation.Tests.Application
{
    [Binding]
    public class CommandDispatcherBinding
    {
        private readonly ScenarioContext _context;

        public CommandDispatcherBinding(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"a developer had a collection of objects that are not handlers")]
        public void GivenADeveloperHadACollectionOfObjectsThatAreNotHandlers()
        {
            _context.Add("collection", new[] {new object()});
        }

        [Given(@"a developer had a collection of two handlers for the same command")]
        public void GivenADeveloperHadACollectionOfTwoHandlersForTheSameCommand()
        {
            var handler1 = Mock.Of<ICommandHandler<string>>();
            var handler2 = Mock.Of<ICommandHandler<string>>();

            _context.Add("collection", new[] {handler1, handler2});
        }

        [When(@"a developer creates a command dispatcher from the collection")]
        public void WhenADeveloperCreatesACommandDispatcherFromTheCollection()
        {
            var collection = _context.Get<object[]>("collection");

            CommandDispatcher Create()
            {
                return new(collection);
            }

            _context.Add("code", (Func<CommandDispatcher>) Create);
        }

        [Then(@"calling the constructor will throw an argument exception")]
        public void ThenCallingTheConstructorWillThrowAnArgumentException()
        {
            var code = _context.Get<Func<CommandDispatcher>>("code");

            code.Should().Throw<ArgumentException>();
        }

        [Given(@"a developer had a collection of one single handler")]
        public void GivenADeveloperHadACollectionOfOneSingleHandler()
        {
            var handlerMock = new Mock<ICommandHandler<string>>();

            _context.Add("collection", new[] {handlerMock.Object});
            _context.Add("handlerMock", handlerMock);
        }

        [Then(@"calling the constructor will create the command dispatcher")]
        public void ThenCallingTheConstructorWillCreateTheCommandDispatcher()
        {
            var code = _context.Get<Func<CommandDispatcher>>("code");

            var commandDispatcher = code();

            _context.Add("commandDispatcher", commandDispatcher);
        }

        [Then(@"dispatching the command will call the handler")]
        public void ThenDispatchingTheCommandWillCallTheHandler()
        {
            var commandDispatcher = _context.Get<CommandDispatcher>("commandDispatcher");
            var handlerMock = _context.Get<Mock<ICommandHandler<string>>>("handlerMock");
            var command = _context.Get<string>("command");

            commandDispatcher.Dispatch(command);

            handlerMock.Verify(x => x.Handle(command));
        }

        [Given(@"a developer had a command")]
        public void GivenADeveloperHadACommand()
        {
            _context.Add("command", "The command, content not important.");
        }
    }
}