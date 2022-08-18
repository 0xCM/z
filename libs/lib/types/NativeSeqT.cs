//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public sealed class NativeSeq<T> : Seq<T>, INativeSeq<T>
        where T : unmanaged
    {
        readonly SegRef<T> Source;

        public NativeSeq(SegRef<T> src)
        {
            Source = src;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Source.BaseAddress;
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => Source.SegSize;
        }

        public uint CellSize
        {
            [MethodImpl(Inline)]
            get => Source.CellSize;
        }

        public override uint Count
        {
            [MethodImpl(Inline)]
            get => Source.CellCount;
        }

        public override Span<T> Edit
        {
            [MethodImpl(Inline)]
            get => Source.Data;
        }

        public override ReadOnlySpan<T> View
        {
            [MethodImpl(Inline)]
            get => Source.Data;
        }

        [MethodImpl(Inline)]
        public unsafe ref T Cell(int index)
            => ref Source.Cell(index);

        [MethodImpl(Inline)]
        public unsafe ref T Cell(uint index)
            => ref Source.Cell(index);

        public new ref T First
        {
            [MethodImpl(Inline)]
            get => ref Cell(0);
        }

        public new  ref T this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        public new ref T this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Cell(index);
        }

        public override bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsEmpty;
        }

        public override bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public unsafe T* Pointer()
            => BaseAddress.Pointer<T>();

        [MethodImpl(Inline)]
        public unsafe S* Pointer<S>()
            where S : unmanaged
                => BaseAddress.Pointer<S>();

        [MethodImpl(Inline)]
        public NativeSeq<S> As<S>()
            where S : unmanaged
                => new NativeSeq<S>(new SegRef<S>(Source.BaseAddress, Source.SegSize));
    }
}