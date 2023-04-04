//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class vcpu
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 vhash<T>(Vector128<T> src)
            where T : unmanaged
        {
            var data = v64u(src);
            return sys.nhash(sys.nhash(vcell(data,0)), sys.nhash(vcell(data,1)));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 vhash<T>(Vector256<T> src)
            where T : unmanaged
                => sys.nhash(vhash(vgcpu.vlo(src)), vhash(vgcpu.vhi(src)));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Hash32 vhash<T>(Vector512<T> src)
            where T : unmanaged
                => sys.nhash(vhash(vgcpu.vlo(src)), vhash(vgcpu.vhi(src)));
    }
}