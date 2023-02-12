using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.API.Model;

namespace UserManagmentEventStore.Queries.Queries
{
    public interface IQueriesService
    {
        UserDto GetUser(string userId);
    }
}
