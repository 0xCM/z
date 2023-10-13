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

        [Render(128)]
        public InstCells Body;

        public MachineMode Mode;

        public Hex8 OpCode;

        public InstAttribs InstAttribs;

        public PatternOps Operands;

        public int CompareTo(InstBlockPattern src)
        {
            var result = Form.CompareTo(src.Form);
            if(result == 0)
                result = Body.Count.CompareTo(src.Body.Count);
            return result;
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}