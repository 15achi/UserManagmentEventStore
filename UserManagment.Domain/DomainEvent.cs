using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public abstract class DomainEvent:IDomainEvent
    {
        public Guid Id { get; }

        public string AggregateId { get; }

        [JsonIgnore]
        public int Version { get; private set; }

        [JsonIgnore]
        public int Sequence { get; private set; }

        public DateTime CreatedAt { get; set; }

        protected DomainEvent(string aggregateId)
        {
            Guid guid = Guid.NewGuid();
            DateTime now = DateTime.Now;
            Id = guid;
            AggregateId = aggregateId;
            DateTime dateTime2 = (CreatedAt = now);
            int num2 = (Version = 0);
            num2 = (Sequence = 0);
        }

        [JsonConstructor]
        protected DomainEvent(Guid id, string aggregateId, DateTime createdAt)
        {
            Id = id;
            AggregateId = aggregateId;
            DateTime dateTime2 = (CreatedAt = createdAt);
        }

        public void WithVersionAndSequence(int version, int sequence)
        {
            int num2 = (Version = version);
            num2 = (Sequence = sequence);
        }
    }
}
   
