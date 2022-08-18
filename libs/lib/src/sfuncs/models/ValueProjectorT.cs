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
        public readonly struct ValueProjector<T> : IValueProjector<T>
            where T : struct
        {
            readonly BoxedValueMap<T> Delegate;

            [MethodImpl(Inline)]
            public ValueProjector(BoxedValueMap<T> src)
                => Delegate = src;

            internal BoxedValueMap<T> Actor
            {
                [MethodImpl(Inline)]
                get => Delegate;
            }

            [MethodImpl(Inline)]
            public ref T Project(object src)
                => ref unbox<T>(Delegate((ValueType)src));

            [MethodImpl(Inline)]
            public ref T Project(ValueType src)
                => ref unbox<T>(Delegate(src));

            ValueType IValueProjector.Project(ValueType src)
                => Delegate(src);

            [MethodImpl(Inline)]
            public static implicit operator BoxedValueMap<T>(ValueProjector<T> src)
                => src.Delegate;
        }
    }
}