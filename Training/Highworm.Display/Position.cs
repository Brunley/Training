using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays {
    /// <summary>
    /// Represents the position of the cursor on the console.
    /// </summary>
    public class Position {

        /// <summary>
        /// Get a new position at the current cursor location
        /// </summary>
        public static Position Current => new Position(System.Console.CursorLeft, System.Console.CursorTop);

        /// <summary>
        /// Get a new position at the specified coordinates.
        /// </summary>
        /// <param name="x"> The horizontal position.</param> 
        /// <param name="y"> The vertical position. </param>
        /// <returns>
        /// A new <see cref="Position"/>.
        /// </returns>
        public static Position At(int x, int y) {
            return new Position(x, y);
        }

        /// <summary>
        /// Initialize a new position at 0,0
        /// </summary>
        public Position() {
            X = 0; Y = 0;
        }

        /// <summary>
        /// Initialize a new position at the given coordinates.
        /// </summary>
        /// <param name="x"> The horizontal position.</param> 
        /// <param name="y"> The vertical position. </param>
        public Position(int x, int y): base() {
            X = x; Y = y;
        }

        /// <summary>
        /// The horizontal position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The vertical position.
        /// </summary>
        public int Y { get; set; }
    }
}