﻿using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Indicates a console read event
/// </summary>
/// <param name="text"></param>
public delegate void ConsoleReadEventHandler(string text);

/// <summary>
/// Indicates an empty input was given
/// </summary>
public delegate void ConsoleReadEmptyEventHandler();



namespace Highworm {
    /// <summary>
    /// Indicates an entity that may be painted.
    /// </summary>
    public interface IMayPaint {
        void OnPaint(string state);

        /// <summary>
        /// The current state of the screen
        /// </summary>
        ViewState State {
            get;
            set;
        }
    }
}


namespace Highworm.Displays {
    /// <summary>
    /// A delegate for view drawing.
    /// </summary>
    /// <param name="sender"></param>
    public delegate void ConsolePaintEventHandler(View sender);

    public abstract class View : IMayPaint {
        /// <summary>
        /// An event that is raised when new input is given
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
        /// Initialize a new printable component and setup
        /// the <see cref="System.Text.StringBuilder"/>.
        /// </summary>
        public View() {
            ViewBuilder = new StringBuilder();
            Position = Position.Current;
            State = new ViewState();
        }

        /// <summary>
        /// The printable component's cursor position.
        /// </summary>
        private Position Position {
            get;
            set;
        }

        public int Pass {
            get;
            set;
        }

        /// <summary>
        /// Raises the Input event
        /// </summary>
        /// <param name="text">
        /// The text given in the event
        /// </param>
        protected void OnConsoleRead(string text) {
            if (text.Length == 0) Empty?.Invoke();
            else Read?.Invoke(text);
        }

        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public abstract void OnPaint(string state);

        /// <summary>
        /// Draw the view with the given state.
        /// </summary>
        /// <param name="state"></param>
        public void Draw(string state) {
            // attempt to update the position if necessary
            if (ViewBuilder.Length <= 0)
                Position = Position.Current;

            // set the view state
            State.Set(state);

            // if we reach this point, then the state is valid and we
            // can paint the view
            Console.Write(this);
        }

        /// <summary>
        /// Write the printable component to the command line.
        /// </summary>
        public void Paint() {
            Painting?.Invoke(this);
        }

        /// <summary>
        /// Converts this View to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return ViewBuilder.Clear().Paint(this);
        }


        /// <summary>
        /// The <see cref="System.Text.StringBuilder"/> used to construct the output.
        /// </summary>
        protected StringBuilder ViewBuilder {
            get;
            set;
        }

        /// <summary>
        /// The current state of the screen
        /// </summary>
        public ViewState State {
            get;
            set;
        }
    }

    /// <summary>
    /// An abstract override of the printable class that may
    /// also accept an interpreter for display purposes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class View<T> : View {
        /// <summary>
        /// The data that is going to be interpreted.
        /// </summary>
        protected T ViewData {
            get;
            set;
        }

        /// <summary>
        /// Update a printable component to use
        /// data for an interpreter.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public View<T> Using(T data) {
            ViewData = data; return this;
        }

        /// <summary>
        /// Specifies what to do on empty input behavior
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public View<T> OnEmpty(ConsoleReadEmptyEventHandler action) {
            this.Empty += action; return this;
        }

        /// <summary>
        /// Specifies what to do when input is read.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public View<T> OnRead(ConsoleReadEventHandler action) {
            this.Read += action; return this;
        }

        /// <summary>
        /// Specifies the state the view is visible in.
        /// </summary>
        /// <param name="state">
        /// A single visible state
        /// </param>
        /// <returns></returns>
        public View<T> OnState(string state) {
            this.State.Visible.Add(state); return this;
        }

        /// <summary>
        /// Specifies multiple states that the view is visible in.
        /// </summary>
        /// <param name="states">
        /// A list of visible states
        /// </param>
        /// <returns></returns>
        public View<T> OnState(string[] states) {
            states.ForEach(state => {
                State.Visible.Add(state);
            }); return this;
        }

        /// <summary>
        /// Writing that will only occur during given state.
        /// </summary>
        /// <param name="state">
        /// The state to require
        /// </param>
        /// <param name="method">
        /// The method to perform.
        /// </param>
        protected void OnState(string state, Action<StringBuilder> method) {
            if (State.Current == state) method(ViewBuilder);
        }
    }
}