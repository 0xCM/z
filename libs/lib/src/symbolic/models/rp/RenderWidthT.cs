//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RenderWidth<T> : ITextual
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public static implicit operator RenderWidth<T>(T src)
            => new RenderWidth<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(RenderWidth<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public RenderWidth(T value)
            => Value = value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();
    }
}