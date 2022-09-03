//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cells
    {
        [MethodImpl(Inline), Op]
        public static Cell16 join(byte a0, byte a1)
            => (a0, a1);

        [MethodImpl(Inline), Op]
        public static Cell32 join(byte a0, byte a1, byte a2, byte a3)
            => (join(a0,a1), join(a2,a3));

        [MethodImpl(Inline), Op]
        public static Cell32 join(ushort a0, ushort a1)
            => (a0, a1);

        [MethodImpl(Inline), Op]
        public static Cell64 join(ushort a0, ushort a1, ushort a2, ushort a3)
            => (join(a0,a1), join(a2,a3));

        [MethodImpl(Inline), Op]
        public static Cell64 join(uint a0, uint a1)
            => (a0, a1);

        [MethodImpl(Inline), Op]
        public static Cell128 join(uint a0, uint a1, uint a2, uint a3)
            => (join(a0,a1), join(a2,a3));

        [MethodImpl(Inline), Op]
        public static Cell128 join(ulong lo, ulong hi)
            => (lo, hi);

        [MethodImpl(Inline), Op]
        public static Cell256 join(ulong a0, ulong a1, ulong a2, ulong a3)
            => (join(a0,a1), join(a2,a3));

        [MethodImpl(Inline), Op]
        public static Cell256 join(Cell128 lo, Cell128 hi)
            => (lo, hi);

        [MethodImpl(Inline), Op]
        public static Cell512 join(Cell128 a0, Cell128 a1, Cell128 a2, Cell128 a3)
            => (join(a0,a1), join(a2,a3));

        [MethodImpl(Inline), Op]
        public static Cell512 join(Cell256 lo, Cell256 hi)
            => (lo, hi);
    }
}