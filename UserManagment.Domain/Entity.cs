using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public abstract class Entity<TIdentity> : IEntity<TIdentity> where TIdentity : IEntityId
    {
        public abstract TIdentity Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return EqualityComparer<TIdentity>.Default.Equals(Id, ((Entity<TIdentity>)obj).Id);
        }

        public static bool operator ==(Entity<TIdentity> lhs, Entity<TIdentity> rhs)
        {
            return lhs?.Equals(rhs) ?? ((object)rhs == null);
        }

        public static bool operator !=(Entity<TIdentity> lhs, Entity<TIdentity> rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            if (Id.Equals(default(TIdentity)))
            {
                return base.GetHashCode();
            }

            return GetType().GetHashCode() ^ Id.GetHashCode();
        }
    }
}
