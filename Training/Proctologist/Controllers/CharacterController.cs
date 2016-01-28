﻿using System.Collections.Generic;

namespace Highworm.Controllers {
    public class CharacterController {
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
                    { "Initiative", 0 },
                    { "Mana", 15 },
                    { "Health Replenishment", 5 },
                    { "Mana Replenishment", 5 },
                    { "Energy", 1 },
                    { "Force", 4 }
                }
            };
        }
    }
}