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
        /// <param name="controller">A new <see cref="Highworm.Controllers.GameController"/></param>
        /// <param name="screen">A new <see cref="Highworm.Displays.Display"/></param>
        public Game(Controllers.GameController controller, Display screen) {
            Controller = controller; Screen = screen;
        }

        /// <summary>
        /// Specify the type of game that will be played.
        /// </summary>
        /// <param name="encounter">The type of <see cref="Highworm.IEncounter{T}"/> to start.</param>
        /// <returns>The current <see cref="Highworm.Game"/></returns>
        internal Game Mode(string encounter) {
            return After(() => {
                Controller.Encounter = Models.Encounter.Create<ViewModels.Battle, ViewModels.Participant>();
            });
        }

        /// <summary>
        /// Setup a game with all of the necessary views and their properties, as well
        /// as the input data.
        /// </summary>
        /// <remarks>
        /// This method may be used to reset the game using a new encounter.
        /// </remarks>
        /// <returns>The current <see cref="Highworm.Game"/></returns>
        internal Game Startup() {
            // initialize the default state as 'root'
            Screen.Initialize("root");

            // setup the views and input controls
            Screen
                .Then()
                .IncludeViews(new List<View> {
                    Display.Create<Header>(),
                    Display.Create<Space>(),
                    Display.Create<Menu>(),
                    Display.Create<Space>(),
                    Display.Create<Participants>()
                        .Using(Controller.Encounter.Participants),
                    Display.Create<Space>(),
                    Display.Create<InputMenuCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(Screen.DisplayState.Currently)
                        .IncludeVisibleState(new[] { String.Empty, "root", "menu" }),
                    Display.Create<InputParticipantNameCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(Controller.Encounter.Register<Models.Character>)
                        .IncludeVisibleState(new[] { "add" }),
                    Display.Create<InputParticipantNameForEditCommand>()
                        .OnEmpty(Screen.DisplayState.Empty)
                        .OnRead(null)
                        .IncludeVisibleState(new[] { "edit" })
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
        internal void Play() {
            do { Screen.Increment().Synchronize().Paint(); }
            while (true);
        }

        /// <summary>
        /// Perform an anonymous action and then return the current <see cref="Highworm.Game"/>.
        /// </summary>
        /// <param name="action">An anonymous <see cref="System.Action"/> to perform.</param>
        /// <returns>The current <see cref="Highworm.Game"/></returns>
        private Game After(Action action) {
            action(); return this;
        }

        /// <summary>
        /// The active <see cref="Highworm.Controllers.GameController"/>.
        /// </summary>
        private Controllers.GameController Controller { get; set; }
        /// <summary>
        /// The active <see cref="Highworm.Displays.Display"/> that is being drawn to.
        /// </summary>
        private Display Screen { get; set; }
    }

    class Program {
        [STAThread]
        static void Main(string[] args) {
            // initialize a new game and begin playing
            new Game(
                new Controllers.GameController(), 
                new Displays.Display()
            ).Mode("battle").Startup().Play();
        }
    }
}
