//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    partial class BitVectors
    {
        /// <summary>
        /// Assumes that
        /// 1. The source vector is a symbol tape upon which fixed-width symbols are sequentially recorded
        /// 2. The symbol alphabet is defined by the last character of the literals defined by an enumeration
        /// With these preconditions, the operation returns the ordered sequence of symbols written to the tape
        /// </summary>
        /// <param name="src">The source bitvector</param>
        /// <param name="segwidth">The number of bits designated to represent/define a symbol value</param>
        /// <param name="maxbits">The maximum number bits to use if less than the bit width of the vector</param>
        /// <typeparam name="E">The enumeration type that defines the symbols</typeparam>
        /// <typeparam name="T">The primal bitvector cell type</typeparam>
        public static ReadOnlySpan<char> symbols<E,T>(ScalarBits<T> src, byte segwidth, int? maxbits = null)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var index = ClrEnums.dictionary<E,T>();
            var bitcount = maxbits ?? core.width<T>();
            var count = CellCalcs.mincells((ulong)segwidth, (ulong)bitcount);
            Span<char> symbols = new char[count];
            for(int i=0, bitpos = 0; i<count; i++, bitpos += segwidth)
            {
                var value = index[src[(byte)bitpos, (byte)(bitpos + segwidth - 1)]];
                symbols[i] = value.ToString().Last();
            }
            return symbols;
        }
    }
}