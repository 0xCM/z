//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmAddressLabel : IAsmSourcePart
    {
        [Parser]
        public static bool parse(string src, out AsmAddressLabel dst)
        {
            var input = text.trim(src);
            dst = AsmAddressLabel.Empty;
            var result = false;
            if(text.nonempty(input) && text.begins(input, "_@") && text.ends(input, Chars.Colon))
            {
                var i = text.index(input, Chars.At);
                var j = text.index(input, Chars.Colon);
                if(DataParser.parse(text.inside(input, i, j), out MemoryAddress address))
                {
                    dst = address;
                    result = true;
                }
            }
            return result;
        }

        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public AsmAddressLabel(MemoryAddress address)
        {
            Address = address;
        }

        public AsmCellKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmCellKind.Label;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Address == ulong.MaxValue;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => string.Format("_@{0}:", Address);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmAddressLabel(MemoryAddress src)
            => new AsmAddressLabel(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(AsmAddressLabel src)
            => src.Address;

        public static AsmAddressLabel Empty => new AsmAddressLabel(ulong.MaxValue);
    }
}