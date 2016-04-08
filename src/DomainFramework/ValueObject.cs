using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainFramework
{
    /// <summary>
    /// Base class for value objects in domain
    /// </summary>
    /// <remarks>Objects that matter only as the combination of their attributes. Two value objects with the same values for all their attributes are considered equal</remarks>
    /// <typeparam name="T">The type of this value object</typeparam>
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
        where T : ValueObject<T>
    {
        /// <summary>
        /// To be overridden in inheriting classes for providing a collection of atomic values of
        /// this Value Object.
        /// </summary>
        /// <returns>Collection of atomic values.</returns>
        protected abstract IEnumerable<object> GetAtomicValues();

        #region IEquatable<T> Methods

        public bool Equals(ValueObject<T> other)
        {
            if ((object)other == null)
                return false;

            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                    return false;
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                    return false;
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        #endregion

        #region Methods Overrides

        /// <summary>
        /// Compares two Value Objects according to atomic values returned by <see cref="GetAtomicValues"/>.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>True if objects are considered equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as ValueObject<T>;
            if (other == null)
                return false;
            else
                return Equals(other);
        }
        
        /// <summary>
        /// Returns hashcode value calculated according to a collection of atomic values
        /// returned by <see cref="GetAtomicValues"/>.
        /// </summary>
        /// <returns>Hashcode value.</returns>
        public override int GetHashCode()
        {
            return GetAtomicValues()
               .Select(x => x != null ? x.GetHashCode() : 0)
               .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            if (((object)left) == null || ((object)right) == null)
                return object.Equals(left, right);
            else
                return left.Equals(right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !(left == right);
        }

        #endregion
    }
}
