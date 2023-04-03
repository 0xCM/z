//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vgcpu;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static void impl<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.impl(u8(a), in u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                impl(w, a, b, ref dst);
            else if(typeof(T) == typeof(uint))
                impl(w, 4, 8, a, b, ref dst);
            else if(typeof(T) == typeof(ulong))
                impl(w, 16, 4, a, b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static Vector128<T> vimpl<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vimpl(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static Vector256<T> vimpl<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vimpl(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static void impl<T>(W128 n, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(vimpl(n, a, b), ref dst);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static void impl<T>(W256 n, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(vimpl(n, a, b), ref dst);

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static void impl<T>(W128 n, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i<vcount; i++, offset += blocklen)
                impl(n, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), Impl, Closures(Closure)]
        public static void impl<T>(W256 n, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                impl(n, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }
    }
}