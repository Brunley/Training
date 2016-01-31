using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;

namespace Highworm.Displays {
    public static partial class DisplayExtensions {
        /// <summary>
        /// Include a collection of views.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="display"></param>
        /// <param name="views"></param>
        /// <returns></returns>
        public static T IncludeViews<T>(this T display, IList<View> views) where T : Display {
            views.ForEach(view => {
                display.Views.Add(view); 
            }); return display;
        }

        /// <summary>
        /// Initialize all views in the display.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="display"></param>
        /// <returns></returns>
        public static T Initialize<T>(this T display) where T : Display {
            display.Views.ForEach(view => {
                view.Painting += display.OnPaintingView;
            }); return display;
        }

        /// <summary>
        /// Initialize the state and default state
        /// </summary>
        /// <param name="state">
        /// The state to initialize and set.
        /// </param>
        /// <returns></returns>
        public static T Initialize<T>(this T display, string state) where T : Display {
            display.State.Reset(state); return display.OnStateChange(state);
        }

        /// <summary>
        /// Simple stepping extension.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="display"></param>
        /// <returns></returns>
        public static T Then<T>(this T display) where T : Display {
            return display;
        }

        /// <summary>
        /// Repaint the screen when state changes.
        /// </summary>
        /// <param name="state"></param>
        public static T OnStateChange<T>(this T display, string state) where T : Display {
            display.Increment(); display.Paint(); return display;
        }

        /// <summary>
        /// Synchronize the view and the display passes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="display"></param>
        /// <returns></returns>
        public static T Synchronize<T>(this T display) where T : Display {
            display.Views.ForEach(n => { n.Pass = display.Pass; }); return display;
        }

        /// <summary>
        /// Increments the display refresh.
        /// </summary>
        /// <returns></returns>
        public static T Increment<T>(this T display) where T : Display {
            display.Pass++; return display;
        }
    }
}