//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    [ApiHost]
    public readonly partial struct Asci
    {        
        [MethodImpl(Inline), Op]
        public static unsafe void copy<A>(ReadOnlySpan<A> src, Span<byte> dst)
            where A : unmanaged, IByteSeq
        {
            for(var i=0u; i<src.Length; i++)
                copy(skip(src,i), ref seek(dst,i*64));
        }

        [MethodImpl(Inline)]
        public static void copy<A>(in A src, ref byte dst)
            where A : unmanaged, IByteSeq
                => copy(n2, src, ref dst);

        public static Outcome parse<S,N>(string src, N n, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
        {
            var result = Outcome.Success;
            dst = new();
            var input = text.ifempty(src, EmptyString);
            if(input.Length > (int)n.NatValue)
                result = (false, "Capacity exceeded");
            else
                encode<S,N>(src, out dst);
            return result;
        }

        public static void encode<S,N>(string src, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
        {
            dst = new();
            if(typeof(N) == typeof(N2))
                dst = @as<asci2,S>((asci2)src);
            else if(typeof(N) == typeof(N4))
                dst = @as<asci4,S>((asci4)src);
            else if(typeof(N) == typeof(N8))
                dst = @as<asci8,S>((asci8)src);
            else if(typeof(N) == typeof(N16))
                dst = @as<asci16,S>((asci16)src);
            else if(typeof(N) == typeof(N32))
                dst = @as<asci32,S>((asci32)src);
            else if(typeof(N) == typeof(N64))
                dst = @as<asci64,S>((asci64)src);
            else
                throw no<S>();
        }

        [MethodImpl(Inline)]
        static void copy<A>(N2 n, in A src, ref byte dst)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci2))
                copy(cast(n2, src), ref dst);
            else if(typeof(A) == typeof(asci4))
                copy(cast(n4, src), ref dst);
            else if(typeof(A) == typeof(asci8))
                copy(cast(n8, src), ref dst);
            else if(typeof(A) == typeof(asci16))
                copy(cast(n16, src), ref dst);
            else
                copy(n32, src, ref dst);
        }

        [MethodImpl(Inline)]
        static void copy<A>(N32 n, in A src, ref byte dst)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci32))
                copy(cast(n32, src), ref dst);
            else if(typeof(A) == typeof(asci64))
                copy(cast(n64, src), ref dst);
            else
                throw no<A>();
        }

        [MethodImpl(Inline)]
        public static ReadOnlySpan<char> chars<A>(in A src)
            where A : unmanaged, IByteSeq
                => chars(n2, src);

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars<A>(N2 n, in A src)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci2))
                return decode(cast(n2,src));
            else if(typeof(A) == typeof(asci4))
                return Asci.decode(cast(n4,src));
            else if(typeof(A) == typeof(asci8))
                return decode(cast(n8,src));
            else if(typeof(A) == typeof(asci16))
                return decode(cast(n16,src));
            else
                return chars(n32, src);
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars<A>(N32 n, in A src)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci32))
                return decode(cast(n32,src));
            else if(typeof(A) == typeof(asci64))
                return decode(cast(n64,src));
            else
                return ReadOnlySpan<char>.Empty;
        }        

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> whitespace()
            => Whitespace;

        static ReadOnlySpan<C> Whitespace
            => new C[]{C.CR, C.FF, C.NL, C.Space, C.Tab, C.VTab};

        [MethodImpl(Inline), Op]
        static uint available(ReadOnlySpan<byte> src)
        {
            var present = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(skip(src,i) != 0)
                    present++;
                else
                    break;
            }
            return present;
        }

        [MethodImpl(Inline), Op]
        public static ByteSize unpack(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = src.Length;
            var j=0u;
            for(var i=0u; i<count; i++, j+=2)
                seek(dst,j) = (byte)skip(src,i);
            return count;
        }

        /// <summary>
        /// Tests whether a byte represents corresponds to an valid asci character
        /// </summary>
        /// <param name="src">The data to test</param>
        [MethodImpl(Inline), Op]
        public static bool valid(byte src)
            => src <= AsciCodeFacets.MaxCodeValue;

        /// <summary>
        /// Tests whether a byte represents corresponds to an invalid asci character
        /// </summary>
        /// <param name="src">The data to test</param>
        [MethodImpl(Inline), Op]
        public static bool invalid(byte src)
            => !valid(src);

        /// <summary>
        /// Tests whether a character is an uppercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(UpperCased @case, char c)
            => (C)c >= AsciCodeFacets.MinUpperLetter && (C)c <= AsciCodeFacets.MaxUpperLetter;

        /// <summary>
        /// Tests whether a character is a lowercase asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(LowerCased @case, char c)
            => (C)c >= AsciCodeFacets.MinLowerLetter && (C)c <= AsciCodeFacets.MaxLowerLetter;

        /// <summary>
        /// Tests whether a character is an asci letter character
        /// </summary>
        /// <param name="c">The character to test</param>
        [MethodImpl(Inline), Op]
        public static bool letter(char c)
            => letter(UpperCase, c) || letter(LowerCase, c);

        /// <summary>
        /// Presents the input  as a byte
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in AsciCode src)
            => ref @as<AsciCode,byte>(src);

        [MethodImpl(Inline), Op]
        public static char @char(byte src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char @char(AsciSymbol src)
            => (char)src;

        /// <summary>
        /// Returns the asci characters corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(sbyte offset, sbyte count)
            => slice(recover<char>(AsciChars.CharBytes), offset, count);

        public static AsciNull Null
            => default;
    }
}