using System;

namespace Shared
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }
        
        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }

}