//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        /// <summary>
        /// Writes an empty line to the console
        /// </summary>
        public static void print()
            => T.WriteLine();

        /// <summary>
        /// Writes a colorized message to the console
        /// </summary>
        /// <param name="message">The message text</param>
        /// <param name="color">The emission color</param>
        public static void print(string message, FlairKind color)
            => T.WriteLine(message, color);

        /// <summary>
        /// Writes a single messages to the terminal
        /// </summary>
        /// <param name="msg">The message to print</param>
        public static void print(IAppMsg msg)
            => T.WriteMessage(msg);

        /// <summary>
        /// Writes a single messages to the terminal
        /// </summary>
        /// <param name="msg">The message to print</param>
        public static void print(AppMsg msg)
            => T.WriteMessage(msg);

        /// <summary>
        /// Writes a single line to the terminal
        /// </summary>
        /// <param name="content">The message to print</param>
        public static void print(object content)
            => T.WriteLine(content);

        /// <summary>
        /// Writes formattables to the console in a contiguous block
        /// </summary>
        /// <param name="content">The content to print</param>
        public static void print<F>(F src)
            where F : ITextual
                => T.WriteLine(src, FlairKind.Status);

        /// <summary>
        /// Writes formattables to the console in a contiguous block
        /// </summary>
        /// <param name="content">The content to print</param>
        public static void print(IAppEvent e)
            => T.WriteLine(e.Format(), e.Flair);

        /// <summary>
        /// Writes a contiguous sequence of flaired messages
        /// </summary>
        /// <param name="src">The message sequence</param>
        public static void print(params (object content, FlairKind flair)[] src)
            => T.Write(src);
    }
}