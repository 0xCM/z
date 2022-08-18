//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        /// <summary>
        /// Reads a line of text from the terminal after printing a supplied message
        /// </summary>
        public static string prompt(object msg)
            => T.Prompt(msg);
    }
}