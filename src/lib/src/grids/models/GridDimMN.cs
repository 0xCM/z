//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypeNats;

    /// <summary>
    /// Defines a rectangular dimension
    /// </summary>
    /// <typeparam name="M">The type of the first dimension</typeparam>
    /// <typeparam name="N">The type of the second dimension</typeparam>
    public readonly struct GridDim<M,N> : IDim2, IDim<M,N>
        where M : unmanaged, ITypeNat
        where N : unmanaged, ITypeNat
    {
        /// <summary>
        /// Specifies the first component of the dimension
        /// </summary>
        public ulong I
            => value<M>();

        /// <summary>
        /// Specifies the second component of the dimension
        /// </summary>
        public ulong J
            => value<N>();

        /// <summary>
        /// The volume bound by the rectangle defined by the two axes
        /// </summary>
        public ulong Volume
            => NatCalc.mul<M,N>();

        /// <summary>
        /// Returns the axis corresponding to its 0-based index
        /// </summary>
        public ulong this[int axis]
        {
            [MethodImpl(Inline)]
            get => axis == 0 ? I  :  axis == 1 ? J :  0;
        }

        /// <summary>
        /// The axis count - 2
        /// </summary>
        public int Order
        {
            [MethodImpl(Inline)]
            get => 2;
        }

        public string Format()
            => $"{I}×{J}";

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => HashCode.Combine(I,J);

        public bool Equals(GridDim<M,N> y)
            => this.I == y.I && this.J == y.J;

        public override bool Equals(object y)
            => y is GridDim<M,N> d && Equals(d);

        [MethodImpl(Inline)]
        public static implicit operator Pair<ulong>(GridDim<M,N> x)
            => (TypeNats.value<M>(), TypeNats.value<N>());

        [MethodImpl(Inline)]
        public static implicit operator Dim2<byte>(GridDim<M,N> src)
            => new Dim2<byte>((byte)src.I, (byte)src.J);

        [MethodImpl(Inline)]
        public static implicit operator Dim2<ushort>(GridDim<M,N> src)
            => new Dim2<ushort>((ushort)src.I, (ushort)src.J);

        [MethodImpl(Inline)]
        public static implicit operator Dim2<uint>(GridDim<M,N> src)
            => new Dim2<uint>((uint)src.I, (uint)src.J);

        [MethodImpl(Inline)]
        public static implicit operator Dim2<ulong>(GridDim<M,N> src)
            => new Dim2<ulong>(src.I, src.J);
    }
}