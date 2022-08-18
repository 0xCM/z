//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using A = MemoryAddress;

    partial class XTend
    {
        public static Address32 Lo(this MemoryAddress src)
            => (uint)src.Location;

        public static Address32 Hi(this MemoryAddress src)
            => (uint)(src.Location >> 32);

        [MethodImpl(Inline)]
        public static Address16 Quadrant(this MemoryAddress src, N0 n)
            => src.Lo().Lo;

        [MethodImpl(Inline)]
        public static Address16 Quadrant(this MemoryAddress src, N1 n)
            => src.Lo().Hi;

        [MethodImpl(Inline)]
        public static Address16 Quadrant(this MemoryAddress src, N2 n)
            => src.Hi().Lo;

        [MethodImpl(Inline)]
        public static Address16 Quadrant(this MemoryAddress src, N3 n)
            => src.Hi().Hi;
    }


}