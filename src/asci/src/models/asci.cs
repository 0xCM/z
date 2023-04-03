//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly ref struct asci
    {        
        readonly ReadOnlySpan<AsciSymbol> Data;

        [MethodImpl(Inline)]
        public asci(ReadOnlySpan<AsciSymbol> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public asci(ReadOnlySpan<AsciCode> src)
        {
            Data = recover<AsciCode,AsciSymbol>(src);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Bytes);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => recover<AsciSymbol,byte>(Data);
        }

        public ReadOnlySpan<AsciSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => Data;
        }
    
        public ReadOnlySpan<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<AsciCode>(Bytes);
        }

        public bool IsBlank 
        {
            [MethodImpl(Inline)]
            get => SQ.whitespace(Codes);
        }
    
        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => SQ.@null(Codes);
        }


        public override int GetHashCode()
            => Hash;

        public string Format()
            => AsciSymbols.format(Codes);

        public int CompareTo(asci src)
            => AsciSymbols.cmp(Codes, src.Codes);
        
        [MethodImpl(Inline)]
        public bool Equals(asci src)
            => Bytes.SequenceEqual(src.Bytes);

        public static implicit operator asci(string src)
            => new (AsciSymbols.encode(src));

        public static implicit operator asci(Span<AsciSymbol> src)
            => new (src);

        public static asci Empty => new(sys.empty<AsciSymbol>());
    }
}