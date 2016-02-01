using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using Highworm.Displays;
using Highworm.Displays.Views;
using Highworm.Displays.Views.Inputs;

namespace Highworm {
    /// <summary>
    /// Represents an entire game.
    /// </summary>
    class Game {

        /// <summary>
        /// Initialize a new game.
        /// </summary>
        Game() { Controller = new Controllers.GameController(); }

        /// <summary>
        /// Specify the type of game that will be played.
        /// </summary>
        /// <param name="encounter">The type of <see cref="Highworm.IEncounter{T}"/> to start.</param>
        /// <returns>The current <see cref="Highworm.Game"/></returns>
        /// <remarks>
        /// This method may be used to start the game over.
        /// </remarks>
        Game Mode(string encounter) {
            return After(() => {
                Controller.Encounter = Models.Encounter.Create<ViewModels.Battle, ViewModels.Participant>();
            }).Startup();
        }

        /// <summary>
        /// Setup a game with all of the necessary views and their properties, as well
        /// as the input data.
        /// </summary>
        /// <remarks>
        /// This method may be used to reset the game using a new encounter.
        /// </remarks>
        /// <returns>The current <see cref="Highworm.Game"/></returns>
        Game Startup() {
            // initialize the default state as 'root'
            Controller.Screen.Initialize("root");

            // setup the views and input controls
            Controller.Screen
                .Do()
                .IncludeViews(new List<View> {
                    Display.Create<Header>(),
                    Display.Create<Space>(),
                    Display.Create<Menu>(),
                    Display.Create<Space>(),
                    Display.Create<Participants>()
                        .Using(Controller.Encounter.Participants),
                    Display.Create<Space>(),
                    Display.Create<InputMenuCommand>()
                        .OnEmpty(Controller.Screen.DisplayState.Empty)
                        .OnRead((input) => {
                            Controller
                                .Do().OnRead(input)
                                .Then()
                                    .Screen.DisplayState.Currently(input);
                        })
                        .AddVisibleStates(new[] { String.Empty, "root", "menu" }),
                    Display.Create<InputParticipantNameCommand>()
                        .OnEmpty(Controller.Screen.DisplayState.Empty)
                        .OnRead(Controller.Encounter.Register<Models.Character>)
                        .AddVisibleStates(new[] { "add" }),
                    Display.Create<InputParticipantNameForEditCommand>()
                        .OnEmpty(Controller.Screen.DisplayState.Empty)
                        .OnRead(null)
                        .AddVisibleStates(new[] { "edit" })
                })
                .Then()
                .Initialize();

            // return the current game
            return this;
        }

        /// <summary>
        /// Begin playing the game, initializing all of the views and
        /// their properties and setting up the application workflow.
        /// </summary>
        void Play() {
            do { Controller.Paint(); }
            while (true);
        }

        /// <summary>
        /// Perform an anonymous action and then return the current <see cref="Highworm.Game"/>.
        /// </summary>
        /// <param name="action">An anonymous <see cref="System.Action"/> to perform.</param>
        /// <returns>The current <see cref="Highworm.Game"/></returns>
        Game After(Action action) {
            action(); return this;
        }


        /// <summary>
        /// The active <see cref="Highworm.Controllers.GameController"/>.
        /// </summary>
        Controllers.GameController Controller { get; set; }

        
        [STAThread]
        static void Main(string[] args) {
            // initialize a new game and begin playing
            new Game().Mode("battle").Play();
        }
    }
}
