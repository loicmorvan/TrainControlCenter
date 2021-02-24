using System;
using Foundation.DomainDrivenDesign;
using Moq;
using NetworkEdition.Domain.NetworkAggregate;
using NetworkEdition.Domain.NetworkAggregate.DomainEvents;
using Xunit;

namespace NetworkEdition.Domain.Tests
{
    public static class GivenANetwork
    {
        public class WhenRemovingARelay
        {
            [Fact]
            public void ChecksForIdentityValidity()
            {
                // Arrange
                var sut = new Network(Guid.NewGuid());
                var observerMock = new Mock<IObserver<DomainEvent>>();
                using var disposable = sut.DomainEvents.Subscribe(observerMock.Object);

                // Act + Assert
                Assert.Throws<ArgumentException>(() => sut.RemoveRelay(Guid.NewGuid()));
                observerMock.VerifyNoOtherCalls();
            }

            [Fact]
            public void DoesRemoveTheRelay()
            {
                // Arrange
                var networkIdentity = (NetworkIdentifier) Guid.NewGuid();
                var sut = new Network(networkIdentity);
                var relayIdentity = (RelayIdentifier) Guid.NewGuid();
                sut.CreateRelay(relayIdentity);

                var observerMock = new Mock<IObserver<DomainEvent>>();
                using var disposable = sut.DomainEvents
                                          .Subscribe(observerMock.Object);

                // Act
                sut.RemoveRelay(relayIdentity);

                // Assert
                observerMock.Verify(x => x.OnNext(new RelayRemoved(networkIdentity, relayIdentity)));
                observerMock.VerifyNoOtherCalls();
            }
        }

        public class WhenAddingARelay
        {
            [Fact]
            public void DoesCreateARelay()
            {
                // Arrange
                var networkIdentity = (NetworkIdentifier) Guid.NewGuid();
                var sut = new Network(networkIdentity);
                var relayIdentity = (RelayIdentifier) Guid.NewGuid();
                sut.CreateRelay(relayIdentity);

                var observerMock = new Mock<IObserver<DomainEvent>>();
                using var disposable = sut.DomainEvents
                                          .Subscribe(observerMock.Object);

                // Act
                sut.RemoveRelay(relayIdentity);

                // Assert
                observerMock.Verify(x => x.OnNext(new RelayRemoved(networkIdentity, relayIdentity)));
                observerMock.VerifyNoOtherCalls();
            }
        }
    }
}