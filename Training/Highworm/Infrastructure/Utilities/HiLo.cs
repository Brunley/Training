using System;

namespace Highworm {
    /// <summary>
    /// An entity for storing high and low values necessary for clean identity generation.
    /// </summary>
    public class HiLo {
        /// <summary>
        /// The current high value.
        /// </summary>
        private decimal High { get; set; }

        /// <summary>
        /// The current low value.
        /// </summary>
        private decimal Low { get; set; }

        /// <summary>
        /// The name of the HiLo generator instance.
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// The most recently generated key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Initialize a new identity generator.
        /// </summary>
        protected HiLo() { High = 32; Low = 0; }

        /// <summary>
        /// Create the next identity in the sequence.
        /// </summary>
        /// <returns>
        /// The identity that was generated.
        /// </returns>
        public string Next() {
            return $"{Name}/{Increment()}";
        }

        /// <summary>
        /// Retrieve an increment from the generator.
        /// </summary>
        /// <returns>Returns the incremented value.</returns>
        private decimal Increment() {
            if (Low + 1 >= High) Synchronize(); return Low++;
        }

        /// <summary>
        /// Discard unused low values and increase the high value.
        /// </summary>
        public void Synchronize() {
            Low = High; High += 32;
        }
    }

    /// <summary>
    /// An entity for storing high and low values necessary for clean identity generation.
    /// </summary>
    /// <typeparam name="T">The type of entity to generate identities for.</typeparam>
    public class HiLo<T> : HiLo {
        /// <summary>
        /// Initialize a new identity generator for the given type.
        /// </summary>
        /// <param name="name">The type to create a generator for.</param>
        public HiLo(string name) : base() { Name = name; }
    }
}