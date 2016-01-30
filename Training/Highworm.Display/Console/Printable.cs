using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

public delegate void ConsoleReadEventHandler(string text);

namespace Highworm.Displays {
    public abstract class Printable {
        /// <summary>
        /// An event that is raised when new input is given
        /// </summary>
        public event ConsoleReadEventHandler Read;

        /// <summary>
        /// Initialize a new printable component and setup
        /// the <see cref="System.Text.StringBuilder"/>.
        /// </summary>
        protected Printable() {
            Builder = new StringBuilder();
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
        protected abstract StringBuilder Paint();

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
            if (Builder.Length <= 0 || forceUpdate) 
                Position = Position.Current;
            
            // clear the previously drawn text
            Builder.Clear();

            // move the cursor to the component's designated
            // coordinates, and clear the entire line so that
            // it does not bleed into existing text
            //Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(new string(' ', Console.WindowWidth));

            // perform the writing process to the
            // c# console and then return to the starting position
            if(Visible) Paint();
        }

        /// <summary>
        /// Converts this View to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Builder.Clear().Then(Paint);
        }

        /// <summary>
        /// Indicates whether or not the component should be drawn.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Write the printable component to the command line and moves
        /// the cursor to the next line
        /// </summary>
        public void WriteLine() {
            Write(true); Console.Write("\n");
        }

        /// <summary>
        /// The <see cref="System.Text.StringBuilder"/> used to construct the output.
        /// </summary>
        protected StringBuilder Builder {
            get; set;
        }
    }

    /// <summary>
    /// An abstract override of the printable class that may
    /// also accept an interpreter for display purposes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Printable<T> : Printable {
        /// <summary>
        /// The data that is going to be interpreted.
        /// </summary>
        public abstract T Content { get; set; }

        /// <summary>
        /// Update a printable component to use
        /// data for an interpreter.
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public Printable<T> Using(T data)  {
            // set the view data
            Content = data;
            // return the existing printable
            return this;
        }
    }
}