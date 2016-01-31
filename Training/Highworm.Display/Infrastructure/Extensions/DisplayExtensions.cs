﻿using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays {
    /// <summary>
    /// Methods for working with <see cref="Highworm.Displays.Display"/> entities.
    /// </summary>
    public static partial class DisplayExtensions {
        /// <summary>
        /// Introduce a collection of <see cref="Highworm.Displays.View"/>s 
        /// to the <see cref="Highworm.Displays.Display"/>.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <param name="views">A collection of <see cref="Highworm.Displays.View"/>s</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T IncludeViews<T>(this T display, IList<View> views) where T : Display {
            views.ForEach(view => {
                display.Views.Add(view); 
            }); return display;
        }

        /// <summary>
        /// Initialize the <see cref="Highworm.Displays.View"/>s that belong to 
        /// a <see cref="Highworm.Displays.Display"/> and wire up event handlers.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T Initialize<T>(this T display) where T : Display {
            display.Views.ForEach(view => {
                view.Painting += display.OnPaintingView;
            }); return display;
        }

        /// <summary>
        /// Initialize the <see cref="Highworm.Displays.Display"/> and
        /// set its default state.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <param name="state">The state to declare as default.</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T Initialize<T>(this T display, string state) where T : Display {
            display.DisplayState.Reset(state); return display.OnStateChange(state);
        }

        /// <summary>
        /// A simple step that returns a non-null <see cref="Highworm.Displays.Display"/>.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T Then<T>(this T display) where T : Display {
            return display;
        }

        /// <summary>
        /// Raised whenever the <see cref="Highworm.Displays.Display.State.Change"/>
        /// event is fired off, indicating that the display has changed its state.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <param name="state">The state to declare a change to.</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T OnStateChange<T>(this T display, string state) where T : Display {
            display.Increment(); display.Paint(); return display;
        }

        /// <summary>
        /// Synchronize the refresh value of a <see cref="Highworm.Displays.Display"/> 
        /// and all of its collected <see cref="Highworm.Displays.View"/>s.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T Synchronize<T>(this T display) where T : Display {
            display.Views.ForEach(n => { n.ViewRefresh = display.Refresh; }); return display;
        }

        /// <summary>
        /// Increment the refresh value of a <see cref="Highworm.Displays.Display"/>
        /// without synchronizing its collected <see cref="Highworm.Displays.View"/>s.
        /// </summary>
        /// <typeparam name="T">A type that inherits from <see cref="Highworm.Displays.Display"/>.</typeparam>
        /// <param name="display">The display to add views to.</param>
        /// <returns>
        /// Returns the <see cref="Highworm.Displays.Display"/> for method chaining.
        /// </returns>
        public static T Increment<T>(this T display) where T : Display {
            display.Refresh++; return display;
        }
    }
}