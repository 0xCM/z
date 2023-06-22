//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmRegName : IDataType<AsmRegName>
    {
        readonly asci8 Data;

        [MethodImpl(Inline)]
        public AsmRegName(asci8 name)
        {
            Data = name;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(AsmRegName src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(AsmRegName src)
            => Data.Equals(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmRegName(asci8 src)
            => new AsmRegName(src);

        [MethodImpl(Inline)]
        public static implicit operator asci8(AsmRegName src)
            => src.Data;

        public static AsmRegName Empty => new AsmRegName(asci8.Null);
    }
}