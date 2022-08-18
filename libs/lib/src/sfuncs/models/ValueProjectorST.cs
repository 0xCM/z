//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct SFx
    {
        public readonly struct ValueProjector<S,T> : IValueProjector<S,T>
            where S : struct
            where T : struct
        {
            internal readonly ValueMap<S,T> Delegate;

            [MethodImpl(Inline)]
            public ValueProjector(ValueMap<S,T> f)
                => Delegate = f;

            [MethodImpl(Inline)]
            public T map(object src)
                => Delegate(unbox<S>(src));

            [MethodImpl(Inline)]
            public T map(ValueType src)
                => Delegate(unbox<S>(src));

            [MethodImpl(Inline)]
            public ref T Project(in S src)
                => ref Delegate(src);

            ValueType IValueProjector.Project(ValueType src)
                => map(src);

            [MethodImpl(Inline)]
            public static implicit operator ValueMap<S,T>(ValueProjector<S,T> src)
                => src.Delegate;
        }
    }
}