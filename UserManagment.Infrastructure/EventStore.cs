using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Infrastructure
{
    public class EventStore
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public int Version { get; set; }

        public string Name { get; set; }

        public string AggregateId { get; set; }

        public string Data { get; set; }

        public string Aggregate { get; set; }


        [Description("ignore")]
        public int Sequence { get; set; }
    }
}
