//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using DW = DataWidth;
    using TW = NativeTypeWidth;
    using FW = CpuCellWidth;
    using TSK = TypeSignKind;

    using W = W1024;

    /// <summary>
    /// Defines a type-level representation of <see cref='DW.W1024'/>
    /// </summary>
    public readonly struct W1024 : IDataWidth<W>
    {
        public const DW Width = DW.W1024;

        public const TSK Sign = TSK.Unsigned;

        /// <summary>
        /// An instance-level representative
        /// </summary>
        public static W W => default;

        /// <summary>
        /// The width identity
        /// </summary>
        public const string Identifier = "w1024";

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
        public static implicit operator W1024(N1024 src) => default(W1024);

        [MethodImpl(Inline)]
        public static implicit operator N1024(W1024 src) => default(N1024);

        [MethodImpl(Inline)]
        public bool Equals(W w)
            => true;

        public override string ToString()
            => Width.FormatValue();

        public override int GetHashCode()
            => (int)Width;

        public override bool Equals(object obj)
            => obj is W;
    }
}