//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using Asm.Operands;

    public struct RegGrid32x512
    {
        RegStore32x512 Storage;

        RegNameSet XmmNames;

        RegNameSet YmmNames;

        RegNameSet ZmmNames;

        public RegGrid32x512()
        {
            Storage = new();
            var regs = AsmRegSets.create();
            XmmNames = regs.XmmRegNames();
            YmmNames = regs.YmmRegNames();
            ZmmNames = regs.ZmmRegNames();

        }

        [MethodImpl(Inline)]
        public ref readonly AsmRegName XmmName(byte n)
            => ref XmmNames[n];

        [MethodImpl(Inline)]
        public ref readonly AsmRegName YmmName(byte n)
            => ref YmmNames[n];

        [MethodImpl(Inline)]
        public ref readonly AsmRegName ZmmName(byte n)
            => ref ZmmNames[n];

        [MethodImpl(Inline)]
        public ref xmm XmmVal(byte n)
            => ref Storage.Xmm(n);

        [MethodImpl(Inline)]
        public ref ymm YmmVal(byte n)
            => ref Storage.Ymm(n);

        [MethodImpl(Inline)]
        public ref zmm ZmmVal(byte n)
            => ref Storage.Zmm(n);
    }
}