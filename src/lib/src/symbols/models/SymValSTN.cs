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
    public readonly struct SymVal<S,T,N> : ISymbol<SymVal<S,T,N>,S,T,N>
        where S : unmanaged
        where T : unmanaged
        where N : unmanaged, ITypeNat
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

        public string Format()
            => Value.ToString();

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

        [MethodImpl(Inline)]
        public static explicit operator char(SymVal<S,T,N> src)
            => @as<S,char>(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator S(SymVal<S,T,N> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S>(SymVal<S,T,N> src)
            => new SymVal<S>(src.Value, src.Base);

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S,T>(SymVal<S,T,N> src)
            => new SymVal<S,T>(src.Value, src.Base);
    }
}