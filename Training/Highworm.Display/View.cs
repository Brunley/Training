using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays {
    /// <summary>
    /// A view represents an encapsulation of information that may be drawn to the
    /// screen in sequence by a <see cref="Highworm.Displays.Display"/> using the
    /// text from a <see cref="System.Text.StringBuilder"/>.
    /// </summary>
    public abstract class View : IMayPaint {
        /// <summary>
        /// An event that is raised when non-empty input is given
        /// </summary>
        public event ConsoleReadEventHandler Read;

        /// <summary>
        /// An event that is raised when empty input is given.
        /// </summary>
        public event ConsoleReadEmptyEventHandler Empty;

        /// <summary>
        /// An event that is raised when it is time to draw the view.
        /// </summary>
        public event ConsolePaintEventHandler Painting;

        /// <summary>
        /// Initialize a new printable view and the 
        /// <see cref="System.Text.StringBuilder"/> it will use
        /// to draw to the screen.
        /// </summary>
        protected View() {
            ViewBuilder = new StringBuilder();
            ViewPosition = Position.Current;
            ViewState = new State();
        }

        /// <summary>
        /// Raise a <see cref="ConsoleReadEventHandler"/>.
        /// </summary>
        /// <param name="input">
        /// The text that was read from the console.
        /// </param>
        protected void OnConsoleRead(string input) {
            if (input.Length == 0) Empty?.Invoke();
            else Read?.Invoke(input);
        }

        /// <summary>
        /// Used to compose the <see cref="System.Text.StringBuilder"/> content that
        /// will eventually be writen to the screen.
        /// </summary>
        /// <param name="displayState">
        /// The state of the <see cref="Highworm.Displays.Display"/>.
        /// </param>
        public abstract void Compose(string displayState);

        /// <summary>
        /// Begin painting this view with the given state.
        /// </summary>
        /// <param name="displayState">
        /// The state of the <see cref="Highworm.Displays.Display"/>
        /// </param>
        /// <remarks>
        /// If the <see cref="System.Text.StringBuilder"/> has no data, then the cursor position
        /// will be reset to wherever it is on the screen. This should occur each time the screen is
        /// repainted.
        /// 
        /// The view will have its <see cref="State.Current"/> set if it can be drawn.
        /// </remarks>
        public void Paint(string displayState) {
            // attempt to update the position if necessary
            if (ViewBuilder.Length <= 0)
                ViewPosition = Position.Current;

            // set the view state
            ViewState.Currently(displayState);

            // if we reach this point, then the state is valid and we
            // can paint the view
            Console.Write(this);
        }

        /// <summary>
        /// Inform the calling display that this component is ready to be drawn
        /// to the screen, and await for it to decide how to proceed.
        /// </summary>
        public void Paint() {
            Painting?.Invoke(this);
        }

        /// <summary>
        /// Converts this <see cref="Highworm.Displays.View"/> to 
        /// a <see cref="System.String"/> using a <see cref="System.Text.StringBuilder"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="System.Text.StringBuilder"/> will be cleared before it is repainted.
        /// </returns>
        public override string ToString() {
            return ViewBuilder.Clear().Paint(this);
        }

        /// <summary>
        /// The <see cref="System.Text.StringBuilder"/> used to construct the output.
        /// </summary>
        protected StringBuilder ViewBuilder { get; set; }

        /// <summary>
        /// Indicates the current state of the view, and what
        /// states it is allowed to be painted in.
        /// </summary>
        public State ViewState { get; set; }

        /// <summary>
        /// Indicates the view's starting cursor position.
        /// </summary>
        /// <remarks>
        /// The position will be initialized the first time the
        /// view is called.
        /// </remarks>
        private Position ViewPosition { get; set; }

        /// <summary>
        /// Indicates the refresh cycle when this view was told to paint itself.
        /// </summary>
        /// <remarks>
        /// Refresh cycle is used in situations where the drawing process needs to
        /// be interrupted; Such as changing the view state before all views have been
        /// fully drawn. If the views refresh and the display refresh do not match, then
        /// the view will not be drawn.
        /// </remarks>
        public int ViewRefresh { get; set; }


        /// <summary>
        /// An encapsulation of the current <see cref="Highworm.Displays.View"/> draw state, which
        /// may be used to determine which specific behaviors are application during any
        /// given painting phase.
        /// </summary>
        public class State {
            /// <summary>
            /// Initialize a new state and setup the basic properties.
            /// </summary>
            public State() {
                Visible = new List<string>();
                Current = string.Empty;
            }

            /// <summary>
            /// Indicates what states the view is visible during.
            /// </summary>
            public IList<string> Visible { get; set; }

            /// <summary>
            /// The current state of the view.
            /// </summary>
            public string Current { get; set; }

            /// <summary>
            /// Specify a new current state for the view and raise
            /// the state change event.
            /// </summary>
            /// <param name="currentState">The state to set as the current one.</param>
            public void Currently(string currentState) {
                Current = currentState;
            }

            /// <summary>
            /// Indicates whether or not the view is elligible for painting.
            /// </summary>
            /// <param name="state">The state to validate elligibility against.</param>
            /// <returns>
            /// True if the view is elligible.
            /// </returns>
            public bool Paintable(string state) {
                return Visible.Count <= 0 || Visible.Contains(state);
            }
        }
    }

    /// <summary>
    /// A view that can contain <typeparamref name="T"/> type of data, and may synchronize
    /// with entities to offer more dynamic output.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class View<T> : View {
        /// <summary>
        /// The <typeparamref name="T"/> data that is going to be used
        /// for rendering the view to the screen.
        /// </summary>
        /// <remarks>
        /// The <typeparamref name="T"/> must have a public default constructor.
        /// </remarks>
        protected T ViewData { get; set; }

        /// <summary>
        /// Updates the <typeparamref name="T"/> view data for the
        /// view, and keeps it synchronized with the source so that
        /// it may be used dynamically.
        /// </summary>
        /// <param name="viewData"> The data to synchronize.</param>
        /// <returns>
        /// Returns the original view for chained method calls.
        /// </returns>
        public View<T> Using(T viewData) {
            ViewData = viewData; return this;
        }

        /// <summary>
        /// Raised when empty input is given from the console.
        /// </summary>
        /// <param name="consoleReadEmptyEventAction">The action to take when the event occurs.</param>
        /// <returns>
        /// Returns the original view for chained method calls.
        /// </returns>
        public View<T> OnEmpty(ConsoleReadEmptyEventHandler consoleReadEmptyEventAction) {
            this.Empty += consoleReadEmptyEventAction; return this;
        }

        /// <summary>
        /// Raised when non-empty input is given from the console.
        /// </summary>
        /// <param name="consoleReadEventAction">The action to take when the event occurs.</param>
        /// <returns>
        /// Returns the original view for chained method calls.
        /// </returns>
        public View<T> OnRead(ConsoleReadEventHandler consoleReadEventAction) {
            this.Read += consoleReadEventAction; return this;
        }

        /// <summary>
        /// Adds the given state to the list of visible states for this
        /// view.
        /// </summary>
        /// <param name="state">The state this view will be visible during.</param>
        /// <returns>
        /// Returns the original view for chained method calls.
        /// </returns>
        public View<T> AddVisibleStates(string state) {
            this.ViewState.Visible.Add(state); return this;
        }

        /// <summary>
        /// Adds the given states to the list of visible states for this
        /// view.
        /// </summary>
        /// <param name="states">The states this view will be visible during.</param>
        /// <returns>
        /// Returns the original view for chained method calls.
        /// </returns>
        public View<T> AddVisibleStates(string[] states) {
            states.ForEach(state => {
                ViewState.Visible.Add(state);
            }); return this;
        }

        /// <summary>
        /// A method that will only be run during an expected state.
        /// </summary>
        /// <param name="state">The state required for the method to run.</param>
        /// <param name="method">The method to perform during the visible state.</param>
        protected void OnlyDuringState(string state, Action<StringBuilder> method) {
            if (ViewState.Current == state) method(ViewBuilder);
        }
    }
}