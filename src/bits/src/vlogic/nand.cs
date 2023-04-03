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
        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static void nand<T>(in T A, in T B, ref T Z)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.nand(u8(A), u8(B), ref u8(Z));
            else if(typeof(T) == typeof(ushort))
                nand(w, A, B, ref Z);
            else if(typeof(T) == typeof(uint))
                nand(w, 4, 8, A, B, ref Z);
            else if(typeof(T) == typeof(ulong))
                nand(w, 16, 4, A, B, ref Z);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static Vector128<T> vnand<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vnand(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static Vector256<T> vnand<T>(N256 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vnand(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static void nand<T>(W128 w, in T a, in T b, ref T z)
            where T : unmanaged
                => vstore(vnand(w, a, b), ref z);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static void nand<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T z)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                nand(w, skip(a, offset), skip(b, offset), ref seek(z, offset));
        }

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static void nand<T>(W256 n, in T a, in T b, ref T z)
            where T : unmanaged
                => vstore(vnand(n, a, b), ref z);

        [MethodImpl(Inline), Nand, Closures(Closure)]
        public static void nand<T>(W256 w, int vcount, int blocklen, in T a, in T b, ref T z)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i<vcount; i++, offset += blocklen)
                nand(w, skip(a, offset), skip(b, offset), ref seek(z, offset));
        }
    }
}