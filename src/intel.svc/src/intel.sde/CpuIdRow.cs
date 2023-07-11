//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout,Pack=1)]
    public record struct CpuIdRow
    {
        public const string TableId = "asm.cpuid";

        public const byte FieldCount = 7;

        [Render(12)]
        public asci16 Chip;

        [Render(12)]
        public Hex32 Leaf;

        [Render(12)]
        public Hex32 Subleaf;

        [Render(12)]
        public Hex32 Eax;

        [Render(12)]
        public Hex32 Ebx;

        [Render(12)]
        public Hex32 Ecx;

        [Render(12)]
        public Hex32 Edx;
    }
}