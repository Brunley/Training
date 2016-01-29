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

            // if there is no data, then we shouldn't 
            // try to continue
            if (Content == null) return Builder;

            // we need to draw all of the characters in
            // batched groups, so form a collection for 
            // them now
            var groups = new List<List<IMayEncounter>> {
                new List<IMayEncounter>()
            };

            // add participants to the groups, starting a 
            // new group every 3 entries
            for (int i = 0; i < Content.Count; i++ ) {
                // add every 4th entry to a new group
                if (i % 3 == 0) groups.Add(new List<IMayEncounter>());
                // add the participant to the most recent group
                groups.Last().Add(Content[i]);          
            }
            if (groups.Count <= 0) return Builder;

            groups.ForEach(group => {
                // begin by drawing the top line for each character's sheet.
                group.ForEach(entry => {
                    Builder.Append($"{' ',1}{new string('-', 30),28}{' ',1}");
                }); if(group.Count > 0) Builder.Append("\n");

                // draw the character name and level for each sheet
                group.ForEach(entry => {
                    Builder.Append($"|{' '}{entry.Character.Name,-20}{"Lv. 50",8}{' '}{'|'}");
                }); if (group.Count > 0) Builder.Append("\n");

                // draw the name divider for each sheet
                group.ForEach(entry => {
                    Builder.Append($"{'|',1}{new string('-', 30),28}{'|',1}");
                }); if (group.Count > 0) Builder.Append("\n");

                // draw each character's statistics
                if (group.Count > 0) {
                    var skip = 0; // the number of statistics to skip
                    for (int i = 0; i < group.FirstOrDefault().Character.Statistics.Count; i++) {
                        group.ForEach(entry => {
                            Builder.Append(
                                $"{'|',1}{" ",1}{entry.Character.Statistics.Skip(skip).Take(1).SingleOrDefault().Key,-20}{'|',3}{"10",-6}{'|',1}");
                        }); Builder.Append("\n"); skip++;
                    }
                }

                // draw the bottom line of the mini-sheet
                group.ForEach(entry => {
                    Builder.Append($"{' ',1}{new string('-', 30),28}{' ',1}");
                }); if (group.Count > 0) Builder.Append("\n");

            }); //Builder.Append("\n");

            // print the component
            return Builder;
        }
    }
}