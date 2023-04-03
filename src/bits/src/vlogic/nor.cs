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
        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static void nor<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.nor(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                nor(w, a, b, ref dst);
            else if(typeof(T) == typeof(uint))
                nor(w, 4, 8, a, b, ref dst);
            else if(typeof(T) == typeof(ulong))
                nor(w, 16, 4, a, b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static Vector128<T> vnor<T>(W128 w, in T a, in T b)
            where T : unmanaged
        {
            vgcpu.vload(in a, out Vector128<T> vA);
            vgcpu.vload(in b, out Vector128<T> vB);
            return vgcpu.vnor(vA,vB);
        }

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static Vector256<T> vnor<T>(W256 w, in T a, in T b)
            where T : unmanaged
        {
            vgcpu.vload(in a, out Vector256<T> vA);
            vgcpu.vload(in b, out Vector256<T> vB);
            return vgcpu.vnor(vA,vB);
        }

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static void nor<T>(W128 n, in T a, in T b, ref T z)
            where T : unmanaged
                => vstore(vnor(n, a, b), ref z);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static void nor<T>(W128 n, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                nor(n, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static void nor<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(vnor(w, in a, in b), ref dst);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static void nor<T>(W256 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                nor(w, in skip(in a, offset), in skip(in b, offset), ref seek(dst, offset));
        }
    }
}