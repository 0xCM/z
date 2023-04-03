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
        public static void decode(asci16 src, ref char dst)
        {
           var decoded = vpack.vinflate256x16u(src.Storage);
           vcpu.vstore(decoded, ref @as<char,ushort>(dst));
        }

        [MethodImpl(Inline), Op]
        public static void decode(N16 n, ReadOnlySpan<byte> src, Span<char> dst)
            => vcpu.vstore(vpack.vinflate256x16u(vcpu.vload(w128,src)), ref @as<ushort>(sys.first(dst)));

        [MethodImpl(Inline), Op]
        public static string decode(asci16 src)
            => sys.@string(slice(recover<char>(sys.bytes(vpack.vinflate256x16u(src.Storage))),0, src.Length));

        [MethodImpl(Inline)]
        public static ref readonly asci16 cast<A>(N16 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci16>(src);

        /// <summary>
        /// Returns the index of the first source element that matches a specified value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="match">The value to match</param>
        [MethodImpl(Inline), Op]
        public static int index(in asci16 src, byte match)
            => AsciSymbols.search(@byte(edit(src)), src.Capacity, match);

        [MethodImpl(Inline), Op]
        public static C code(in asci16 src, Hex4Kind index)
            => (C)skip(bytes(src), (byte)index);

        [MethodImpl(Inline), Op]
        public static C code(in asci16 src, N4 index)
            => code<N4>(src, index);

        [MethodImpl(Inline)]
        public static C code<N>(in asci16 src, N index = default)
            where N : unmanaged, ITypeNat
                => (C)vcpu.vextract(src.Storage, index);

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
        public static asci16 encode(in char src, byte count, out asci16 dst)
        {
            dst = asci16.Null;
            ref var storage = ref @as<asci16,AsciCode>(dst);
            AsciSymbols.codes(src, (byte)count, ref storage);
            return dst;
        }

        /// <summary>
        /// Populates a 16-code asci block from the leading cells of a character span
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The target block</param>
        [MethodImpl(Inline), Op]
        public static asci16 encode(ReadOnlySpan<char> src, out asci16 dst)
        {
            dst = asci16.Spaced;
            AsciSymbols.codes(src, span<asci16,AsciCode>(ref dst));
            return dst;
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
            => new asci16(vcpu.vbroadcast(w128, (byte)fill));

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
            => AsciSymbols.search(@byte(edit(src)), src.Capacity, (byte)match);

        [MethodImpl(Inline), Op]
        public static char @char(in asci16 src, Hex4Kind index)
            => (char)code(src,index);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci16 src, ref byte dst)
            => vcpu.vstore(src.Storage, ref dst);

        [MethodImpl(Inline), Op]
        public static unsafe void copy(in asci16 src, Span<byte> dst)
            => vcpu.vstore(src.Storage, dst);

        [MethodImpl(Inline), Op]
        public static void store(in asci16 src, Span<char> dst)
            => decode(src, ref first(dst));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(in asci16 src)
            => recover<AsciSymbol>(sys.bytes(src));

        [MethodImpl(Inline), Op]
        public static bool contains(in asci16 src, char match)
            => AsciSymbols.contains(src, (AsciCharSym)match);

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
            var data = sys.bytes(src);
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