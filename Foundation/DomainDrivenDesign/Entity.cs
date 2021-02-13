using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Equ;

namespace Foundation.DomainDrivenDesign
{
    public abstract class Entity<TIdentifier> : MemberwiseEquatable<Entity<TIdentifier>>, IDisposable
        where TIdentifier : ValueObject<TIdentifier>
    {
        private readonly Subject<DomainEvent> _domainEvents = new();

        protected Entity(TIdentifier identity)
        {
            Identity = identity;
        }

        public TIdentifier Identity { get; }

        public IObservable<DomainEvent> DomainEvents => _domainEvents.AsObservable();

        protected void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            // TODO: This is not the way it should be handled.
            _domainEvents.OnNext(@event);
        }

        public void Dispose()
        {
            _domainEvents.Dispose();
        }
    }
}