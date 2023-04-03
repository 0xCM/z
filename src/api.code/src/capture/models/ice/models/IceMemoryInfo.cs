//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Z0.Asm;

    /// <summary>
    /// Describes a block of memory the context of an asm instruction operand
    /// </summary>
    public readonly struct IceMemoryInfo
    {
        public readonly IceRegister Seg;

        public readonly IceRegister SegPrefix;

        public readonly IceMemDirect Direct;

        public readonly MemoryAddress Address;

        public readonly IceMemorySize Size;

        public IceMemoryInfo(IceRegister segreg, IceRegister prefix, IceMemDirect mem, MemoryAddress address, IceMemorySize size)
        {
            Seg = segreg;
            SegPrefix = prefix;
            Direct = mem;
            Address = address;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0 && Direct.IsEmpty && Seg == 0 && SegPrefix == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasKnownSize
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public static IceMemoryInfo Empty
            => default;
    }
}