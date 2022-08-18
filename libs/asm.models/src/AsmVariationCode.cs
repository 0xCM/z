//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly record struct AsmVariationCode : IDataType<AsmVariationCode>
    {
        [Parser]
        public static Outcome parse(string src, out AsmVariationCode dst)
        {
            dst = new AsmVariationCode(text.trim(src));
            return true;
        }

        public readonly asci16 Name;

        [MethodImpl(Inline)]
        public AsmVariationCode(asci16 name)
        {
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(AsmVariationCode src)
            => Name.Equals(src.Name);

        public override int GetHashCode()
            => Hash;

        public int CompareTo(AsmVariationCode src)
            => Name.CompareTo(src.Name);

        public static AsmVariationCode Empty
        {
            [MethodImpl(Inline)]
            get => new AsmVariationCode(asci16.Null);
        }
    }
}