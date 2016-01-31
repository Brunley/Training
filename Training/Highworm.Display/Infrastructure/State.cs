using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Indicates a console state change
/// </summary>
/// <param name="state">The new state</param>
public delegate Highworm.Displays.Display StateChangeEventHandler(string state);

namespace Highworm {
    public class State {

        /// <summary>
        /// An event that is raised when state is changed
        /// </summary>
        public event StateChangeEventHandler Change;

        /// <summary>
        /// The currently set state
        /// </summary>
        public string Current {
            get;
            set;
        }

        /// <summary>
        /// The starting default state
        /// </summary>
        public string Start {
            get;
            set;
        }

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state">
        /// The state to set.
        /// </param>
        /// <returns></returns>
        public void Set(string state) {
            Current = state; OnChange(state);
        }

        /// <summary>
        /// Reset both the current and default states
        /// </summary>
        /// <param name="state">
        /// The state to set.
        /// </param>
        /// <returns></returns>
        public State Reset(string state) {
            Current = Start = state; OnChange(state); return this;
        }

        /// <summary>
        /// Return to the default state.
        /// </summary>
        public void Empty() {
            Current = Start; OnChange(Start);
        }

        /// <summary>
        /// Raised whenever the state changes.
        /// </summary>
        /// <param name="state"></param>
        public void OnChange(string state) {
            Change?.Invoke(state);
        }
    }

    /// <summary>
    /// Information concerning the State of a View.
    /// </summary>
    public class ViewState {
        /// <summary>
        /// Initialize a new ViewState
        /// </summary>
        public ViewState() {
            Visible = new List<string>();
            Current = string.Empty;
        }
        /// <summary>
        /// Indicates what state the view is visible in.
        /// </summary>
        public IList<string> Visible {
            get;
            set;
        }

        /// <summary>
        /// The current state of the view.
        /// </summary>
        public string Current {
            get;
            set;
        }

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state">
        /// The state to set.
        /// </param>
        /// <returns></returns>
        public void Set(string state) {
            Current = state;
        }

        /// <summary>
        /// Determines whether or not the View is able to be painted.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Paintable(string state) {
            return Visible.Count <= 0 || Visible.Contains(state);
        }
    }
}