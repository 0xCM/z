//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct BitPattern : IComparable<BitPattern>
    {
        public readonly asci64 Data;

        [MethodImpl(Inline)]
        public BitPattern(asci64 src)
        {
            Data = src;
        }

        public DataSize Size
        {
            [MethodImpl(Inline)]
            get => BitPatterns.size(this);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(BitPattern src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(BitPattern src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator BitPattern(string src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator BitPattern(asci64 src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator asci64(BitPattern src)
            => src.Data;
    }
}