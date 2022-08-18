//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct ModRmMod
    {
        readonly uint4 Data;

        [MethodImpl(Inline)]
        public ModRmMod(ModRmMod16 src)
        {
            Data = BitNumbers.set((uint4)(byte)src,3,bit.On);
        }

        [MethodImpl(Inline)]
        public ModRmMod(ModRmMod32 src)
        {
            Data = BitNumbers.set((uint4)(byte)src,4,bit.On);
        }

        public ModRmKind Kind
        {
            [MethodImpl(Inline)]
            get => (ModRmKind)(byte)(Data >> 2);
        }

        public uint2 Value
        {
            [MethodImpl(Inline)]
            get => (uint2)Data;
        }

        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();
    }
}