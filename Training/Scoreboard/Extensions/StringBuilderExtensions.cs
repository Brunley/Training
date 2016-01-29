﻿using System;
using System.Linq;

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Text {
    public static class StringBuilderExtensions {
        /// <summary>
        /// Write the <see cref="System.Text.StringBuilder"/> to the <see cref="System.Console"/>.
        /// </summary>
        /// <param name="source">
        /// The <see cref="System.Text.StringBuilder"/> to write.
        /// </param>
        public static StringBuilder Write(this StringBuilder source) {
            Console.Write(source); return source;
        }

        /// <summary>
        /// Take a step before another operation
        /// </summary>
        /// <param name="source">
        /// The <see cref="System.Text.StringBuilder"/>.
        /// </param>
        /// <returns></returns>
        public static StringBuilder Then(this StringBuilder source) {
            return source;
        }

        /// <summary>
        /// Reads the console input and performs an anonymous method with it.
        /// </summary>
        /// <param name="source">
        /// The <see cref="System.Text.StringBuilder"/>.
        /// </param>
        /// <param name="input">
        /// The input from <see cref="System.Console.ReadLine()"/>.
        /// </param>
        /// <returns></returns>
        public static StringBuilder Read(this StringBuilder source, Action<string> input) {
            // invoke the given accepting action on the read line
            input(Console.ReadLine());
            // run the given input expression
            return source;
        }
    }
}