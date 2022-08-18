//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using DW = DataWidth;
    using TW = NativeTypeWidth;
    using FW = CpuCellWidth;
    using VW = NativeVectorWidth;
    using TSK = TypeSignKind;

    using W = W256;
    using N = N256;

    /// <summary>
    /// Defines a type-level representation of <see cref='DW.W256'/>
    /// </summary>
    public readonly struct W256 : IVectorWidth<W>, WType<W>
    {
        public const DW Width = DW.W256;

        public const TSK Sign = TSK.Unsigned;

        /// <summary>
        /// An instance-level representative
        /// </summary>
        public static W W => default;

        /// <summary>
        /// The width identity
        /// </summary>
        public const string Identifier = "w256";

        public string Id
            => Identifier;

        public DW DataWidth
            => Width;

        public TSK TypeSign
            => Sign;

        public FW CellWidth
            => (FW)Width;

        public TW TypeWidth
            => (TW)Width;

        public VW VectorWidth
            => (VW)Width;

        [MethodImpl(Inline)]
        public static implicit operator int(W src)
            => (int)Width;

        [MethodImpl(Inline)]
        public static implicit operator DW(W src)
            => Width;

        [MethodImpl(Inline)]
        public static implicit operator DataWidth<W>(W src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator FW(W src)
            => (FW)Width;

        [MethodImpl(Inline)]
        public static implicit operator TW(W src)
            => (TW)Width;

        [MethodImpl(Inline)]
        public static implicit operator VW(W src)
            => (VW)Width;

        [MethodImpl(Inline)]
        public static implicit operator W(N src)
            => default;

        [MethodImpl(Inline)]
        public static implicit operator N(W src)
            => default;


        [MethodImpl(Inline)]
        public bool Equals(W w)
            => true;

        [MethodImpl(Inline)]
        public string Format()
            => Width.FormatValue();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Width;

        public override bool Equals(object obj)
            => obj is W;
    }
}