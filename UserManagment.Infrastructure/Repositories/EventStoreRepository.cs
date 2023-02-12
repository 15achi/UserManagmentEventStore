
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain;
using UserManagment.Infrastructure.Exceptions;
using UserManagment.Infrastructure.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UserManagment.Infrastructure.Repositories
{
    public class EventStoreRepository:IEventStore
    {

        private readonly DataContext _Context;

        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };

        public EventStoreRepository(DataContext Context)
        {
            _Context = Context;
        }


        public IReadOnlyCollection<IDomainEvent> Load(IEntityId aggregateRootId)
        {
            if (aggregateRootId == null) throw new AggregateRootNotProvidedException("AggregateRootId cannot be null");

            var query = (from E in _Context.EventStores
                         where E.AggregateId == aggregateRootId.ToString()
                         select new
                         {

                             Id = E.Id,
                             CreatedAt = E.CreatedAt,
                             Version = E.Version,
                             Name=E.Name,
                             AggregateId=E.AggregateId,
                             Data=E.Data,
                             Aggregate=E.Aggregate,
                             Sequence=E.Sequence

                         }).Select(x => new EventStoreDao
                         {
                             Id = x.Id,
                             Data=x.Data,
                             Version=x.Version,
                             CreatedAt=x.CreatedAt,
                             Sequence=x.Sequence,
                             Name=x.Name,
                             Aggregate=x.Aggregate,
                             AggregateId = x.AggregateId
                         });

            var domainEvents = query.Select(TransformEvent).Where(x => x != null).ToList().AsReadOnly();
            return domainEvents;

        }

        private IDomainEvent TransformEvent(EventStoreDao eventSelected)
        {
            var o = JsonConvert.DeserializeObject(eventSelected.Data, _jsonSerializerSettings);
            var evt = o as IDomainEvent;

            return evt;
        }


        public void Save(EntityId aggregateId, int originatingVersion, IReadOnlyCollection<IDomainEvent> events, string aggregateName = "Aggregate Name")
        {
            var Event = new EventStore();

            var E = new List<EventStore>();

            if (events.Count == 0) return;

            var listOfEvents = events.Select(ev => new EventStore
            {          
            
                Aggregate = aggregateName,
                CreatedAt=ev.CreatedAt,
                Data = JsonConvert.SerializeObject(ev, Formatting.Indented, _jsonSerializerSettings),
                Id = Guid.NewGuid(),
                Name=ev.GetType().Name,
                AggregateId = aggregateId.ToString(),
                Version = ++originatingVersion
            });

            _Context.EventStores.AddRange(listOfEvents);

            _Context.SaveChanges();
        }
    }
}

