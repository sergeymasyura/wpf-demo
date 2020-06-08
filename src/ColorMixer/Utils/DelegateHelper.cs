// Copyright 2015 Sergey Masyura. All rights reserved.

using System;

namespace ColorMixer.Utils
{
    /// <summary>
    /// Helper class to safely invoke actions.
    /// </summary>
    public static class DelegateHelper
    {
        /// <summary>
        /// Safely invokes an action with arguments.
        /// </summary>
        public static void SafeInvoke(this Action handler)
        {
            var h = handler;

            if (h != null)
            {
                h();
            }
        }

        /// <summary>
        /// Safely invokes an action with one argument.
        /// </summary>
        public static void SafeInvoke<T>(this Action<T> handler, T arg)
        {
            var h = handler;

            if (h != null)
            {
                h(arg);
            }
        }
    }
}