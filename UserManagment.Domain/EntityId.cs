using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public abstract class EntityId:ValueObject, IEntityId
    {
        public abstract override string ToString();

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ToString();
        }
    }
}
