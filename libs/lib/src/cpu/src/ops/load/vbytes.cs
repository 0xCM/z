//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct cpu
    {
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vbytes(W128 w, ulong lo)
            => Vector128.CreateScalarUnsafe(lo).As<ulong,byte>();

        [MethodImpl(Inline), Op]
        public static Vector128<byte> vbytes(W128 w, ulong lo, ulong hi)
            => Vector128.Create(lo,hi).As<ulong,byte>();

        [MethodImpl(Inline), Op]
        public static Vector256<byte> vbytes(W256 w, ulong a, ulong b, ulong c, ulong d)
            => Vector256.Create(a,b,c,d).As<ulong,byte>();
    }
}