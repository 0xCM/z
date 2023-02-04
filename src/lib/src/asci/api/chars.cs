//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [MethodImpl(Inline)]
        public static ReadOnlySpan<char> chars<A>(in A src)
            where A : unmanaged, IByteSeq
                => chars(n2, src);

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars<A>(N2 n, in A src)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci2))
                return Asci.decode(cast(n2,src));
            else if(typeof(A) == typeof(asci4))
                return Asci.decode(cast(n4,src));
            else if(typeof(A) == typeof(asci8))
                return Asci.decode(cast(n8,src));
            else if(typeof(A) == typeof(asci16))
                return Asci.decode(cast(n16,src));
            else
                return chars(n32, src);
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars<A>(N32 n, in A src)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci32))
                return Asci.decode(cast(n32,src));
            else if(typeof(A) == typeof(asci64))
                return Asci.decode(cast(n64,src));
            else
                return ReadOnlySpan<char>.Empty;
        }
    }
}