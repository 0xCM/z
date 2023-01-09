//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines an S-symbol value covered by a T-storage cell
    /// </summary>
    public readonly struct SymVal<S,T> : ISymVal<S,T>
        where S : unmanaged
        where T : unmanaged
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

        /// <summary>
        /// The symbol value, from storage cell perspective
        /// </summary>
        public T Cell
        {
            [MethodImpl(Inline)]
            get => @as<S,T>(Value);
        }

        public SymVal<S> Simplified
        {
            [MethodImpl(Inline)]
            get => new SymVal<S>(Value);
        }

        public Type ValueType
            => typeof(S);

        public Type CellType
            => typeof(T);

        [MethodImpl(Inline)]
        public static explicit operator char(SymVal<S,T> src)
            => @as<S,char>(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator S(SymVal<S,T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator SymVal<S>(SymVal<S,T> src)
            => new SymVal<S>(src.Value, src.Base);
    }
}