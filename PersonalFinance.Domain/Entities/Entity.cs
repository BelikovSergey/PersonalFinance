using System;

namespace PersonalFinance.Domain.Entities
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other == null) return false;

            if (ReferenceEquals(this, other)) return true;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
