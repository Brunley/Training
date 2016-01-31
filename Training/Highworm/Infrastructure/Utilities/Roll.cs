using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    /// <summary>
    /// Represents a randomized roll of the dice.
    /// </summary>
    public class Roll {

        /// <summary>
        /// Create a new dice roll.
        /// </summary>
        /// <param name="dice">The number of dice to roll.</param>
        /// <param name="sides">The number of sides on each die.</param>
        public Roll(int dice, int sides) {
            this.Dice = dice;
            this.Sides = sides;
        }

        /// <summary>
        /// Perform a dice roll.
        /// </summary>
        /// <returns>
        /// The result of rolling the dice as a collection.
        /// </returns>
        public IList<decimal> Next() {
            return this
                .First(() => Results = new List<decimal>())
                .ForEach(() => Results.Add(new Irregular().Next(1, Sides)))
                .Results;
        }

        /// <summary>
        /// The results of rolling the dice.
        /// </summary>
        /// <remarks>
        /// The results will be a collection of rolls, one for each die rolled.
        /// </remarks>
        protected IList<decimal> Results { get; set; }

        /// <summary>
        /// The number of dice to roll.
        /// </summary>
        public int Dice { get; set; }

        /// <summary>
        /// The number of sides on each die.
        /// </summary>
        public int Sides { get; set; }
    }
}