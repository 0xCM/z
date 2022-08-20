//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TypeSign : ITypeSign<TypeSign>
    {
        public TypeSignKind Sign {get;}

        [MethodImpl(Inline)]
        public TypeSign(TypeSignKind kind)
            => Sign = kind;

        [MethodImpl(Inline)]
        public static implicit operator TypeSign(TypeSignKind src)
            => new TypeSign(src);

        [MethodImpl(Inline)]
        public static implicit operator TypeSignKind(TypeSign src)
            => src.Sign;
    }
}