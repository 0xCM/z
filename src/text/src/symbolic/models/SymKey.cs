//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SymKey : ISymKey<SymKey,uint>
    {
        [Parser]
        public static Outcome parse(string src, out SymKey dst)
        {
            dst = default;
            var result = NumericParser.parse(src, out uint x);
            if(result)
                dst = x;
            return result;
        }

        public uint Value {get;}

        [MethodImpl(Inline)]
        public SymKey(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public bool Equals(SymKey src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(SymKey src)
            => Value.CompareTo(src.Value);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator SymKey(uint value)
            => new SymKey(value);

        [MethodImpl(Inline)]
        public static implicit operator uint(SymKey src)
            => src.Value;
    }
}