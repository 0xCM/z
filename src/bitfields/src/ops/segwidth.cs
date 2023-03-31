//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static byte segwidth(uint i0, uint i1)
            => (byte)(i1 - i0 + 1);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte segwidth<T>(in Bitfield256<T> src, byte index)
            where T : unmanaged
                => vcpu.vcell(src.Widths, index);

        [MethodImpl(Inline)]
        public static byte segwidth<E,T>(in Bitfield256<E,T> src, E index)
            where E : unmanaged
            where T : unmanaged
                => vcpu.vcell(src.Widths, bw8(index));
    }
}