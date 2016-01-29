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

            groups.EachNotNull(group => {
                // begin by drawing the top line for each character's sheet.
                group.EachNotNull(entry => {
                    Builder.Append($"{' ',1}{new string('-', 30),28}{' ',1}");
                }).Then(Builder, n => n.Append("\n"));

                // draw the character name and level for each sheet
                group.EachNotNull(entry => {
                    Builder.Append($"|{' '}{entry.Character.Name,-20}{"Lv. 50",8}{' '}{'|'}");
                }).Then(Builder, n => n.Append("\n"));

                // draw the name divider for each sheet
                group.EachNotNull(entry => {
                    Builder.Append($"{'|',1}{new string('-', 30),28}{'|',1}");
                }).Then(Builder, n => n.Append("\n"));

                // draw each character's statistics
                group.NotNull(() => {
                    var skip = 0; // the number of statistics to skip
                    for (int i = 0; i < group.FirstOrDefault().Character.Statistics.Count; i++) {
                        group.ForEach(entry => {
                            Builder.Append(
                                $"{'|',1}{" ",1}{entry.Character.Statistics.Skip(skip).Take(1).SingleOrDefault().Key,-20}{'|',3}{"10",-6}{'|',1}");
                        }); Builder.Append("\n"); skip++;
                    }
                });
               
                // draw the bottom line of the mini-sheet
                group.EachNotNull(entry => {
                    Builder.Append($"{' ',1}{new string('-', 30),28}{' ',1}");
                }).Then(Builder, n => n.Append("\n"));

            }); //Builder.Append("\n");

            // print the component
            return Builder;
        }
    }
}