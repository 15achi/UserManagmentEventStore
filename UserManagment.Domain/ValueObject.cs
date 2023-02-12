using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagment.Domain
{
    public abstract class ValueObject
    {
        private const int HighPrime = 557927;

        protected abstract IEnumerable<object> GetAtomicValues();

        public override int GetHashCode()
        {
            return GetAtomicValues().Select((object x, int i) => (x?.GetHashCode() ?? 0) + 557927 * i).Aggregate((int x, int y) => x ^ y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject valueObject = (ValueObject)obj;
            return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
        }

        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }

        public static bool operator ==(ValueObject one, ValueObject two)
        {
            return EqualOperator(one, two);
        }

        public static bool operator !=(ValueObject one, ValueObject two)
        {
            return NotEqualOperator(one, two);
        }

        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (((object)left == null) ^ ((object)right == null))
            {
                return false;
            }

            return left?.Equals(right) ?? true;
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }
    }
}

