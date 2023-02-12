using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.User.Repositories
{
    public interface IUserRepository
    {
        UserId SaveUser(User user);
        User GetUser(string id);
    }
}
