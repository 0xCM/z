//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline)]
        public static ImmOpRange range(Imm min, Imm max)
            => new ImmOpRange(min,max);

        [MethodImpl(Inline)]
        public static RegOpRange range(RegClass @class, NativeSize size, RegIndex min, RegIndex max)
            => new RegOpRange(@class, size, min, max);
    }
}