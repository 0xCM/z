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
    /// Defines a reference to an immutable S-sequence
    /// </summary>
    public unsafe readonly struct StringRef<C>
        where C : unmanaged
    {
        readonly MemoryAddress Base;

        public uint Length {get;}

        [MethodImpl(Inline)]
        internal StringRef(MemoryAddress @base, uint length)
        {
            Base = @base;
            Length = length;
        }

        public ref readonly C this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Base.Ref<C>(), index);
        }

        public ref readonly C this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Base.Ref<C>(), index);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<C>();
        }

        public ReadOnlySpan<C> View
        {
            [MethodImpl(Inline)]
            get => cover<C>(Base.Pointer<C>(), Length);
        }

        public string Format()
            => api.format(this);


        public override string ToString()
            => Format();
    }
}