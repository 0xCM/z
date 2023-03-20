//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct LiteralValue
    {
        public readonly TypeKey Type;

        public readonly ulong Value;

        [MethodImpl(Inline)]
        public LiteralValue(TypeKey type, ulong value)
        {
            Type = type;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator LiteralValue<ulong>(LiteralValue src)
            => new LiteralValue<ulong>(src.Type, src.Value);
    }
}