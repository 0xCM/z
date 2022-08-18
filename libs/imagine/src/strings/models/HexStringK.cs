//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    /// <summary>
    /// Defines a sequence of K-kinded hex chars
    /// </summary>
    public unsafe readonly struct HexString<K>
        where K : unmanaged
    {
        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public HexString(string src)
        {
            var _src = src ?? EmptyString;
            BaseAddress = Pointers.pchar(_src);
            Size = _src.Length * 2;
        }

        [MethodImpl(Inline)]
        public HexString(char* pSrc, ByteSize size)
        {
            BaseAddress = pSrc;
            Size = size;
        }

        [MethodImpl(Inline)]
        public HexString(MemoryAddress @base, ByteSize size)
        {
            BaseAddress = @base;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Size/2;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => view(this);
        }

        public unsafe string Text
        {
            [MethodImpl(Inline)]
            get => View.ToString();
        }

        [MethodImpl(Inline)]
        public unsafe ReadOnlySpan<char> Chars(K index)
            => cover((char*)(BaseAddress + uint8(index)*8), 2);

        [MethodImpl(Inline)]
        public unsafe string String(K index)
            => @as<char,string>(@ref<char>((char*)(BaseAddress + uint8(index)*8)));

        /// <summary>
        /// Reveals the character data identified by a string reference
        /// </summary>
        /// <param name="src">The source reference</param>
        [MethodImpl(Inline), Op]
        static unsafe ReadOnlySpan<char> view(in HexString<K> src)
            => cover<char>(src.BaseAddress.Pointer<char>(), (uint)src.Length);

        public static HexString<K> Empty
            => new HexString<K>(EmptyString);
    }
}