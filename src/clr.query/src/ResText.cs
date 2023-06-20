//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   using api = TextAssets;

    public readonly record struct ResText
    {   
        public readonly MemoryString Address;

        [MethodImpl(Inline)]
        public ResText(MemoryString src)
        {
            Address = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Address.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(ResText src)
            => Address.Equals(src.Address);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ResText(ReadOnlySpan<char> src)
            => api.restext(src);

        [MethodImpl(Inline)]
        public static implicit operator ResText(string src)
            => api.restext(src);
    }
}