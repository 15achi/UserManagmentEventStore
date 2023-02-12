using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain.User
{
    public class Address: ValueObject
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
