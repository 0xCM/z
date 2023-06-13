//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct AsciSymbols
    {        
        [MethodImpl(Inline), Op]
        public static int cmp(ReadOnlySpan<AsciCode> left, ReadOnlySpan<AsciCode> right)
        {
            var result = -1;
            var count = min(left.Length,right.Length);
            for(var i=0; i<count; i++)
            {
                var a = (char)skip(left,i);
                var b = (char)skip(right,i);
                result = a.CompareTo(b);
                if(result != 0)
                    break;
            }
            return result;
        }


        [MethodImpl(Inline), Op]
        public static int length(ReadOnlySpan<byte> src)
            => foundnot(search(src, z8), src.Length);

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