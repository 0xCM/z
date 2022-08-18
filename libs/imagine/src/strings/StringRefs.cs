//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    using api = StringRefs;

    /// <summary>
    /// Defines a character string over an embedded resource
    /// </summary>
    [ApiHost]
    public unsafe struct StringRefs
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRefs<S> embedded<S>(ReadOnlySpan<S> src)
            where S : unmanaged
                => new StringRefs<S>(src);

        [MethodImpl(Inline), Op]
        public static StringRefs<char> embedded(string src)
            => new StringRefs<char>(src);

        [MethodImpl(Inline), Op]
        public static StringRefs<char> embedded(ReadOnlySpan<char> src)
            => new StringRefs<char>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRef<S> word<S>(in StringRefs<S> src, ulong index, ulong length)
            where S : unmanaged
                => new StringRef<S>(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRef<S> word<S>(in StringRefs<S> src, long index, long length)
            where S : unmanaged
                => new StringRef<S>(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op]
        public static StringRef word(in StringRefs src, ulong index, ulong length)
            => new StringRef(src.Address(index), (uint)length);

        [MethodImpl(Inline), Op]
        public static StringRef word(in StringRefs src, long index, long length)
            => new StringRef(src.Address(index), (uint)length);

        [Op]
        public static string format(in StringRef src)
            => new string(src.Cells);

        public static string format<S>(in StringRef<S> src)
            where S : unmanaged
                => new string(recover<S,char>(src.View));

        [Op]
        public static string format(in StringRefs src)
            => new string(src.View);

        public static string format<S>(in StringRefs<S> src)
            where S : unmanaged
                => new string(recover<S,char>(src.View));

        readonly MemoryAddress BaseAddress;

        /// <summary>
        /// The maximum number of symbols in the string
        /// </summary>
        public readonly uint Length;

        [MethodImpl(Inline)]
        public StringRefs(ReadOnlySpan<char> src)
        {
            BaseAddress = address(first(src));
            Length = (uint)src.Length;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<char>();
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => cover(BaseAddress.Pointer<char>(), Length);
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(ulong index)
            => address(skip(View,index));

        [MethodImpl(Inline)]
        public MemoryAddress Address(long index)
            => address(skip(View,index));

        [MethodImpl(Inline)]
        public ref readonly char Symbol(ulong index)
            => ref skip(View,index);

        [MethodImpl(Inline)]
        public ref readonly char Symbol(long index)
            => ref skip(View,index);

        [MethodImpl(Inline)]
        public StringRef Word(ulong index, ulong length)
            => api.word(this, index, length);

        [MethodImpl(Inline)]
        public StringRef Word(long index, long length)
            => api.word(this, index, length);

        public ref readonly char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public ref readonly char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public StringRef this[long offset, long length]
        {
            [MethodImpl(Inline)]
            get => api.word(this, offset, length);
        }

        public StringRef this[ulong offset, ulong length]
        {
            [MethodImpl(Inline)]
            get => api.word(this, offset, length);
        }

        public string Format()
            => sys.@string(View);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator StringRefs(ReadOnlySpan<char> src)
            => new StringRefs(src);

        [MethodImpl(Inline)]
        public static implicit operator StringRefs(string src)
            => new StringRefs(src);
    }
}