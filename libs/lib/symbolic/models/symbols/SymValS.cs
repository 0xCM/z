//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a symbol, characterized by its value, that defines an atomic element in some vocabulary/grammar
    /// </summary>
    public readonly struct SymVal<S> : ISymVal<S>, IEquatable<SymVal<S>>
        where S : unmanaged
    {
        /// <summary>
        /// The symbol value
        /// </summary>
        public S Value {get;}

        public NumericBaseKind Base {get;}

        [MethodImpl(Inline)]
        public SymVal(S src, NumericBaseKind @base = NumericBaseKind.Base10)
        {
            Value = src;
            Base = @base;
        }

        public Identifier Name
        {
            [MethodImpl(Inline)]
            get => Value.ToString();
        }

        [MethodImpl(Inline)]
        public bool Equals(SymVal<S> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override bool Equals(object src)
            => src is SymVal<S> x && Equals(x);

        public override int GetHashCode()
            => Value.GetHashCode();

        [MethodImpl(Inline)]
        public static explicit operator char(SymVal<S> src)
            => core.@as<S,char>(src);

        [MethodImpl(Inline)]
        public static implicit operator S(SymVal<S> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S>(S src)
            => new SymVal<S>(src);

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S>((S src, NumericBaseKind nbk) x)
            => new SymVal<S>(x.src, x.nbk);

        public static SymVal<S> Empty
            => default;
    }
}