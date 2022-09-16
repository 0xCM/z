//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines an S-symbol value, of bit-width N, covered by a T-storage cell
    /// </summary>
    public readonly struct SymVal<B,S,T,N> : ISymbol<SymVal<B,S,T,N>,B,S,T,N>
        where B : unmanaged, INumericBase
        where S : unmanaged
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        /// <summary>
        /// The symbol value
        /// </summary>
        public readonly S Value;

        public B Base => default;

        [MethodImpl(Inline)]
        public SymVal(S src)
        {
            Value = src;
        }

        public Identifier Name
        {
            [MethodImpl(Inline)]
            get => Value.ToString();
        }

        public SymVal<S> Simplified
        {
            [MethodImpl(Inline)]
            get => new SymVal<S>(Value);
        }

        /// <summary>
        /// The symbol value, from storage cell perspective
        /// </summary>
        public T Cell
        {
            [MethodImpl(Inline)]
            get => @as<S,T>(edit(Value));
        }

        public char Char
        {
            [MethodImpl(Inline)]
            get => (char)bw16(Value);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Char.ToString();

        public override string ToString()
            => Format();

        /// <summary>
        /// The bit-width of a symbol
        /// </summary>
        public static ushort SymWidth
        {
            [MethodImpl(Inline)]
            get => (ushort)nat64u<N>();
        }

        /// <summary>
        /// The bit-width of a storage cell
        /// </summary>
        public static ushort SegWidth
        {
            [MethodImpl(Inline)]
            get => (ushort)width<T>();
        }

        /// <summary>
        /// The maximum number of symbols that can be packed into a storage cell
        /// </summary>
        public static ushort Capacity
        {
            [MethodImpl(Inline)]
            get => (ushort)(SegWidth/SymWidth);
        }

        NumericBaseKind ISymVal.Base
            => Base.Kind;

        S ISymVal<S>.Value
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator SymVal<B,S,T,N>(S src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator SymVal<B,S,T,N>(char src)
            => new (@as<char,S>(src));

        [MethodImpl(Inline)]
        public static explicit operator SymVal<B,S,T,N>(ushort src)
            => new (@as<ushort,S>(src));

        [MethodImpl(Inline)]
        public static explicit operator SymVal<B,S,T,N>(byte src)
            => (char)src;

        [MethodImpl(Inline)]
        public static explicit operator byte(SymVal<B,S,T,N> src)
            => (byte)((char)src);

        [MethodImpl(Inline)]
        public static implicit operator char(SymVal<B,S,T,N> src)
            => src.Char;

        [MethodImpl(Inline)]
        public static implicit operator S(SymVal<B,S,T,N> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S>(SymVal<B,S,T,N> src)
            => new SymVal<S>(src.Value, src.Base.Kind);

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S,T>(SymVal<B,S,T,N> src)
            => new SymVal<S,T>(src.Value, src.Base.Kind);
    }
}