//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm.Operands;

    partial class X86Machine
    {
        [MethodImpl(Inline), Op]
        public void mov(r8 a, r8 b)
            => reg8(a) = reg8(b);

        [MethodImpl(Inline), Op]
        public void mov(r16 a, r16 b)
            => reg16(a) = reg16(b);

        [MethodImpl(Inline), Op]
        public void mov(r32 a, r32 b)
            => reg32(a) = reg32(b);

        [MethodImpl(Inline), Op]
        public void mov(r64 a, r64 b)
            => reg64(a) = reg64(b);
    }
}