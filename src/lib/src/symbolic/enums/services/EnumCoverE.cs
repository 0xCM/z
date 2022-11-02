//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnumCover<E> : IEnumCover<E>
        where E : unmanaged, Enum
    {
        public E Value {get;}

        [MethodImpl(Inline)]
        public EnumCover(E value)
        {
            Value = value;
        }

        public string Expr
            => EnumRender<E>.Service.Format(Value);

        public string Name
            => EnumRender<E>.Service.Format(Value,true);

        public ulong Scalar
        {
            [MethodImpl(Inline)]
            get => sys.bw64(Value);
        }

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public static implicit operator EnumCover<E>(E src)
            => new EnumCover<E>(src);

        public static implicit operator E(EnumCover<E> src)
            => src.Value;
    }
}