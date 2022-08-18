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

    using W = Seg128x8;

    /// <summary>
    /// Defines a type-level representation of a <see cref='DW.W128'/> bits with <see cref='DW.W8'/> bit partition widths
    /// </summary>
    public readonly struct Seg128x8 : IVectorWidth<W>
    {
        public const DW Width = DW.W128;

        public const TSK Sign = TSK.Unsigned;

        /// <summary>
        /// An instance-level representative
        /// </summary>
        public static W W => default;

        /// <summary>
        /// The width identity
        /// </summary>
        public const string Identifier = "128x8";

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
        public bool Equals(W w)
            => true;

        [MethodImpl(Inline)]
        public string Format()
            => Identifier;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Width;

        public override bool Equals(object obj)
            => obj is W;

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
    }
}