//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static PolyBits;

    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct BfSegExpr
    {
        public readonly Char5Seq SegName;

        public readonly BfInterval SegBits;

        [MethodImpl(Inline)]
        public BfSegExpr(Char5Seq name, BfInterval bits)
        {
            SegName = name;
            SegBits = bits;
        }

        public uint MinPos
        {
            [MethodImpl(Inline)]
            get => SegBits.Offset;
        }

        public uint MaxPos
        {
            [MethodImpl(Inline)]
            get => SegBits.MaxPos;
        }

        public byte SegWidth
        {
            [MethodImpl(Inline)]
            get => SegBits.Width;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => SegName.Hash | SegBits.Hash;
        }

        [MethodImpl(Inline)]
        public bool Equals(BfSegExpr src)
            => SegBits == src.SegBits && SegName == src.SegName;

        public override int GetHashCode()
            => Hash;

        public string Format()
            => PbRender.format(this);

        public override string ToString()
            => Format();
    }
}