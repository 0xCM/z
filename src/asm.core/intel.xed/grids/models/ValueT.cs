//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
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
                => new Value(core.bw32(src.Storage));

            public static Value<T> Empty => default;
        }
    }
}