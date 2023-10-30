//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

partial class XedCmd
{
    [CmdOp("asm/regs/query")]
    Outcome RegQuery(CmdArgs args)
    {
        var selected = list<RegNameSet>();
        var result = Outcome.Success;
        if(args.Count != 0)
        {
            for(var i=0; i<args.Count; i++)
            {
                var pred = args[i].Value;
                result = DataParser.eparse(pred, out RegClassCode @class);
                if(result.Fail)
                    return result;

                var names = AsmRegSets.RegNames(@class);
                if(names.IsNonEmpty)
                    selected.Add(names);
            }
        }
        else
        {
            selected.Add(AsmRegSets.Gp8RegNames());
            selected.Add(AsmRegSets.Gp16RegNames());
            selected.Add(AsmRegSets.Gp32RegNames());
            selected.Add(AsmRegSets.Gp64RegNames());
            selected.Add(AsmRegSets.XmmRegNames());
            selected.Add(AsmRegSets.YmmRegNames());
            selected.Add(AsmRegSets.ZmmRegNames());
            selected.Add(AsmRegSets.MaskRegNames());
            selected.Add(AsmRegSets.MmxRegNames());
            selected.Add(AsmRegSets.SegRegNames());
            selected.Add(AsmRegSets.CrRegNames());
            selected.Add(AsmRegSets.DbRegNames());
            selected.Add(AsmRegSets.FpuRegNames());
        }

        var buffer = text.buffer();
        iter(selected, reg => buffer.AppendLine(string.Format("{0}:[{1}]", reg.Name, reg.Format())));
        Channel.Write(buffer.Emit());

        return result;
    }
}