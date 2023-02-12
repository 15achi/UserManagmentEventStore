using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public abstract class AggregateRoot<TIdentity> : Entity<TIdentity>, IAggregateRoot<TIdentity>, IEntity<TIdentity> where TIdentity : IEntityId
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public int Version { get; }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected AggregateRoot()
        {
        }

        protected AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            if (events == null)
            {
                return;
            }

            foreach (IDomainEvent @event in events)
            {
                Mutate(@event);
                int version = Version;
                Version = version + 1;
            }
        }

        protected void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        protected void RemoveDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Remove(@event);
        }

        protected void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void Apply(IEnumerable<IDomainEvent> events)
        {
            foreach (IDomainEvent @event in events)
            {
                Apply(@event);
            }
        }

        protected void Apply(IDomainEvent @event)
        {
            Mutate(@event);
            AddDomainEvent(@event);
        }

        private void Mutate(IDomainEvent @event)
        {
            ((dynamic)this).On((dynamic)@event);
        }
    }
}
