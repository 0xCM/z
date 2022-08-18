
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeBufferSeq : IDisposable
    {
        readonly Index<NativeBuffer> _Buffers;

        [MethodImpl(Inline)]
        internal NativeBufferSeq(NativeBuffer[] src)
        {
            _Buffers = src;
        }

        public uint BufferCount
        {
            [MethodImpl(Inline)]
            get => _Buffers.Count;
        }

        public ref readonly NativeBuffer this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Buffer(index);
        }

        [MethodImpl(Inline)]
        public ref readonly NativeBuffer Buffer(uint index)
            => ref _Buffers[index];

        [MethodImpl(Inline)]
        public Span<byte> Edit(uint index)
            => Buffer(index).Edit;

        [MethodImpl(Inline)]
        public MemoryAddress Address(uint index)
            => Buffer(index).BaseAddress;

        [MethodImpl(Inline)]
        public BitWidth Width(uint index)
            => Buffer(index).Width;

        [MethodImpl(Inline)]
        public ByteSize Size(uint index)
            => Buffer(index).Size;

        [MethodImpl(Inline)]
        public void Clear(uint index)
            => Buffer(index).Clear();

        [MethodImpl(Inline)]
        public Span<byte> Slice(uint index, uint offset, uint length)
            => Spans.slice(Edit(index), offset, length);

        public void Clear()
        {
            for(var i=0; i<BufferCount; i++)
                _Buffers[i].Clear();
        }

        public void Dispose()
        {
            for(var i=0; i<BufferCount; i++)
                _Buffers[i].Dispose();
        }
    }
}