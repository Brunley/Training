using System;

namespace Highworm {
    /// <summary>
    /// Declares the name used in identity generation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IdentityAttribute : Attribute {
        /// <summary>
        /// The actual name of the attributed entity for collections.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initialize a new attribute
        /// </summary>
        public IdentityAttribute() :
            base() {
        }

        /// <summary>
        /// Initialize a new attribute
        /// </summary>
        /// <param name="name">The name for the entity to be used in collections.</param>
        public IdentityAttribute(string name)
            : base() {
            this.Name = name;
        }
    }
}