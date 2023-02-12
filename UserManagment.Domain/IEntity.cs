using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public interface IEntity<out TIdentity> where TIdentity : IEntityId
    {
        TIdentity Id { get; }
    }
}
