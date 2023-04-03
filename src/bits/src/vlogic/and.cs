//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vgcpu;
    using static SFx;

    using BL = ByteLogic;
    using K = ApiClasses;

    partial class vlogic
    {
        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(in T a, in T b, ref T dst)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
               BL.and(u8(a), u8(b), ref u8(dst));
            else if(typeof(T) == typeof(ushort))
                and(w, in a, in b, ref dst);
            else if(typeof(T) == typeof(uint))
                and(w, 4, 8, in a, in b, ref dst);
            else if(typeof(T) == typeof(ulong))
                and(w, 16, 4, in a, in b, ref dst);
            else
                throw no<T>();
        }

        [MethodImpl(Inline), And, Closures(Closure)]
        public static Vector128<T> and<T>(W128 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vand(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), And, Closures(Closure)]
        public static Vector256<T> and<T>(W256 w, in T a, in T b)
            where T : unmanaged
                => vgcpu.vand(vgcpu.vload(w, a), vgcpu.vload(w, b));

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W128 n, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(and(n, a, b), ref dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W128 w, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i<vcount; i++, offset += blocklen)
                and(w, skip(a, offset), skip(b, offset), ref seek(dst, offset));
        }

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W256 w, in T a, in T b, ref T dst)
            where T : unmanaged
                => vstore(and(w, in a, in b), ref dst);

        [MethodImpl(Inline), And, Closures(Closure)]
        public static void and<T>(W256 n, int vcount, int blocklen, in T a, in T b, ref T dst)
            where T : unmanaged
        {
            for(int i=0, offset = 0; i < vcount; i++, offset += blocklen)
                and(n, skip(in a, offset), in skip(in b, offset), ref seek(dst, offset));
        }

        public readonly struct MultiAnd
        {
            [MethodImpl(Inline), And, Closures(Closure)]
            public static void and<T>(in T a, in T b, ref T dst)
                where T : unmanaged
            {
                if(typeof(T) == typeof(byte))
                    and(w64, default(T)).Invoke(a, b, ref dst);
                else if(typeof(T) == typeof(ushort))
                    and(w256, default(T)).Invoke(a, b, ref dst);
                else if(typeof(T) == typeof(uint))
                    and(w256, default(T)).Invoke(4, 8, a, b, ref dst);
                else if(typeof(T) == typeof(ulong))
                    and(w256, default(T)).Invoke(16, 4, a, b, ref dst);
                else
                    throw no<T>();
            }

            [MethodImpl(Inline)]
            public static And<W,T> and<W,T>(W w = default, T t = default)
                where W : unmanaged, ITypeWidth
                where T : unmanaged
                    => sfunc(w, sfunc<And<W,T>>(), t);

            public readonly struct And<W,T> : IBinarySquare<W,T>
                where W : unmanaged, ITypeWidth
                where T : unmanaged
            {
                public K.And ApiClass => default;

                [MethodImpl(Inline)]
                public void Invoke(in T a, in T b, ref T dst)
                {
                    if(typeof(W) == typeof(W64))
                        BL.and(u8(a), u8(b), ref u8(dst));
                    else if(typeof(W) == typeof(W128))
                        vlogic.and(w128, a, b, ref dst);
                    else if(typeof(W) == typeof(W256))
                        vlogic.and(w256, a, b, ref dst);
                    else
                        throw no<W>();
                }

                [MethodImpl(Inline)]
                public void Invoke(int count, int step, in T a, in T b, ref T dst)
                {
                    if(typeof(W) == typeof(W128))
                        vlogic.and(w128, count, step, a, b, ref dst);
                    else if(typeof(W) == typeof(W256))
                        vlogic.and(w256, count, step, a, b, ref dst);
                    else
                        throw no<W>();
                }
            }
        }
   }
}