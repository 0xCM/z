//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using BL = ByteLogic;

    partial class vlogic
    {
        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static void xor<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.xor(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                xor(w, in a, in b, ref dst);
            else if(typeof(T) == typeof(uint))
                xor(w, 4, 8, in a, in b, ref dst);
            else if(typeof(T) == typeof(ulong))
                xor(w, 16, 4, in a, in b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static Vector128<T> vxor<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vxor(gcpu.vload(w, in a), gcpu.vload(w, in b));

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static Vector256<T> vxor<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => gcpu.vxor(gcpu.vload(w, in a), gcpu.vload(w, in b));

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static void xor<T>(W128 n, in T a, in T b, ref T z)
            where T : unmanaged
                => gcpu.vstore(vxor(n, in a, in b), ref z);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static void xor<T>(W128 n, int vcount, int blocklen, in T a, in T b, ref T z)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                xor(n, in skip(in a, offset), in skip(in b, offset), ref seek(z, offset));
        }

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static void xor<T>(W256 n, in T a, in T b, ref T z)
            where T : unmanaged
                => gcpu.vstore(vxor(n, in a, in b), ref z);

        [MethodImpl(Inline), Xor, Closures(Closure)]
        public static void xor<T>(W256 n, int vcount, int blocklen, in T a, in T b, ref T z)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                xor(n, in skip(in a, offset), in skip(in b, offset), ref seek(z, offset));
        }
    }
}