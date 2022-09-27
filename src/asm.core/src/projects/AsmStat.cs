//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct AsmStat : IComparable<AsmStat>
    {
        public const string TableId = "asm.stats";

        public Identifier AsmName;

        public uint Count;

        public int CompareTo(AsmStat src)
            => AsmName.CompareTo(src.AsmName);
    }
}