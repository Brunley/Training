using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays {

    /// <summary>
    /// Indicates a console state change
    /// </summary>
    /// <param name="state">The new state</param>
    public delegate Display StateChangeEventHandler(string state);

    /// <summary>
    /// Displays all information about the current game.
    /// </summary>
    public class Display {

        /// <summary>
        /// Initialize a new screen display and setup the base properties.
        /// </summary>
        /// <remarks>
        /// The display will raise the <see cref="StateChangeEventHandler"/> event whenever
        /// its state is changed.
        /// </remarks>
        public Display() {
            Views = new List<View>(); DisplayState = new State(); DisplayState.Change += this.OnStateChange;
        }

        /// <summary>
        /// Create a new <see cref="Highworm.Displays.View{T}"/>
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Highworm.Displays.View"/>.</typeparam>
        /// <returns>
        /// Returns the view, for method chaining.
        /// </returns>
        /// <remarks>
        /// The view must have a public default constructor.
        /// </remarks>
        public static T Create<T>() where T : View, new() {
            return new T();
        }

        /// <summary>
        /// Create a new <see cref="Highworm.Displays.View{T}"/> and runs an expression against it.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Highworm.Displays.View"/>.</typeparam>
        /// <param name="action">The expression to perform against the view.</param>
        /// <returns>
        /// Returns the view, for method chaining.
        /// </returns>
        /// <remarks>
        /// The view must have a public default constructor.
        /// </remarks>
        public static T Create<T>(Action<T> action) where T : View, new() {
            var printable = Create<T>(); action(printable); return printable;
        }

        /// <summary>
        /// Raised whenever a view is requesting permission to be painted
        /// to the screen.
        /// </summary>
        /// <param name="view">The <see cref="Highworm.Displays.View"/> being painted.</param>
        /// <remarks>
        /// The view will not be painted if the refresh rates are out of sync.
        /// </remarks>
        public void OnPaintingView(View view) {
            if (view.ViewRefresh == Refresh)
                view.Paint(DisplayState.Current);
        }

        /// <summary>
        /// Clears the console and begins painting all of the ellgibile
        /// views to the screen. 
        /// </summary>
        /// <remarks>
        /// This method might be interrupted by incrementing
        /// the <see cref="Highworm.Displays.Display.Refresh"/> before it finishes
        /// iterating through the <see cref="Highworm.Displays.Display.Views"/>.
        /// </remarks>
        public void Paint() {
            Console.Clear(); Views.Where(n => n.ViewState.Paintable(DisplayState.Current)).ForEach(view => { 
                view.Paint();
            });
        }

        /// <summary>
        /// A collection of all views that have been added to the display.
        /// </summary>
        public IList<View> Views { get; set; }

        /// <summary>
        /// The current state of the display.
        /// </summary>
        /// <remarks>
        /// State is used to determine if a component can be drawn to the screen, or what happens when
        /// input is given.
        /// </remarks>
        public State DisplayState { get; set; }

        /// <summary>
        /// Indicates the current refresh cycle.
        /// </summary>
        /// <remarks>
        /// Refresh cycle is used in situations where the drawing process needs to
        /// be interrupted; Such as changing the view state before all views have been
        /// fully drawn. If the views refresh and the display refresh do not match, then
        /// the view will not be drawn.
        /// </remarks>
        public int Refresh { get; set; }

        /// <summary>
        /// An encapsulation of the current <see cref="Highworm.Displays.Display"/> draw state, which
        /// may be used to determine which specific components and behaviors are application during any
        /// given painting phase.
        /// </summary>
        public class State {

            /// <summary>
            /// An event that occurs whenever the state is changed.
            /// </summary>
            public event StateChangeEventHandler Change;

            /// <summary>
            /// The current state of the display.
            /// </summary>
            public string Current { get; private set; }

            /// <summary>
            /// The default, starting state that the display will
            /// always reset to.
            /// </summary>
            private string Start { get; set; }

            /// <summary>
            /// Raised whenever something causes the state to change.
            /// </summary>
            /// <param name="state">The state that was set.</param>
            private void OnChange(string state) {
                Change?.Invoke(state);
            }

            /// <summary>
            /// Specify a new current state for the display and raise
            /// the state change event.
            /// </summary>
            /// <param name="currentState">The state to set as the current one.</param>
            public void Currently(string currentState) {
                Current = currentState; OnChange(currentState);
            }

            /// <summary>
            /// Reset both the current and default states, and synchronize them and raise the state change event.
            /// </summary>
            /// <param name="defaultState">The state to reset all data to.</param>
            /// <returns>
            /// The <see cref="State"/> for method chaining.
            /// </returns>
            public State Reset(string defaultState) {
                Current = Start = defaultState; OnChange(defaultState); return this;
            }

            /// <summary>
            /// Return to the default state and raise the state change event.
            /// </summary>
            public void Empty() {
                Current = Start; OnChange(Start);
            }
        }
    }
}