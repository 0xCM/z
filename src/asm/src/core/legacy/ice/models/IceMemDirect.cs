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

    public readonly struct IceMemDirect
    {
        public readonly IceRegister Base;

        public readonly MemoryScale Scale;

        public readonly uint Dx;

        // 0 | 1 (16/32/64-bit) | 2 (16-bit) | 4 (32-bit) | 8 (64-bit)
        public readonly uint DxSize;

        [MethodImpl(Inline)]
        public IceMemDirect(IceRegister register, MemoryScale scale, uint dx, uint dxSize)
        {
            Base = register;
            Dx = dx;
            Scale = scale;
            DxSize = dxSize;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Base == 0 && Scale.IsEmpty && Dx != 0;
        }

        public static IceMemDirect Empty
            => new IceMemDirect(IceRegister.None, MemoryScale.Empty, 0, 0);
    }
}