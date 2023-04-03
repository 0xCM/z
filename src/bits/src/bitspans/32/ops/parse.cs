//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class BitSpans32
    {
        /// <summary>
        /// Creates a bitspan from text encoding of a binary number
        /// </summary>
        /// <param name="src">The bit source</param>
        [Op]
        public static BitSpan32 parse(string src)
        {
            var data = src.RemoveAny(Chars.LBracket, Chars.RBracket, Chars.Space, Chars.Underscore, (char)AsciLetterSym.b);
            var len = data.Length;
            var lastix = len - 1;
            Span<Bit32> bits = new Bit32[len];
            for(var i=0; i<= lastix; i++)
               bits[lastix - i] = data[i] == Bit32.Zero ? Bit32.Off : Bit32.On;
            return BitSpans32.load(bits);
        }
    }
}