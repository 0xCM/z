//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct LiteralValue<T>
        where T : unmanaged
    {
        public readonly TypeKey Type;

        public readonly T Value;

        [MethodImpl(Inline)]
        public LiteralValue(TypeKey type, T value)
        {
            Type = type;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator LiteralValue(LiteralValue<T> src)
            => new LiteralValue(src.Type, sys.bw64(src.Value));
    }
}