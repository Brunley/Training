using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

namespace System {
    /// <summary>
    /// Represents a roll of the dice.
    /// </summary>
    public class Roll {
        /// <summary>
        /// Create a new dice roll.
        /// </summary>
        /// <param name="dice">
        /// The number of dice to roll.
        /// </param>
        /// <param name="sides">
        /// The number of sides on each die.
        /// </param>
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
            // create a new collection to contain the
            // results of our rolls
            Results = new List<decimal>();

            // for each die, perform a roll
            for (int i = 0; i < Dice; i++)
                Results.Add(new Irregular().Next(1, Sides));
            // return the rolls
            return Results;
        }

        /// <summary>
        /// The dice roll results.
        /// </summary>
        public IList<decimal> Results {
            get;
            set;
        }

        private int Dice {
            get;
            set;
        }

        private int Sides {
            get;
            set;
        }
    }
}