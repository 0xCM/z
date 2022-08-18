//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    partial class SRM
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MemoryBlock<T>
            where T : unmanaged, ICliRecord<T>
        {
            public readonly byte* Pointer;

            public readonly int Length;

            [MethodImpl(Inline)]
            public MemoryBlock(byte* ptr, int size)
            {
                Pointer = ptr;
                Length = size;
            }

            [MethodImpl(Inline)]
            public static implicit operator MemoryBlock<T>(MemoryBlock src)
                => new MemoryBlock<T>(src.Pointer, src.Length);

            [MethodImpl(Inline)]
            public static implicit operator MemoryBlock(MemoryBlock<T> src)
                => new MemoryBlock(src.Pointer, src.Length);

            [MethodImpl(Inline)]
            public static implicit operator MemoryBlockDef(MemoryBlock<T> src)
                => new MemoryBlockDef(src.Pointer, src.Length);

            [MethodImpl(Inline)]
            public static implicit operator MemoryBlock<T>(MemoryBlockDef src)
                => new MemoryBlock<T>(src.Pointer, src.Length);
        }
    }
}