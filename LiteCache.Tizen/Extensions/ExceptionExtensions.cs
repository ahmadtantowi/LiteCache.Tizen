﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiteCache.Tizen.Extensions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets a formatted string with the calling class name, exception message, and stack trace.
        /// </summary>
        /// <returns>The formatted debug message.</returns>
        /// <param name="ex">The <see cref="system.Exception"/>.</param>
        /// <param name="callingClass">The class in which the exception was thrown. Usually you'll use the 'this' keyword for this parameter.</param>
        public static string ToFormattedDebugMessage(this Exception ex, object callingClass)
        {
            return string.Format("EXCEPTION: {0}: {1}  |  {2}", callingClass.GetType().FullName, ex.Message, ex.StackTrace);
        }

        /// <summary>
        /// Gets a formatted string with the calling class name, exception message, and stack trace.
        /// </summary>
        /// <returns>The formatted debug message.</returns>
        /// <param name="ex">The <see cref="System.Exception"/>.</param>
        /// <param name="callingClassType">The <see cref="System.Type"/> of the calling class. Usually you'll pass 'typeof(CallingClass)' for this parameter.</param>
        public static string ToFormattedDebugMessage(this Exception ex, Type callingClassType)
        {
            return string.Format("EXCEPTION: {0}: {1}  |  {2}", callingClassType.FullName, ex.Message, ex.StackTrace);
        }

        /// <summary>
        /// Writes a formatted string to the debug output with the calling class name, exception message, and stack trace.
        /// </summary>
        /// <param name="ex">The <see cref="system.Exception"/>.</param>
        /// <param name="callingClass">The class in which the exception was thrown. Usually you'll use the 'this' keyword for this parameter.</param>
        public static void WriteFormattedMessageToDebugConsole(this Exception ex, object callingClass)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToFormattedDebugMessage(callingClass));
        }

        /// <summary>
        /// Writes a formatted string to the debug output with the calling class name, exception message, and stack trace.
        /// </summary>
        /// <param name="ex">The <see cref="System.Exception"/>.</param>
        /// <param name="callingClassType">The <see cref="System.Type"/> of the calling class. Usually you'll pass 'typeof(CallingClass)' for this parameter.</param>
        public static void WriteFormattedMessageToDebugConsole(this Exception ex, Type callingClassType)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToFormattedDebugMessage(callingClassType));
        }
    }
}
