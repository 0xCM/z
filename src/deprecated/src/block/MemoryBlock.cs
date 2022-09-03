//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class SRM
    {
        public const int InvalidCompressedInteger = int.MaxValue;

        [ApiHost("srm.memoryblock")]
        public readonly unsafe partial struct MemoryBlock
        {
            public readonly byte* Pointer;

            public readonly int Length;

            [MethodImpl(Inline)]
            public MemoryBlock(byte* buffer, int length)
            {
                Pointer = buffer;
                Length = length;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Length == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Length != 0;
            }

            public static MemoryBlock Empty
            {
                [MethodImpl(Inline)]
                get => new MemoryBlock(core.gptr(first(Array.Empty<byte>())),0);
            }

            public MemoryBlockDef Definition
            {
                [MethodImpl(Inline)]
                get => this;
            }

            public MemoryAddress BaseAddress
            {
                [MethodImpl(Inline)]
                get => IsNonEmpty ? Pointer : MemoryAddress.Zero;
            }

            [MethodImpl(Inline), Op]
            bool Available(int offset, int byteCount)
                => available(this, (uint)offset, byteCount);

            [Op]
            public byte[]? ToArray()
                => Pointer == null ? null : PeekBytes(0, Length);
        }
    }
}