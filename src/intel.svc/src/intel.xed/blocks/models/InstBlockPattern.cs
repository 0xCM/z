//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedZ
{
    [Record(TableName)]
    public record InstBlockPattern : IComparable<InstBlockPattern>, ISequential
    {
        const string TableName = "xed.instblock.patterns";

        [Render(8)]
        public uint Seq;

        [Render(20)]
        public XedInstClass Instruction;

        [Render(58)]
        public XedInstForm Form;

        [Render(8)]
        public byte Index;

        [Render(1)]
        public InstPatternBody Body;

        public int CompareTo(InstBlockPattern src)
        {
            var result = Form.CompareTo(src.Form);
            if(result == 0)
                result = Body.CellCount.CompareTo(src.Body.CellCount);
            return result;
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }

}