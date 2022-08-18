//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        /// <summary>
        /// Returns a readonly symbol span covering each <see cref='Hex2Kind'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex2Kind,byte,N2>> hexseq(N2 n)
            => Bytes.cells<SymVal<Hex2Kind,byte,N2>>(n4);

        /// <summary>
        /// Returns a readonly symbol span covering each <see cref='Hex3Kind'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex3Kind,byte,N3>> hexseq(N3 n)
            => Bytes.cells<SymVal<Hex3Kind,byte,N3>>(n8);

        /// <summary>
        /// Returns a readonly symbol span covering each <see cref='Hex4Kind'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex4Kind,byte,N4>> hexseq(N4 n)
            => Bytes.cells<SymVal<Hex4Kind,byte,N4>>(n16);

        /// <summary>
        /// Creates a store covering each <see cref='Hex5Kind'/> member
        /// </summary>
        /// <param name="n">The sequence length selector</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<SymVal<Hex5Kind,byte,N5>> hexseq(N5 n)
            => Bytes.cells<SymVal<Hex5Kind,byte,N5>>(n32);
    }
}