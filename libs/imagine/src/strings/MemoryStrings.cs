//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    [StructLayout(StructLayout,Pack=1, Size=Size)]
    public unsafe readonly struct MemoryStrings
    {
        const byte OffsetScale = 4;

        [MethodImpl(Inline), Op]
        public static MemoryStrings create(uint entries, uint length, MemoryAddress offsetbase, MemoryAddress charbase)
            => new MemoryStrings(entries, length, offsetbase, charbase);

        [MethodImpl(Inline), Op]
        public static MemoryStrings create(ReadOnlySpan<byte> offsets, ReadOnlySpan<char> chars)
            => new MemoryStrings(count(offsets), (uint)chars.Length, Algs.address(offsets), Algs.address(chars));

        [MethodImpl(Inline)]
        public static MemoryStrings<K> create<K>(ReadOnlySpan<byte> offsets, ReadOnlySpan<char> chars)
            where K : unmanaged
                => new MemoryStrings<K>(create(offsets, chars));

        [MethodImpl(Inline)]
        public static StringAddress<N> natural<N>(string src)
            where N : unmanaged, ITypeNat
        {
            if(src.Length >= Typed.nat32i<N>())
                return new StringAddress<N>(address(src));
            else
                return default;
        }

        [MethodImpl(Inline), Op]
        public static unsafe string format(StringAddress src)
            => new string(src.Address.Pointer<char>());

        [MethodImpl(Inline), Op]
        public static unsafe string format<N>(StringAddress<N> src)
            where N : unmanaged, ITypeNat
                => new string(src.Address.Pointer<char>());

        [MethodImpl(Inline), Op]
        public static unsafe ref char first(StringAddress src)
            => ref @ref(src.Address.Pointer<char>());

        [MethodImpl(Inline), Op]
        public static uint render(StringAddress src, ref uint i, Span<char> dst)
        {
            var i0=i;
            ref var c = ref first(src);
            var j=0u;
            while(c != 0 && i < dst.Length)
                seek(dst, i++) = skip(c, j++);
            return j-1;
        }

        [MethodImpl(Inline)]
        public static uint render<N>(StringAddress<N> src, ref uint i, Span<char> dst)
            where N : unmanaged, ITypeNat
        {
            ref var c = ref first(src.Source);
            var n = src.Length;
            for(var j=0; j<n; j++)
                seek(dst,i++) = skip(c,j);
            return n;
        }

        [MethodImpl(Inline), Op]
        static Label label(ReadOnlySpan<char> src)
            => new Label(Algs.address(src), (byte)src.Length);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in MemoryStrings src)
            => Algs.cover(src.CharBase.Pointer<char>(), src.CharCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(MemoryAddress @base, int i0, int i1)
            => Algs.cover(@base.Pointer<char>() + i0, (i1 - i0));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in MemoryStrings src, int index)
            => slice(chars(src), offset(src, index), length(src, index));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> chars(in MemoryStrings src, uint index)
            => chars(src, (int)index);

        /// <summary>
        /// Determines the address of a character string at a specified offset
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(MemoryStrings src, int index)
            => Algs.address(chars(src, index));

        /// <summary>
        /// Determines the address of a character string at a specified offset
        /// </summary>
        /// <param name="src"></param>
        /// <param name="offset"></param>
        [MethodImpl(Inline), Op]
        public static MemoryAddress address(MemoryStrings src, uint index)
            => Algs.address(chars(src, index));

        [MethodImpl(Inline), Op]
        public static StringAddress address(string src)
            => new StringAddress(Algs.address(src));

        [MethodImpl(Inline), Op]
        public static StringAddress address(ReadOnlySpan<char> src)
            => new StringAddress(Algs.address(src));

        [MethodImpl(Inline), Op]
        public static StringAddress address<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => new StringAddress(Algs.address(src));

        [MethodImpl(Inline)]
        public static MemoryString<K> @string<K>(in MemoryStrings<K> src, K index)
            where K : unmanaged
                => new MemoryString<K>(src.CharBase + offset(src, index), length(src,index));

        [MethodImpl(Inline)]
        public static MemoryString<K> @string<K>(in MemoryStrings<K> src, uint index)
            where K : unmanaged
                => new MemoryString<K>(src.CharBase + offset(src,index), length(src,index));

        [MethodImpl(Inline), Op]
        public static uint count(ReadOnlySpan<byte> offsets)
            => (uint)(offsets.Length/4);

        [MethodImpl(Inline), Op]
        public static ref readonly uint offset(in MemoryStrings strings, int index)
        {
            var src = recover<uint>(cover(strings.OffsetBase.Pointer<byte>(), strings.EntryCount*OffsetScale));
            return ref skip(src,index);
        }

        [MethodImpl(Inline), Op]
        public static ref readonly uint offset<K>(in MemoryStrings<K> strings, uint index)
            where K : unmanaged
        {
            var src = recover<uint>(cover(strings.OffsetBase.Pointer<byte>(), strings.EntryCount*OffsetScale));
            return ref skip(src, index);
        }

        [MethodImpl(Inline), Op]
        public static ref readonly uint offset<K>(in MemoryStrings<K> strings, K index)
            where K : unmanaged
        {
            var src = recover<uint>(cover(strings.OffsetBase.Pointer<byte>(), strings.EntryCount*OffsetScale));
            return ref skip(src, bw32(index));
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<uint> offsets(in MemoryStrings src)
            => recover<uint>(cover(src.OffsetBase.Pointer<byte>(), src.EntryCount*OffsetScale));

        [MethodImpl(Inline), Op]
        public static int length(in MemoryStrings src, uint index)
        {
            var a = offset(src, index);
            var b = 0u;
            if(index == src.EntryCount - 1)
                b = src.CharCount;
            else
                b = offset(src, index + 1);
            return (int)(b - a);
        }

        [MethodImpl(Inline), Op]
        public static int length(in MemoryStrings src, int index)
            => length(src, (uint)index);

        [MethodImpl(Inline), Op]
        public static int length<K>(in MemoryStrings<K> src, K index)
            where K : unmanaged
        {
            var a = offset(src, index);
            var b = 0u;
            if(bw32(index) == src.EntryCount - 1)
                b = src.CharCount;
            else
                b = offset(src, bw32(index) + 1);
            return (int)(b - a);
        }

        [MethodImpl(Inline), Op]
        public static int length<K>(in MemoryStrings<K> src, uint index)
            where K : unmanaged
        {
            var a = offset(src, index);
            var b = 0u;
            if(index == src.EntryCount - 1)
                b = src.CharCount;
            else
                b = offset(src, index + 1);
            return (int)(b - a);
        }

        [MethodImpl(Inline), Op]
        public static uint length(StringAddress src)
        {
            ref var c = ref first(src);
            var counter = 0u;
            while(c != 0)
                c = seek(c, counter++);
            return counter;
        }

        public const ushort Size = 8 + 16;

        public readonly uint EntryCount;

        public readonly uint CharCount;

        public readonly MemoryAddress OffsetBase;

        public readonly MemoryAddress CharBase;

        [MethodImpl(Inline)]
        public MemoryStrings(uint entries, uint chars, MemoryAddress offsetbase, MemoryAddress charbase)
        {
            EntryCount = entries;
            CharCount = chars;
            OffsetBase = offsetbase;
            CharBase = charbase;
        }

        public ReadOnlySpan<char> this[int index]
        {
            [MethodImpl(Inline)]
            get => chars(this, index);
        }

        public ReadOnlySpan<char> this[uint index]
        {
            [MethodImpl(Inline)]
            get => chars(this, index);
        }

        [MethodImpl(Inline)]
        public int Length(uint index)
            => length(this,index);

        [MethodImpl(Inline)]
        public int Length(int index)
            => length(this,index);

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => address(this, index);

        [MethodImpl(Inline)]
        public MemoryAddress Address(int index)
            => address(this, index);

        [MethodImpl(Inline)]
        public MemoryString String(uint index)
            => new MemoryString(Address(index), Length(index));

        [MethodImpl(Inline)]
        public MemoryString String(int index)
            => new MemoryString(Address(index), Length(index));

        [MethodImpl(Inline)]
        public Label Label(uint index)
            => label(this[index]);

        [MethodImpl(Inline)]
        public Label Label(int index)
            => label(this[index]);

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => chars(this);
        }

        public unsafe ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => offsets(this);
        }

        public MemoryStrings<K> Kinded<K>()
            where K : unmanaged
                => new MemoryStrings<K>(this);
    }
}