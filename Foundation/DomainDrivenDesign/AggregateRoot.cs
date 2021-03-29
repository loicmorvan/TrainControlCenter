namespace Foundation.DomainDrivenDesign
{
    public class AggregateRoot<TIdentifier> : Entity<TIdentifier>
        where TIdentifier : ValueObject<TIdentifier>
    {
        public AggregateRoot(TIdentifier id) : base(id)
        {
        }
    }
}