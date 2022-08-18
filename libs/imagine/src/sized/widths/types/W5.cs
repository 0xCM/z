//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 5050
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using DW = DataWidth;
    using TSK = TypeSignKind;
    using W = W5;
    using N = N5;

    /// <summary>
    /// Defines a type-level representation of <see cref='DW.W5'/>
    /// </summary>
    public readonly struct W5 : WData<W>
    {
        public const DW Width = DW.W5;

        public const TSK Sign = TSK.Unsigned;

        /// <summary>
        /// An instance-level representative
        /// </summary>
        public static W W => default;

        /// <summary>
        /// The width identity
        /// </summary>
        public const string Identifier = "w5";

        public string Id
            => Identifier;

        public DW DataWidth
            => Width;

        public TSK TypeSign
            => Sign;

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
            => obj is W;    }
}