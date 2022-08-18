//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EnumCover<E,T> : IEnumCover<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        public E Value {get;}

        [MethodImpl(Inline)]
        public EnumCover(E value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public EnumCover(T scalar)
        {
            Value = core.@as<T,E>(scalar);
        }

        public T Scalar
        {
            [MethodImpl(Inline)]
            get => core.@as<E,T>(Value);
        }

        public string Expr
            => EnumRender<E>.Service.Format(Value);

        public string Name
            => EnumRender<E>.Service.Format(Value,true);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnumCover<E,T>(E src)
            => new EnumCover<E,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator EnumCover<E,T>(T src)
            => new EnumCover<E,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator E(EnumCover<E,T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator T(EnumCover<E,T> src)
            => src.Scalar;
    }
}