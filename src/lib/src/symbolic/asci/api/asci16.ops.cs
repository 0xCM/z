//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    using C = AsciCode;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static C code(in asci16 src, Hex4Kind index)
            => (C)skip(bytes(src), (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci16 src, N4 index)
            => code<N4>(src, index);

        [MethodImpl(Inline)]
        public static C code<N>(in asci16 src, N index = default)
            where N : unmanaged, ITypeNat
                => (C)cpu.vextract(src.Storage, index);

        /// <summary>
        /// Populates a 16-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static asci16 encode(N16 n, ReadOnlySpan<char> src)
            => encode(src, out asci16 dst);

        /// <summary>
        /// Populates an asci target with a specified number of source characters
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of characters to encode</param>
        /// <param name="dst">The receiver</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci16 encode(in char src, byte count, out asci16 dst)
        {
            dst = asci16.Null;
            ref var storage = ref @as<asci16,AsciCode>(dst);
            codes(src, (byte)count, ref storage);
            return ref dst;
        }

        /// <summary>
        /// Populates a 16-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static ref readonly asci16 encode(ReadOnlySpan<char> src, out asci16 dst)
        {
            dst = asci16.Spaced;
            codes(src, span<asci16,AsciCode>(ref dst));
            return ref dst;
        }

        /// <summary>
        /// Presents the source content as a bytespan
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> bytes(in asci16 src)
            => src.Storage.ToSpan();

        [MethodImpl(Inline), Op]
        public static asci16 init(N16 n, ulong lo, ulong hi)
            => new asci16(Vector128.Create(lo,hi).AsByte());
        [MethodImpl(Inline), Op]
        public static asci16 init(N16 n, AsciCode fill = AsciCode.Space)
            => new asci16(cpu.vbroadcast(w128, (byte)fill));

        [MethodImpl(Inline), Op]
        public static asci16 init(N16 n, ReadOnlySpan<AsciCode> src)
            => new asci16(recover<AsciCode,byte>(src));

        /// <summary>
        /// Counts the number of characters that precede a null terminator, if any
        /// </summary>
        /// <param name="src">The asci source</param>
        [MethodImpl(Inline), Op]
        public static int length(in asci16 src)
            => foundnot(index(src, z8), src.Capacity);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci16 src, char match)
            => search(@byte(edit(src)), src.Capacity, (byte)match);

        [MethodImpl(Inline), Op]
        public static char @char(in asci16 src, Hex4Kind index)
            => (char)code(src,index);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci16 src, ref byte dst)
            => cpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci16 src, Span<byte> dst)
            => cpu.vstore(src.Storage, dst);

        [MethodImpl(Inline), Op]
        public static void store(in asci16 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci16 src)
            => recover<AsciSymbol>(core.bytes(src));

        [MethodImpl(Inline), Op]
        public static bool contains(in asci16 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static asci16[] alloc(N16 n, int count)
        {
            var buffer =  new asci16[count];
            Span<asci16> dst = buffer;
            dst.Fill(init(n));
            return buffer;
        }

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci16 src)
            => ref @as<asci16,byte>(src);

        /// <summary>
        /// Counts the number of source characters that match the target
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="match">The character to match</param>
        [MethodImpl(Inline), Op]
        public static byte count(in asci16 src, AsciSymbol match)
        {
            var data = src.View;
            var counter = z8;
            for(var i=0; i< asci16.Size; i++)
            {
                if(skip(data,i) == match)
                    counter++;
            }
            return counter;
        }
    }
}