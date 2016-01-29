using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Views {
    /// <summary>
    /// Represents a view of an encounter's participants.
    /// </summary>
    public class Participants : View<IList<IMayEncounter>> {
        /// <summary>
        /// The content that will be presented.
        /// </summary>
        public override IList<IMayEncounter> Content {
            get;
            set;
        }

        /// <summary>
        /// Custom logic to display the content
        /// </summary>
        public override StringBuilder Compose() {
            // make sure we clear the view
            Builder.Clear();
            // write each participant to the screen
            foreach(var participant in Content.OrderBy(n => n.Order)) {
                Builder.Append($"{participant.Character.Name,5}\n");

                foreach(var statistic in participant.Character.Statistics) {
                    Builder.Append($"{String.Empty,20}{statistic.Key}\n");
                }
            }
            // print the component
            return Builder;
        }
    }
}