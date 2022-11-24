//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct ValueProjectorProxy<S,T> : IValueProjector<S,T>
        where S : struct
        where T : struct
    {
        readonly Func<S,T> Delegate;

        /// <summary>
        /// Captures a projected value
        /// </summary>
        readonly T[] Dst;

        [MethodImpl(Inline)]
        public ValueProjectorProxy(Func<S,T> f, T[] dst)
        {
            Delegate = f;
            Dst = dst;
        }

        [MethodImpl(Inline)]
        public ref T Project(in S src)
        {
            ref var dst = ref Dst[0];
            dst = Delegate(src);
            return ref dst;
        }

        ValueType IValueProjector.Project(ValueType src)
            => Project(unbox<S>(src));

        [MethodImpl(Inline)]
        public static implicit operator ValueMap<S,T>(ValueProjectorProxy<S,T> src)
            => src.Project;
    }

}