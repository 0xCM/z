//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct BitsF32
    {
        public const uint SignMask = 0x7fffffff;

        [FieldOffset(0)]
        public float Data;

        [FieldOffset(0)]
        public uint Bits;

        [MethodImpl(Inline)]
        internal BitsF32(float src)
        {
            Bits = 0;
            Data = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator uint(BitsF32 src)
            => src.Bits;
    }
}