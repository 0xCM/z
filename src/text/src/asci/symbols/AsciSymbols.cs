//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using static AsciSymbols;


    [ApiHost]
    public readonly partial struct AsciSymbols
    {        
        // [MethodImpl(Inline), Op]
        // public static ReadOnlySpan<C> whitespace()
        //     => Whitespace;

        // static ReadOnlySpan<C> Whitespace
        //     => new C[]{C.CR, C.FF, C.NL, C.Space, C.Tab, C.VTab};

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


        [MethodImpl(Inline), Op]
        public static ByteSize unpack(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = src.Length;
            var j=0u;
            for(var i=0u; i<count; i++, j+=2)
                seek(dst,j) = (byte)skip(src,i);
            return count;
        }

        [MethodImpl(Inline), Op]
        public static void store(ReadOnlySpan<byte> src, char fill, Span<char> dst)
        {
            var count = sys.length(src,dst);
            for(var i=0u; i<count; i++)
            {
                ref readonly var next = ref skip(src,i);
                seek(dst,i) = next == 0 ? fill : @char(skip(src,i));
            }
        }

        [MethodImpl(Inline), Op]
        public static int encode(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }

        /// <summary>
        /// Encodes a single character
        /// </summary>
        /// <param name="src">The character to encode</param>
        [MethodImpl(Inline), Op]
        public static AsciCode encode(char src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static int encode(ReadOnlySpan<char> src, ref byte dst)
            => encode(first(src), src.Length, ref dst);

        /// <summary>
        /// Encodes each source string and packs the result into the target
        /// </summary>
        /// <param name="src">The encoding source</param>
        /// <param name="dst">The encoding target</param>
        [MethodImpl(Inline), Op]
        public static int encode(ReadOnlySpan<string> src, Span<byte> dst)
        {
            var j = 0;
            for(var i=0u; i<src.Length; i++)
                j += AsciSymbols.encode(skip(src, i), dst.Slice(j));
            return j + 1;
        }

        /// <summary>
        /// Encodes each source string and packs the result into the target, interspersed by a supplied delimiter
        /// </summary>
        /// <param name="src">The encoding source</param>
        /// <param name="dst">The encoding target</param>
        [MethodImpl(Inline), Op]
        public static uint encode(ReadOnlySpan<string> src, Span<byte> dst, byte delimiter)
        {
            var j=0u;
            for(var i=0u; i<src.Length; i++)
            {
                j += (uint)(AsciSymbols.encode(skip(src, i), sys.slice(dst,j)));
                seek(dst, ++j) = delimiter;
            }
            return j + 1;
        }

        [MethodImpl(Inline), Op]
        public static int encode(in char src, int count, ref byte dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }

        /// <summary>
        /// Encodes a sequence of source characters and stores a result in a caller-supplied
        /// T-parametric target with cells assumed to be at least 16 bits wide
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target</param>
        /// <typeparam name="T">The target cell type</typeparam>
        [MethodImpl(Inline), Op]
        public static int encode<T>(ReadOnlySpan<char> src, Span<T> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = @as<T>((byte)skip(src,i));
            return count;
        }
         
        [MethodImpl(Inline)]
        public static bool contains<T>(in T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
        {
            var code = (byte)match;
            var count = src.Length;
            var data = sys.bytes(src);
            for(var i=0; i<count; i++)
                if(skip(data,i) == code)
                    return true;
            return false;
        }

        [MethodImpl(Inline)]
        public static int index<T>(in T src, AsciCharSym match)
            where T : unmanaged, IAsciSeq
        {
            var code = (byte)match;
            var count = src.Length;
            var data = sys.bytes(src);
            for(var i=0; i<count; i++)
                if(skip(data,i) == code)
                    return i;

            return NotFound;
        }

        [MethodImpl(Inline)]
        public static bool bitstring<S>(S src)
            where S : unmanaged, IAsciSeq<S>
        {
            var result = true;
            var counter = 0;
            var data = sys.bytes(src);
            var n = data.Length;
            for(var i=0; i<n; i++)
            {
                var b = (AsciCode)skip(data,i);
                result = (b == AsciCode.Space || b == AsciCode.d0 || b == AsciCode.d1);
                if(!result)
                    break;
            }

            return result;
        }

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciCode src)
            => src;

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciLetterLoSym src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static AsciSymbol symbol(AsciLetterUpSym src)
            => (AsciCode)src;

        [MethodImpl(Inline), Op]
        public static ref readonly AsciSymbol symbol(in byte src)
            => ref sys.view<byte,AsciSymbol>(src);        
         
        [MethodImpl(Inline), Op]
        public static string @string(sbyte offset, sbyte count)
            => text.slice(AsciCharString, offset, count);

        /// <summary>
        /// Returns the uint16 asci scalar values corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ushort> scalars(sbyte offset, sbyte count)
            => recover<char,ushort>(chars(offset,count));

        public static string AsciCharString
        {
            [Op]
            get => "00000000000000000000000000000000 !\"#$%&0()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[0]^_`abcdefghijklmnopqrstuvwxyz{|}~0";
        }

        public static string LowercaseLetterString
        {
            [Op]
            get => "abcdefghijklmnopqrstuvwxyz";
        }

        public static string UppercaseLetterString
        {
            [Op]
            get => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }

        public static ReadOnlySpan<char> LowercaseLetters
        {
            [Op]
            get => LowercaseLetterString;
        }

        public static ReadOnlySpan<char> UppercaseLetters
        {
            [Op]
            get => UppercaseLetterString;
        }

        public static string UppercaseHexString
        {
            [Op]
            get => "0123456789ABCDEF";
        }

        public static ReadOnlySpan<char> UppercaseHexDigits
        {
            [Op]
            get => UppercaseHexString;
        }
    }
}