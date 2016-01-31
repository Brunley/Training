using System.Collections;
using System.Collections.Generic;

namespace Highworm {
    public class State {
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
            Current = state;
        }

        /// <summary>
        /// Reset both the current and default states
        /// </summary>
        /// <param name="state">
        /// The state to set.
        /// </param>
        /// <returns></returns>
        public State Reset(string state) {
            Current = Start = state; return this;
        }

        /// <summary>
        /// Return to the default state.
        /// </summary>
        public void Empty() {
            Current = Start;
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
    }
}