using Equ;

namespace Foundation.DomainDrivenDesign
{
    public abstract class Entity<TIdentifier> : MemberwiseEquatable<Entity<TIdentifier>>
        where TIdentifier : ValueObject<TIdentifier>
    {
        protected Entity(TIdentifier identity)
        {
            Identity = identity;
        }

        public TIdentifier Identity { get; }

        protected void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            // TODO
        }
    }
}