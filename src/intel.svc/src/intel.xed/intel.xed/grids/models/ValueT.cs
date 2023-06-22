//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        public readonly record struct Value<T> : IValue<T>
            where T : unmanaged
        {
            public readonly T Storage;

            [MethodImpl(Inline)]
            public Value(T data)
            {
                Storage = data;
            }

            T IValue<T>.Value
                => Storage;

            [MethodImpl(Inline)]
            public static implicit operator Value(Value<T> src)
                => new Value(sys.bw32(src.Storage));

            public static Value<T> Empty => default;
        }
    }
}