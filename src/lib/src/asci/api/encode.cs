//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static int encode(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
            return count;
        }

        public static uint encode<T>(W8 w, N5 n, in SymExpr symbol, T kind, uint offset, Span<byte> dst)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            encode(desc, slice(dst,offset));
            return (uint)width;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly AsciSeq encode(string src, in AsciSeq dst)
        {
            encode(src, dst.Storage);
            return ref dst;
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
                j += encode(skip(src, i), dst.Slice(j));
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
                j += (uint)(encode(skip(src, i), core.slice(dst,j)));
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

        /// <summary>
        /// Encodes a 3-character asci sequence as a <see cref='asci4'/> value
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        /// <param name="c">The third asci character</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, char a, char b, char c)
            => new asci4(Asci.pack((AsciCode)a, (AsciCode)b, (AsciCode)c, out var _ ));

        /// <summary>
        /// Encodes a 4-character asci sequence as a <see cref='asci4'/> value
        /// </summary>
        /// <param name="a">The first asci character</param>
        /// <param name="b">The second asci character</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, char a, char b, char c, char d)
            => new asci4(Asci.pack((AsciCode)a, (AsciCode)b, (AsciCode)c, (AsciCode)d, out var _ ));

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(in char src, byte count, out asci4 dst)
        {
            dst = asci4.Null;
            ref var storage = ref Unsafe.As<asci4,AsciCode>(ref dst);
            codes(src, (byte)count, ref storage);
            return dst;
        }

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(ReadOnlySpan<char> src, out asci4 dst)
        {
            dst = default;
            codes(src, span<asci4,AsciCode>(ref dst));
            return dst;
        }


        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci4 encode(N4 n, ReadOnlySpan<char> src)
            => encode(src, out asci4 dst);

        /// <summary>
        /// Populates a 4-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref ByteBlock4 encode(ReadOnlySpan<char> src, ref ByteBlock4 dst)
        {
            Asci.encode(src, dst.Bytes);
            return ref dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static asci8 encode(in char src, byte count, out asci8 dst)
        {
            dst = asci8.Null;
            ref var storage = ref @as<asci8,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return dst;
        }

        /// <summary>
        /// Populates an 8-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci8 encode(N8 n, ReadOnlySpan<char> src)
            => encode(src, out asci8 dst);

        /// <summary>
        /// Populates an 8-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static asci8 encode(ReadOnlySpan<char> src, out asci8 dst)
        {
            dst = default;
            AsciSymbols.codes(src, span<asci8,AsciCode>(ref dst));
            return dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static asci32 encode(in char src, byte count, out asci32 dst)
        {
            dst = asci32.Null;
            ref var storage = ref @as<asci32,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return dst;
        }

        /// <summary>
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static asci32 encode(ReadOnlySpan<char> src, out asci32 dst)
        {
            dst = asci32.Spaced;
            AsciSymbols.codes(src, span<asci32,AsciCode>(ref dst));
            return dst;
        }

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static asci64 encode(in char src, byte count, out asci64 dst)
        {
            dst = asci64.Null;
            ref var storage = ref @as<asci64,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return dst;
        }

        /// <summary>
        /// Populates a 64-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static asci64 encode(ReadOnlySpan<char> src, out asci64 dst)
        {
            dst = asci64.Spaced;
            AsciSymbols.codes(src, span<asci64,AsciCode>(ref dst));
            return dst;
        }

        /// <summary>
        /// Populates a 32-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci64 encode(N64 n, ReadOnlySpan<char> src)
            => encode(src, out asci64 dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock4 encode(string src, out AsciBlock4 dst)
            => encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock8 encode(string src, out AsciBlock8 dst)
            => encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock16 encode(string src, out AsciBlock16 dst)
            => encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock32 encode(string src, out AsciBlock32 dst)
            => encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock64 encode(string src, out AsciBlock64 dst)
            => encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock128 encode(string src, out AsciBlock128 dst)
            => encode(span(src), out dst);

        [MethodImpl(Inline), Op]
        public static AsciBlock4 encode(ReadOnlySpan<char> src, out AsciBlock4 dst)
        {
            dst = default;
            var count = min(ByteBlock4.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock8 encode(ReadOnlySpan<char> src, out AsciBlock8 dst)
        {
            dst = default;
            var count = min(ByteBlock8.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock16 encode(ReadOnlySpan<char> src, out AsciBlock16 dst)
        {
            dst = default;
            var count = min(ByteBlock16.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock24 encode(ReadOnlySpan<char> src, out AsciBlock24 dst)
        {
            dst = default;
            var count = min(ByteBlock24.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock32 encode(ReadOnlySpan<char> src, out AsciBlock32 dst)
        {
            dst = AsciBlock32.Empty;
            var count = min(ByteBlock32.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock64 encode(ReadOnlySpan<char> src, out AsciBlock64 dst)
        {
            dst = AsciBlock64.Empty;
            var count = min(ByteBlock64.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static AsciBlock128 encode(ReadOnlySpan<char> src, out AsciBlock128 dst)
        {
            dst = AsciBlock128.Empty;
            var count = min(ByteBlock128.N, src.Length);
            encode(src, slice(dst.Bytes,0,count));
            return dst;
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
    }
}