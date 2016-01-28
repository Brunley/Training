using System.Collections.Generic;

namespace Highworm.Controllers {
    public class SetupController {
        /// <summary>
        /// Create a new character.
        /// </summary>
        /// <param name="name">
        /// The name of the character to create.
        /// </param>
        /// <returns></returns>
        public Character Create(string name) {
            return new Character {
                Name = name,
                Statistics = new Dictionary<string, decimal> {
                    { "Health", 20 },
                    { "Initiative", 0 }
                }
            };
        }
    }
}