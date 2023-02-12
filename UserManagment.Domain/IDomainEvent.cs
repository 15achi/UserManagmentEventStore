using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public interface IDomainEvent
    {
        int Sequence { get; }

        int Version { get; }

        DateTime CreatedAt { get; set; }
    }
}
