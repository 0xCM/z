//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [StructLayout(StructLayout, Pack=1), Record(TableId)]
        public struct RegMapEntry
        {
            public const string TableId = "xed.regs.map";

            [Render(8)]
            public ushort XedRegId;

            [Render(8)]
            public Asm.RegClass RegClass;

            [Render(8)]
            public NativeSize RegSize;

            [Render(8)]
            public text7 RegName;

            [Render(8)]
            public byte RegIndex;
        }
    }
}