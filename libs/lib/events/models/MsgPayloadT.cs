//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MsgPayload<T> : ITextual
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public MsgPayload(T data)
            => Data = data;

        [MethodImpl(Inline)]
        public string Format()
            => Data?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MsgPayload<T>(T src)
            => new MsgPayload<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(MsgPayload<T> src)
            => src.Data;
    }
}