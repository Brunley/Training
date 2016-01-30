using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;


namespace Highworm.Displays {
    /// <summary>
    /// The Header is printed at the top of the console.
    /// </summary>
    public class Participants : View<IList<IMayEncounter>> {
        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public override void Paint() {
            // we need to draw all of the characters in
            // batched groups, so form a collection for 
            // them now
            var groups = new List<List<IMayEncounter>> {
                new List<IMayEncounter>()
            };

            // add participants to the groups, starting a 
            // new group every 3 entries
            for (int i = 0; i < ViewData.Count; i++) {
                // add every 4th entry to a new group
                if (i % 3 == 0) groups.Add(new List<IMayEncounter>());
                // add the participant to the most recent group
                groups.Last().Add(ViewData[i]);
            }

            groups.EachNotNull(group => {
                // begin by drawing the top line for each character's sheet.
                group.EachNotNull(entry => {
                    Builder.Append($"{' ',1}{new string('-', 30),28}{' ',1}");
                }).Append(Builder, "\n");

                // draw the character name and level for each sheet
                group.EachNotNull(entry => {
                    Builder.Append($"|{' '}{entry.Character.Name,-20}{"Lv. 50",8}{' '}{'|'}");
                }).Append(Builder, "\n");

                // draw the name divider for each sheet
                group.EachNotNull(entry => {
                    Builder.Append($"{'|',1}{new string('-', 30),28}{'|',1}");
                }).Append(Builder, "\n");

                // draw each character's statistics
                group.NotNull(() => {
                    var skip = 0; // the number of statistics to skip
                    for (int i = 0; i < group.Take(1).Single().Character.Statistics.Count; i++) {
                        group.EachNotNull(entry => {
                            Builder.Append(
                                $"{'|',1}{" ",1}{entry.Character.Statistics.Skip(skip).Take(1).SingleOrDefault().Key,-20}{'|',3}{"10",-6}{'|',1}");
                        }).Append(Builder, "\n"); skip++;
                    }
                });

                // draw the bottom line of the mini-sheet
                group.EachNotNull(entry => {
                    Builder.Append($"{' ',1}{new string('-', 30),28}{' ',1}");
                }).Append(Builder, "\n");

            });
        }
    }
}