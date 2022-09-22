//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct BitsF64
    {
        public const ulong SignMask = 0x7fffffffffffffff;

        [FieldOffset(0)]
        public double Data;

        [FieldOffset(0)]
        public ulong Bits;

        [MethodImpl(Inline)]
        internal BitsF64(double src)
            : this()
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ulong(BitsF64 src)
            => src.Bits;
    }
}