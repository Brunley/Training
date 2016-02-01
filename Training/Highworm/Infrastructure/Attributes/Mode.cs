using System;

namespace Highworm {
    /// <summary>
    /// Declares the name used in selecting game mode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModeAttribute : Attribute {
        /// <summary>
        /// The actual name of the game mode.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initialize a new attribute
        /// </summary>
        public ModeAttribute() :
            base() {
        }

        /// <summary>
        /// Initialize a new attribute
        /// </summary>
        /// <param name="name">The name for the game mode.</param>
        public ModeAttribute(string name)
            : base() {
            this.Name = name;
        }
    }
}