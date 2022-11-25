//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Correlates a value with a key that uniquely identifies the value within some context
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Size=16), ApiComplete]
    public record struct CorrelationToken : IHashed<Hash64>
    {     
        ulong Lo;

        ulong Hi;

        [MethodImpl(Inline)]
        public CorrelationToken()
        {
            Lo = 0;
            Hi = 0;
        }

        [MethodImpl(Inline)]
        public CorrelationToken(ulong lo)
        {
            Lo = lo;
            Hi = 0;
        }

        [MethodImpl(Inline)]
        public CorrelationToken(ulong lo, ulong hi)
        {
            Lo = lo;
            Hi = hi;
        }
        
        public Hash64 Hash
        {
            [MethodImpl(Inline)]
            get => new Hash64(hash(Lo), hash(Hi));
        }

        Hash32 IHashed.Hash
        {
            [MethodImpl(Inline)]
            get => hash(Lo,Hi);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Lo == 0 && Hi == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Lo != 0 || Hi != 0;
        }

        [MethodImpl(Inline)]
        public bool Equals(CorrelationToken src)
        {
            var result = Lo == src.Lo;
            result &= Hi == src.Hi;
            return result;
        }

        [MethodImpl(Inline)]
        public int CompareTo(CorrelationToken src)
        {
            var result = Lo.CompareTo(src.Lo);
            if(result == 0)
                result = Hi.CompareTo(src.Hi);
            return result;
        }

        public string Format()
        {
            var i=0u;
            Span<char> dst = stackalloc char[32];
            var h0 = Lo.FormatHex(zpad:false,uppercase:true);
            var h1 = Hi.FormatHex(zpad:false,uppercase:true);
            var j = SE.copy(h0, ref i, dst);
            j += SE.copy(h1, ref i, dst);
            return @string(slice(dst,0,j));
        }

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => hash(Lo,Hi);

        [MethodImpl(Inline)]
        public static implicit operator CorrelationToken(ulong src)
            => new CorrelationToken(src);

        public static CorrelationToken Empty
            => default;
    }
}