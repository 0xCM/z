//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        /// <summary>
        /// Infers bitfield segment widths from an enum
        /// </summary>
        /// <typeparam name="W">The defining denum</typeparam>
        public static Index<byte> widths<W>()
            where W : unmanaged, Enum
                => Symbols.index<W>().Kinds.Map(x => bw8(x));
    }
}