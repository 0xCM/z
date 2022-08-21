//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = StringRefs;

    public unsafe struct StringRefs<C>
        where C : unmanaged
    {
        readonly MemoryAddress BaseAddress;

        /// <summary>
        /// The maximum number of symbols in the string
        /// </summary>
        public uint Length {get;}

        [MethodImpl(Inline)]
        public StringRefs(ReadOnlySpan<C> src)
        {
            BaseAddress = address(first(src));
            Length = (uint)src.Length;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<C>();
        }

        public ReadOnlySpan<C> View
        {
            [MethodImpl(Inline)]
            get => cover(BaseAddress.Pointer<C>(), Length);
        }

        [MethodImpl(Inline)]
        public MemoryAddress Address(ulong index)
            => address(skip(View,index));

        [MethodImpl(Inline)]
        public MemoryAddress Address(long index)
            => address(skip(View,index));

        [MethodImpl(Inline)]
        public ref readonly C Symbol(ulong index)
            => ref skip(View,index);

        [MethodImpl(Inline)]
        public ref readonly C Symbol(long index)
            => ref skip(View,index);

        [MethodImpl(Inline)]
        public StringRef<C> Word(ulong index, ulong length)
            => api.word(this, index, length);

        [MethodImpl(Inline)]
        public StringRef<C> Word(long index, long length)
            => api.word(this, index, length);

        public ref readonly C this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public ref readonly C this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(index);
        }

        public StringRef<C> this[long offset, long length]
        {
            [MethodImpl(Inline)]
            get => api.word(this, offset, length);
        }

        public StringRef<C> this[ulong offset, ulong length]
        {
            [MethodImpl(Inline)]
            get => api.word(this, offset, length);
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator StringRefs<C>(ReadOnlySpan<C> src)
            => new StringRefs<C>(src);
    }
}