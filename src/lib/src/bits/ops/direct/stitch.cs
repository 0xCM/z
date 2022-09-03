//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        [MethodImpl(Inline), Stitch]
        public static byte stitch(byte left, int ldx, byte right, int rdx)
        {
            var a = (uint)left << ldx;
            var b = (uint)right >> rdx;
            return (byte)((a | b) >> rdx);
        }

        [MethodImpl(Inline), Stitch]
        public static ushort stitch(ushort left, int ldx, ushort right, int rdx)
        {
            var a = (uint)left << ldx;
            var b = (uint)right >> rdx;
            return (ushort)((a | b) >> rdx);
        }

        [MethodImpl(Inline), Stitch]
        public static uint stitch(uint left, int ldx, uint right, int rdx)
        {
            var a = left << ldx;
            var b = right >> rdx;
            return (a | b) >> rdx;
        }

        [MethodImpl(Inline), Stitch]
        public static ulong stitch(ulong left, int ldx, ulong right, int rdx)
        {
            var a = left << ldx;
            var b = right >> rdx;
            return (a | b) >> rdx;
        }
    }
}