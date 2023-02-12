using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.User;

namespace UserManagmentEventSsore.Commands.Commands
{
    public interface ICommandsService
    {
        UserId CreateUser(string firstName, string lastName);
        void UpdateUserAddress(UserId userId, string city, string country, string street, string zipcode);
    }
}
