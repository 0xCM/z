//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        /// <summary>
        /// Emits an information-level message with a magenta foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void magenta(object content)
            => T.WriteMessage(AppMsg.colorize(content?.ToString() ?? string.Empty, FlairKind.Running));

        /// <summary>
        /// Emits an information-level message with a magenta foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void magenta(string title, object content)
            => T.WriteMessage(AppMsg.colorize( $"{title}: " + content?.ToString() ?? string.Empty, FlairKind.Running));

        /// <summary>
        /// Emits an information-level message with a magenta foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void green(object content)
            => T.WriteMessage(AppMsg.colorize(content?.ToString() ?? string.Empty, FlairKind.Status));

        /// <summary>
        /// Emits an information-level message with a magenta foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void green(string title, object content)
            => T.WriteMessage(AppMsg.colorize( $"{title}: " + content?.ToString() ?? string.Empty, FlairKind.Status));

        /// <summary>
        /// Emits an information-level message with a cyan foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void cyan(object content)
            => T.WriteMessage(AppMsg.colorize(content?.ToString() ?? string.Empty, FlairKind.Ran));

        /// <summary>
        /// Emits an information-level message with a cyan foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void cyan(string title, object content)
            => T.WriteMessage(AppMsg.colorize( $"{title}: " + content?.ToString() ?? string.Empty, FlairKind.Ran));

        /// <summary>
        /// Emits an information-level message with a red foreground, typically used to emit error messages
        /// at the point of occurrence, not at the point at which they are handled
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void red(object content)
            => T.WriteMessage(AppMsg.colorize(content?.ToString() ?? string.Empty, FlairKind.Error));

        /// <summary>
        /// Emits an information-level message with a red foreground, typically used to emit error messages
        /// at the point of occurrence, not at the point at which they are handled
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void red(string title, object content)
            => T.WriteMessage(AppMsg.colorize( $"{title}: " + content?.ToString() ?? string.Empty, FlairKind.Error));

        /// <summary>
        /// Emits an information-level message with a yellow foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void yellow(object content)
            => T.WriteMessage(AppMsg.colorize(content?.ToString() ?? string.Empty, FlairKind.Warning));

        /// <summary>
        /// Emits an information-level message with a yellow foreground
        /// </summary>
        /// <param name="content">The message to emit</param>
        /// <param name="caller">The calling member</param>
        public static void yellow(string title, object content)
            => T.WriteMessage(AppMsg.colorize( $"{title}: " + content?.ToString() ?? string.Empty, FlairKind.Warning));
    }
}