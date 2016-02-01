﻿using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays {
    /// <summary>
    /// An entity that can be drawn to the screen within specified boundaries.
    /// </summary>
    public class Control {
        /// <summary>
        /// The static width of the control.
        /// </summary>
        private int Width { get; set; }

        /// <summary>
        /// A count of the current pens.
        /// </summary>
        private int Count { get; set; }

        /// <summary>
        /// A collection of pens to use for writing to the screen.
        /// </summary>
        private IList<Pen> Pens { get; set; }

        /// <summary>
        /// Initialize a new control with a collection of pens.
        /// </summary>
        /// <param name="width">The width to create the control with.</param>
        public Control(int width = 45) {
            Pens = new List<Pen>(); Width = width; Count = 0;
        }

        /// <summary>
        /// Write a new <see cref="Highworm.Displays.Control.Pen"/> to
        /// the <see cref="Highworm.Displays.Control"/>.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Control.Pen"/></typeparam>
        /// <param name="pen">A type that inherits from <see cref="Highworm.Displays.Control.Pen"/></param>
        /// <returns>The current <see cref="Highworm.Displays.Control"/>.</returns>
        public Control Write<T>(T pen) where T : Pen {
            Pens.Add( pen.Order(Count++) ); return this;
        }

        /// <summary>
        /// Represents a pen that will draw to the screen.
        /// </summary>
        public class Pen {
            /// <summary>
            /// The number of columns this pen will span.
            /// </summary>
            private int Columns { get; set; }

            /// <summary>
            /// The pen's index in the collection.
            /// </summary>
            private int Index { get; set; }

            /// <summary>
            /// Determines whether the number of characters will
            /// be counted to determine width, or if it is set
            /// manually.
            /// </summary>
            private bool Count { get; set; }

            /// <summary>
            /// Determines whether or not the content will be left or right
            /// aligned when it is printed to the screen.
            /// </summary>
            private bool Left { get; set; }

            /// <summary>
            /// A <see cref="System.Text.StringBuilder"/> representing the current text.
            /// </summary>
            private string Text { get; set; }

            /// <summary>
            /// Update the index order for the drawing utility.
            /// </summary>
            /// <param name="index">The index to set.</param>
            /// <returns>The existing pen with an updated index.</returns>
            internal Pen Order(int index) {
                Index = index; return this;
            }

            /// <summary>
            /// Initialize a new pen with the given text and the
            /// specified column span.
            /// </summary>
            /// <param name="index">The pen's index count.</param>
            /// <param name="text">The text to write.</param>
            /// <param name="count">Whether to count the number of characters for column sizing.</param>
            /// <param name="columns">The amount of columns to span.</param>
            /// <param name="left">Whether the content should be left aligned.</param>
            /// <remarks>
            /// If the columns field is left empty, the control will dynamically size.
            /// </remarks>
            public Pen(string text, bool count = false, int columns = 0, bool left = false) {
                Text = text; Count = count; Columns = columns; Left = left;
            }
        }
    }
}