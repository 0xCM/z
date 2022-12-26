//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        /// <summary>
        /// Writes specified content to the terminal using the current color scheme
        /// </summary>
        /// <param name="msg">The message to emit</param>
        public static void write<M>(M msg)
            => T.Write(msg);

        /// <summary>
        /// Writes specified content to the terminal using the current color scheme
        /// </summary>
        /// <param name="msg">The message to emit</param>
        /// <param name="color">The emission color</param>
        public static void write<M>(M msg, FlairKind color)
            => T.Write($"{msg}", color);
    }
}