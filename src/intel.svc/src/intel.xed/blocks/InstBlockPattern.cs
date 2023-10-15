//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;
using static sys;

using static XedModels;
using static XedRules;

partial class XedZ
{
    [Record(TableName)]
    public record InstBlockPattern : IComparable<InstBlockPattern>, ISequential
    {
        const string TableName = "xed.instblock.patterns";

        [Render(8)]
        public uint Seq;

        [Render(8)]
        public byte Index;

        [Render(20)]
        public XedInstClass Instruction;

        [Render(8)]
        public MachineMode Mode;

        [Render(8)]
        public bit Lock;

        [Render(8)]
        public Hex8 OpCode;

        [Render(58)]
        public XedInstForm Form;

        [Render(220)]
        public InstCells Body;

        [Render(92)]
        public InstAttribs InstAttribs;

        [Render(1)]
        public InstBlockOperands Operands;

        public int CompareTo(InstBlockPattern src)
            => XedZ.cmp(this, src);

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}