using System.Collections;
using System.Collections.Generic;

namespace Foundation.DomainDrivenDesign
{
    public class EntityCollection<TEntity, TIdentifier> : IEnumerable<TEntity>
        where TEntity : Entity<TIdentifier>
        where TIdentifier : ValueObject<TIdentifier>
    {
        private readonly Dictionary<TIdentifier, TEntity> _entities = new();

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _entities.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity.Identity, entity);
        }

        public bool Remove(TIdentifier identity)
        {
            return _entities.Remove(identity);
        }

        public bool Remove(TEntity entity)
        {
            return _entities.Remove(entity.Identity);
        }

        public bool Contains(TIdentifier identity)
        {
            return _entities.ContainsKey(identity);
        }

        public TEntity? TryGet(TIdentifier identity)
        {
            return _entities.TryGetValue(identity, out var entity) ? entity : null;
        }
    }
}