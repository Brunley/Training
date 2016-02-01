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
            Dice = dice; Sides = sides;
        }

        /// <summary>
        /// Perform a dice roll.
        /// </summary>
        /// <returns>
        /// The result of rolling the dice as a collection.
        /// </returns>
        public IList<decimal> Next() {
            return this
                .Do(() => Results = new List<decimal>())
                .ForEach<Roll>(() => Results.Add(new Irregular().Next(1, Sides)))
                .Results;
        }

        /// <summary>
        /// Perform a given action a number of times equal to a given <see cref="Roll.Dice"/>.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        /// <returns>
        /// The <see cref="Roll"/> for method chaining.
        /// </returns>
        private T ForEach<T>(Action action) where T : Roll {
            for (int i = 0; i < Dice; i++) action(); return this as T;
        }

        /// <summary>
        /// The results of rolling the dice.
        /// </summary>
        /// <remarks>
        /// The results will be a collection of rolls, one for each die rolled.
        /// </remarks>
        private IList<decimal> Results { get; set; }

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