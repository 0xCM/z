//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct SFx
    {
        [MethodImpl(Inline)]
        public unsafe static void map<M,T>(Span<T> src, M mapper, Span<MemoryAddress> dst)
            where T : unmanaged
            where M : IPointedMap<T,MemoryAddress>
        {
            var count = (uint)src.Length;
            fixed(T* pSrc = src)
            {
                var p = pSrc;
                for(var i=0u; i<count; i++)
                    seek(dst,i) = mapper.Map(p++);
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void locate<T>(Span<T> src, Span<MemoryAddress> dst)
            where T : unmanaged
                => map(src,new Locate<T>(), dst);


        readonly unsafe struct Locate<T> : IPointedMap<Locate<T>,T,MemoryAddress>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public MemoryAddress Map(T* pSrc)
                => pSrc;
        }

        [MethodImpl(Inline)]
        public static void map<F,T>(F f, in T src, ref T dst, int count)
            where F : IUnaryOp<T>
        {
            for(var i=0; i<count; i++)
                seek(dst, i) = f.Invoke(skip(src, i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public ref T map<T>(ValueProjector projector, object x)
            where T : struct
                => ref unbox<T>(projector.Delegate((ValueType)x));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T map<T>(ValueProjector<T> f, in T x)
            where T : struct
                => ref unbox<T>(f.Actor(x));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T map<T>(ValueProjector<T,T> f, in T x)
            where T : unmanaged
                => ref f.Delegate(x);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T map<T>(ValueProjector<T,T> f, ValueType x)
            where T : unmanaged
                => ref f.Delegate(unbox<T>(x));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T map<T>(ValueProjector<T,T> f, object x)
            where T : unmanaged
                => ref map(f,(ValueType)x);

        [MethodImpl(Inline)]
        public static ref T map<S,T>(ValueProjector<S,T> projector, in S x)
            where S : struct
            where T : struct
                => ref projector.Delegate(x);

        [MethodImpl(Inline)]
        public static ref T map<S,T>(ValueProjectorProxy<S,T> proxy, object x)
            where S : struct
            where T : struct
                => ref proxy.Project(unbox<S>(x));

        [MethodImpl(Inline)]
        public static ref T map<S,T>(ValueProjectorProxy<S,T> proxy, ValueType x)
            where S : struct
            where T : struct
                => ref proxy.Project(unbox<S>(x));
    }
}