//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class SRM
    {
        public unsafe readonly struct MemoryBlockDef
        {
            public readonly byte* Pointer;

            public readonly int Length;

            [MethodImpl(Inline)]
            public MemoryBlockDef(byte* ptr, int size)
            {
                Pointer = ptr;
                Length = size;
            }

            [MethodImpl(Inline)]
            public static implicit operator MemoryBlockDef(MemoryBlock src)
                => new MemoryBlockDef(src.Pointer, src.Length);

            [MethodImpl(Inline)]
            public static implicit operator MemoryBlock(MemoryBlockDef src)
                => new MemoryBlock(src.Pointer, src.Length);
        }
    }
}