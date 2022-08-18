//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void xnor<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.xnor(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                xnor(w, a, b, ref dst);
            else if(typeof(T) == typeof(uint))
                xnor(w, 4, 8, a, b, ref dst);
            else if(typeof(T) == typeof(ulong))
                xnor(w, 16, 4, a, b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static Vector128<T> vxnor<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vxnor(gcpu.vload(w, a), gcpu.vload(w, b));

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static Vector256<T> vxnor<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vxnor(gcpu.vload(w, a), gcpu.vload(w, in b));

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static void xnor<T>(W128 n, in T a, in T b, ref T z)
            where T : unmanaged
                => gcpu.vstore(vxnor(n, a, b), ref z);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static void xnor<T>(W256 n, in T a, in T b, ref T z)
            where T : unmanaged
                => gcpu.vstore(vxnor(n, a, b), ref z);

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static void xnor<T>(W128 n, int vcount, int blocklen, in T a, in T b, ref T z)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                xnor(n, in skip(in a, offset), in skip(in b, offset), ref seek(z, offset));
        }

        [MethodImpl(Inline), Xnor, Closures(Closure)]
        public static void xnor<T>(W256 n, int vcount, int blocklen, in T a, in T b, ref T z)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                xnor(n, in skip(in a, offset), in skip(in b, offset), ref seek(z, offset));
        }
    }
}