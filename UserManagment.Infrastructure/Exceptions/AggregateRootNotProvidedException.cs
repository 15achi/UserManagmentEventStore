using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Infrastructure.Exceptions
{
    public class AggregateRootNotProvidedException :Exception
    {
        public AggregateRootNotProvidedException(string message) : base(message)
        {

        }
    }
}
