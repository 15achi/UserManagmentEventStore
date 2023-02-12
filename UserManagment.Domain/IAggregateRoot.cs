using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public interface IAggregateRoot<out TIdentity> : IEntity<TIdentity> where TIdentity : IEntityId
    {
        int Version { get; }

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    }
}
