//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static BitMaskLiterals;

    partial class Cells
    {
        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N1 n)
            => new Cell8(uint8(src.Content & Lo8x1));

        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N2 n)
            => new Cell8(uint8(src.Content & Lo8x2));

        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N3 n)
            => new Cell8(uint8(src.Content & Lo8x3));

        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N4 n)
            => new Cell8(uint8(src.Content & Lo8x4));

        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N5 n)
            => new Cell8(uint8(src.Content & Lo8x5));

        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N6 n)
            => new Cell8(uint8(src.Content & Lo8x6));

        [MethodImpl(Inline), Op]
        public static Cell8 trim(Cell8 src, N7 n)
            => new Cell8(uint8(src.Content & Lo8x7));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N1 n)
            => new Cell16(uint16(src.Content & Lo16x1));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N2 n)
            => new Cell16(uint16(src.Content & Lo16x2));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N3 n)
            => new Cell16(uint16(src.Content & Lo16x3));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N4 n)
            => new Cell16(uint16(src.Content & Lo16x4));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N5 n)
            => new Cell16(uint16(src.Content & Lo16x5));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N6 n)
            => new Cell16(uint16(src.Content & Lo16x6));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N7 n)
            => new Cell16(uint16(src.Content & Lo16x7));

        [MethodImpl(Inline), Op]
        public static Cell16 trim(Cell16 src, N8 n)
            => new Cell16(uint16(src.Content & Lo16x8));
    }
}