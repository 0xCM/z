//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static AsciSymbols;

    using C = AsciCode;

    [ApiHost]
    public readonly partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<C> whitespace()
            => Whitespace;

        static ReadOnlySpan<C> Whitespace
            => new C[]{C.CR, C.FF, C.NL, C.Space, C.Tab, C.VTab};

        public static AsciProcessor<T> processor<T>(IWfChannel channel, uint buffer, Func<MemoryAddress,uint,T> f)
            => new AsciProcessor<T>(channel, buffer,f);

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
        public static int length(ReadOnlySpan<byte> src)
            => foundnot(search(src, z8), src.Length);

        [MethodImpl(Inline), Op]
        public static int search(in byte src, int count, byte match)
        {
            for(var i=0u; i<count; i++)
                if(skip(src,i) == match)
                    return (int)i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int search(ReadOnlySpan<byte> src, byte match)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                if(skip(src, i) == match)
                    return (int)i;
            return NotFound;
        }

        /// <summary>
        /// Transforms an uppercase character [A..Z] to the corresponding lowercase character [a..z];
        /// if the source character is not in the letter domain, the input is returned unharmed
        /// </summary>
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static char lowercase(char src)
             => letter(UpperCase, src)  ? lowercase((AsciLetterUpCode)src)  : src;

        [MethodImpl(Inline), Op]
        public static char lowercase(AsciLetterUpCode src)
            => skip(AsciSymbols.LowercaseLetters, (uint)src - (uint)AsciCodeFacets.MinUpperLetter);

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
        /// if given a lowercase character [a..z], produces the corresponding uppercase character [A..z]
        /// Otherwise, returns the input unharmed
        /// </summary>
        /// <param name="src">The source character</param>
        [MethodImpl(Inline), Op]
        public static char uppercase(char src)
             => letter(LowerCase, src) ? uppercase((AsciLetterLoCode)src) : src;

        [MethodImpl(Inline), Op]
        public static char uppercase(AsciLetterLoCode src)
            => skip(UppercaseLetters,(uint)src - (uint)AsciLetterLoCode.First);

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