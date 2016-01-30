using System;
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
/// Indicates an entity that may be painted.
/// </summary>
public interface IMayPaint {
    void OnPaint();
}

namespace Highworm.Displays {
    public abstract class View : IMayPaint {
        /// <summary>
        /// An event that is raised when new input is given
        /// </summary>
        public event ConsoleReadEventHandler Read;

        /// <summary>
        /// Initialize a new printable component and setup
        /// the <see cref="System.Text.StringBuilder"/>.
        /// </summary>
        protected View() {
            ViewBuilder = new StringBuilder();
            Position = Position.Current;
            Visible = true;
        }

        /// <summary>
        /// The printable component's cursor position.
        /// </summary>
        private Position Position {
            get;
            set;
        }

        /// <summary>
        /// Raises the Input event
        /// </summary>
        /// <param name="type">
        /// The type of input event.
        /// </param>
        /// <param name="text">
        /// The text given in the event
        /// </param>
        protected void OnConsoleRead(string text) {
            Read?.Invoke(text);
        }

        /// <summary>
        /// The printable component's output text.
        /// </summary>
        /// <returns>
        /// A string to write at the component's cursor position.
        /// </returns>
        public abstract void OnPaint();

        /// <summary>
        /// Write the printable component to the command line.
        /// </summary>
        /// <param name="reset">
        /// Indicates whether the cursor will return to where it started
        /// after writing, or stay at the end of the component.
        /// </param>
        /// <param name="forceUpdate">
        /// Force the coordinates to update
        /// </param>
        public void Write(bool reset = true, bool forceUpdate = false) {
            // attempt to update the position if necessary
            if (ViewBuilder.Length <= 0 || forceUpdate) 
                Position = Position.Current;

            // move the cursor to the component's designated
            // coordinates, and clear the entire line so that
            // it does not bleed into existing text
            //Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(new string(' ', Console.WindowWidth));

            // perform the writing process to the
            // c# console and then return to the starting position
            if (Visible) Console.Write(this);
        }

        /// <summary>
        /// Converts this View to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return ViewBuilder.Clear().Paint(this);
        }

        /// <summary>
        /// Indicates whether or not the component should be drawn.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// The <see cref="System.Text.StringBuilder"/> used to construct the output.
        /// </summary>
        protected StringBuilder ViewBuilder {
            get; set;
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
        protected T ViewData { get; set; }

        /// <summary>
        /// Update a printable component to use
        /// data for an interpreter.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public View<T> Using(T data)  {
            // set the view data
            ViewData = data;
            // return the existing printable
            return this;
        }
    }
}