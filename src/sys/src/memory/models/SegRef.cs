//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a reference to a memory segment
    /// </summary>
    public readonly struct SegRef : ISegRef<byte>
    {
        public readonly MemoryAddress Address;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public SegRef(MemoryAddress src, ByteSize size)
        {
            Address = src;
            Size = size;
        }

        [MethodImpl(Inline)]
        ref byte self()
            => ref first(bytes(this));

        [MethodImpl(Inline)]
        public ref SegRef<T> As<T>()
            where T : unmanaged
                => ref @as<byte,SegRef<T>>(self());

        [MethodImpl(Inline)]
        public Span<T> Data<T>()
            => cover<T>(BaseAddress, Length/size<T>());

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Length);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => cover<byte>(BaseAddress, Length);
        }

        public uint Length
        {
            [MethodImpl(Inline)]
            get => Size;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Address;
        }

        public uint CellSize
        {
            [MethodImpl(Inline)]
            get => 1;
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Length;
        }

        [MethodImpl(Inline)]
        public unsafe ref byte Cell(int index)
            => ref Unsafe.AsRef<byte>((void*)(BaseAddress + (uint)index));

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => nhash(Address,Size);
        }

        public override int GetHashCode()
            => Hash;

        public ref byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        [MethodImpl(Inline)]
        public unsafe byte* Pointer()
            => BaseAddress.Pointer<byte>();

        [MethodImpl(Inline)]
        public bool Equals(SegRef src)
            => src.Address == Address && src.Size == Size;

        [MethodImpl(Inline)]
        public unsafe T* Pointer<T>()
            where T : unmanaged
                => BaseAddress.Pointer<T>();

        public string Format()
            => string.Format("{0}:{1}", BaseAddress, Length);

        public override bool Equals(object src)
            => src is SegRef r && Equals(r);

        /// <summary>
        /// Dereferences the reference
        /// </summary>
        /// <param name="src">The source reference</param>
        [MethodImpl(Inline)]
        public static Span<byte> operator !(SegRef src)
            => src.Edit;

        [MethodImpl(Inline)]
        public static bool operator ==(SegRef a, SegRef b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(SegRef a, SegRef b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator SegRef((MemoryAddress src, ByteSize size) src)
            => new SegRef(src.src, src.size);


        public static SegRef Empty => default;
    }
}