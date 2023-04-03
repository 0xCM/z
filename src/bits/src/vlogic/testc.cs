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
        public static bit testc<T>(in T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               return BL.testc(u8(a));
            else if(typeof(T) == typeof(ushort))
               return vtestc(w, a);
            else if(typeof(T) == typeof(uint))
               return testc(w, 4, 8, a);
            else if(typeof(T) == typeof(ulong))
                return testc(w, 16, 4, a);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit testc<T>(in T a, in T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               return BL.testc(in u8(a),in u8(b));
            else if(typeof(T) == typeof(ushort))
               return vtestc(w, in a,in b);
            else if(typeof(T) == typeof(uint))
               return testc(w, 4, 8, in a, in b);
            else if(typeof(T) == typeof(ulong))
                return testc(w, 16, 4, in a, in b);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit vtestc<T>(W128 w, in T a)
            where T : unmanaged
                => vgcpu.vtestc(vgcpu.vload(w, a));

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit vtestc<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vtestc(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit vtestc<T>(W256 w, in T a)
            where T : unmanaged
                => vgcpu.vtestc(vgcpu.vload(w, a));

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit vtestc<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vtestc(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(W128 n, int vcount, int blocklen, in T a)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i<vcount; i++, offset+=blocklen)
                result &= vtestc(n, skip(a, offset));
            return result;
        }

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(W128 n, int vcount, int blocklen, in T a, in T b)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i<vcount; i++, offset+=blocklen)
                result &= vtestc(n, skip(a, offset), skip(b, offset));
            return result;
        }

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(W256 n, int vcount, int blocklen, in T a)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i<vcount; i++, offset+=blocklen)
                result &= vtestc(n, skip(a, offset));
            return result;
        }

        [MethodImpl(Inline), TestC, Closures(Closure)]
        public static bit testc<T>(W256 n, int vcount, int blocklen, in T a, in T b)
            where T : unmanaged
        {
            var result = bit.On;
            for(int i=0, offset = 0; i<vcount; i++, offset+=blocklen)
                result &= vtestc(n, skip(a, offset), skip(b, offset));
            return result;
        }
    }
}