//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnumLiteralInfo<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        public readonly EcmaToken Token;

        public readonly uint Position;

        public readonly string Name;

        public readonly E Literal;

        public readonly T Scalar;

        [MethodImpl(Inline)]
        public EnumLiteralInfo(EcmaToken token, uint pos, string name, E literal, T scalar)
        {
            Token = token;
            Position = pos;
            Name = name;
            Literal = literal;
            Scalar = scalar;
        }
    }
}