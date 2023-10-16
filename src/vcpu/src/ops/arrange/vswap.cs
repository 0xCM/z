//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        // [7      6     5    4     3     2     1     0    ]
        // [15_14 13_12 11_10 09_08 07_06 05_04 03_02 01_00]
        // [2*k + 1 2*k | k=0,..,7]
        // 2 <-> 3
        // [15_14 13_12 11_10 09_08 05_04 07_06 03_02 01_00 ]
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vswap(Vector128<byte> src, uint i, uint j)
        {
            var perm = vgcpu.vinc<byte>(w128);
            perm = perm.Cell((int)j,(byte)i);
            perm = perm.Cell((int)i,(byte)j);
            return vshuffle(src,perm);
        }

        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vswap(Vector128<ushort> src, uint i, uint j)
        {
            var perm = vgcpu.vinc<byte>(w128);

            var i0 = bit.parity((uint)i, bit.Off);
            var i1 = bit.parity((uint)i, bit.On);
            var j0 = bit.parity((uint)j, bit.Off);
            var j1 = bit.parity((uint)j, bit.On);

            perm = vset(i0, j0, perm);
            perm = vset(i1, j1, perm);
            perm = vset(j0, i0, perm);
            perm = vset(j1, i1, perm);

            return v16u(vshuffle(v8u(src),perm));
        }

        [MethodImpl(Inline)]
        static Vector128<T> vset<T>(T src, byte index, Vector128<T> dst)
            where T : unmanaged
                => dst.WithElement(index, src);
    }
}