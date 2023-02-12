using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagment.API.Model;
using UserManagment.Domain.User.Repositories;

namespace UserManagmentEventStore.Queries.Queries
{
    public class QueriesService : IQueriesService
    {
        private readonly IUserRepository _userRepository;
        public QueriesService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDto GetUser(string userId)
        {
            var user = _userRepository.GetUser(userId);

            if (user == null) return new UserDto(); 

            return new UserDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.Id.ToString(),
                Address = user.UserAddress != null ? new AddressDto()
                {
                    City = user.UserAddress?.City,
                    Country = user.UserAddress?.Country,
                    Street = user.UserAddress?.Street,
                    ZipCode = user.UserAddress?.ZipCode
                } : null
            };
        }
    }
}
