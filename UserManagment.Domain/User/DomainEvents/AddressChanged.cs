using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.User.DomainEvents
{
    public class AddressChanged:DomainEvent
    {
        public string City { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public string Street { get; }

        public AddressChanged(string city,
            string country,
            string zipcode,
            string street,
            string aggregateId) : base(aggregateId)
        {
            City = city;
            Country = country;
            ZipCode = zipcode;
            Street = street;
        }
    }
}
