//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// If the test string is null, returns the empty string; otherwise, returns the test string
        /// </summary>
        /// <param name="src">The subject string</param>
        /// <param name="replace">The replacement value if blank</param>
        [MethodImpl(Inline), Op]
        public static string denullify(string src)
            => src ?? EmptyString;
    }
}