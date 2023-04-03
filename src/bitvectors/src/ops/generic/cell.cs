//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cell<T>(BitVector128<T> src, byte index)
            where T : unmanaged
                => vgcpu.vcell(src.State,index);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T cell<T>(BitVector256<T> src, byte index)
            where T : unmanaged
                => vgcpu.vcell(src.State,index);
    }
}