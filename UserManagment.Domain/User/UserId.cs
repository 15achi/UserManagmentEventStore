using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.User
{
    public class UserId:EntityId
    {
        private Guid _guid;

        public UserId()
        {
            _guid = Guid.NewGuid();
        }

        public UserId(string id)
        {
            var c = id;
            _guid = Guid.Parse(id);
        }

        public override string ToString() => _guid.ToString();
    }
}
