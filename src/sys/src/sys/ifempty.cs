//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Returns the replacement text if the source text is blank := {null | empty}
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="replace">The replacement value if blank</param>
        [MethodImpl(Inline), Op]
        public static string ifempty(string src, string replace)
            => empty(src) ? replace ?? EmptyString : src;

        [MethodImpl(Inline)]
        public static T ifempty<T>(T src, T replace)
            where T : INullity
                =>  src.IsEmpty ? replace : src;

        [MethodImpl(Inline)]
        public static T ifempty<T>(T src, Func<T> replace)
            where T : INullity
                =>  src.IsEmpty ? replace() : src;            
    }
}