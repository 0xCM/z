//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class TypeNats
    {
        /// <summary>
        /// Creates a sequence of primitive values from a natural value
        /// </summary>
        /// <param name="src">The source value</param>
        [Op]
        public static byte[] digits(ulong src)
        {
            var text = src.ToString();
            var chars = new byte[text.Length];
            for(var i=0; i<text.Length; i++)
                chars[i] = byte.Parse(text[i].ToString());
            return chars;
        }
    }
}