//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        /// <summary>
        /// Determines whether some line of a text file contains a specified substring
        /// </summary>
        /// <param name="file">The source file</param>
        /// <param name="match">The substring to match</param>
        /// <param name="lineNumber">The line number of the first match, if found</param>
        [Op]
        public static bool Contains(this FilePath file, string match, out uint lineNumber)
        {
            lineNumber = 0u;
            using var reader = file.Utf8Reader();
            while(!reader.EndOfStream)
            {
                var lineText = reader.ReadLine();
                lineNumber++;
                if(lineText.Contains(match))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether some line of a text file satisfies a specified predicate
        /// </summary>
        /// <param name="file">The source file</param>
        /// <param name="predicate">The adjudicating predicate</param>
        /// <param name="lineNumber">The line number of the first match, if found</param>
        [Op]
        public static bool Contains(this FilePath file, Func<string,bool> predicate, out uint lineNumber)
        {
            lineNumber = 0u;
            using var reader = file.Utf8Reader();
            while(!reader.EndOfStream)
            {
                var lineText = reader.ReadLine();
                lineNumber++;
                if(predicate(lineText))
                    return true;
            }
            return false;
        }
    }
}