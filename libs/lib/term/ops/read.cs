//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        /// <summary>
        /// Reads a line of text from the terminal
        /// </summary>
        public static string read()
            => T.ReadLine();

        /// <summary>
        /// Reads a character from the terminal
        /// </summary>
        public static char readKey(string content = null)
            => T.ReadKey(content != null ? AppMsg.called(content, LogLevel.Status) : null);
    }
}