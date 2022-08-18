//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Op]
        public static Sign sign(sbyte src)
            => src;

        [MethodImpl(Inline), Op]
        public static Sign sign(byte src)
            => src > 0 ? SignKind.Positive : 0;

        [MethodImpl(Inline), Op]
        public static Sign sign(short src)
            => src;
        [MethodImpl(Inline), Op]
        public static Sign sign(ushort src)
            => src > 0 ? SignKind.Positive : 0;

        [MethodImpl(Inline), Op]
        public static Sign sign(int src)
            => src;

        [MethodImpl(Inline), Op]
        public static Sign sign(uint src)
            => src > 0 ? SignKind.Positive : 0;

        [MethodImpl(Inline), Op]
        public static Sign sign(long src)
            => src;

        [MethodImpl(Inline), Op]
        public static Sign sign(ulong src)
            => src > 0 ? SignKind.Positive : 0;

        [MethodImpl(Inline), Op]
        public static Sign sign(float src)
            => (SignKind)MathF.Sign(src);

        [MethodImpl(Inline), Op]
        public static Sign sign(double src)
            => (SignKind)Math.Sign(src);
    }
}