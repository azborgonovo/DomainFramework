using System;

namespace DomainFramework
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    /// <remarks>Objects that have a distinct identity that runs through time and different representations</remarks>
    /// <typeparam name="TIdentity">The identity type of this entity</typeparam>
    public abstract class Entity<TIdentity> : IEquatable<Entity<TIdentity>>
    {
        public TIdentity Id { get; protected set; }

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return Id == null || Id.Equals(default(TIdentity));
        }

        #region IEquatable<T> Methods

        public bool Equals(Entity<TIdentity> other)
        {
            if ((object)other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            if (IsTransient() || other.IsTransient())
                return false;

            return Id.Equals(other.Id);
        }

        #endregion

        #region Overrides Methods

        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/></param>
        /// <returns><see cref="M:System.Object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as Entity<TIdentity>;
            if (other == null)
                return false;
            
            return Equals(other);
        }

        /// <summary>
        /// <see cref="M:System.Object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="M:System.Object.GetHashCode"/></returns>
        public override int GetHashCode()
        {
            return IsTransient() ? base.GetHashCode() : Id.GetHashCode();
        }

        public static bool operator ==(Entity<TIdentity> left, Entity<TIdentity> right)
        {
            if (((object)left) == null || ((object)right) == null)
                return object.Equals(left, right);
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity<TIdentity> left, Entity<TIdentity> right)
        {
            return !(left == right);
        }

        #endregion
    }
}
