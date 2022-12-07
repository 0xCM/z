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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void select<T>(in T a, in T b, in T C, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.select(u8(a), u8(b), u8(C), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                select(w, a, b, C, ref dst);
            else if(typeof(T) == typeof(uint))
                select(w, 4, 8, a, b, C, ref dst);
            else if(typeof(T) == typeof(ulong))
                select(w, 16, 4, a, b, C, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static Vector128<T> vselect<T>(W128 n, in T a, in T b, in T c)
            where T : unmanaged
        {
            gcpu.vload(a, out Vector128<T> vA);
            gcpu.vload(b, out Vector128<T> vB);
            gcpu.vload(c, out Vector128<T> vC);
            return gcpu.vselect(vA,vB,vC);
        }

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static Vector256<T> vselect<T>(W256 n, in T a, in T b, in T c)
            where T : unmanaged
        {
            gcpu.vload(a, out Vector256<T> vA);
            gcpu.vload(b, out Vector256<T> vB);
            gcpu.vload(c, out Vector256<T> vC);
            return gcpu.vselect(vA,vB,vC);
        }

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static void select<T>(W128 n, in T a, in T b, in T c, ref T dst)
            where T : unmanaged
                => gcpu.vstore(vselect(n, a, b, c), ref dst);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static void select<T>(W256 n, in T a, in T b, in T c, ref T dst)
            where T : unmanaged
                => gcpu.vstore(vselect(n, a, b, c), ref dst);

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static void select<T>(W128 n, int vcount, int blocklen, in T a, in T b, in T c, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                select(n, skip(a, offset), skip(b, offset), skip(c, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), Select, Closures(Closure)]
        public static void select<T>(W256 n, int vcount, int blocklen, in T a, in T b, in T c, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i<vcount; i++, offset += blocklen)
                select(n, skip(a, offset), skip(b, offset), skip(c, offset), ref seek(dst, offset));
        }
    }
}