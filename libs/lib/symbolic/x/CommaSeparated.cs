//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this short src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this ushort src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this int src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this uint src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this long src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this ulong src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this float src)
            => src.ToString("#,#");

        /// <summary>
        /// Formamats a number with comma separators
        /// </summary>
        /// <param name="src">The source number</param>
        [TextUtility]
        public static string CommaSeparated(this double src)
            => src.ToString("#,#");
    }
}