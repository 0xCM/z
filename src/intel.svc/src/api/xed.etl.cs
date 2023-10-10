//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using System.Linq;

using static sys;
using static XedModels;
using static XedZ;

[Record(TableName)]
public record XedInstPattern : IComparable<XedInstPattern>, ISequential
{
    const string TableName = "xed.instructions.patterns";

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

    public int CompareTo(XedInstPattern src)
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


partial class XedCmd
{
    XedImport XedImport => Wf.XedImport();

    [CmdOp("xed/ock")]
    void ListOcKinds()
    {
        var src = AsmOpCodes.info();
        iter(src, r => {
            Channel.RowFormat("{0} {1}", r.Name, r.Number);
        });
    }

    [CmdOp("xed/blocks")]
    void EmitBlockLines()
    {
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}
