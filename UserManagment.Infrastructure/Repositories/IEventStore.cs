using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain;

namespace UserManagment.Infrastructure.Repositories
{
    public interface IEventStore
    {
       void  Save(EntityId aggregateId,
            int originatingVersion,
            IReadOnlyCollection<IDomainEvent> events,
            string aggregateName = "Aggregate Name");

        IReadOnlyCollection<IDomainEvent> Load(IEntityId aggregateRootId);
    }
}
