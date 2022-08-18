//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
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
                    var pred = arg(args,i).Value;
                    result = DataParser.eparse(pred, out RegClassCode @class);
                    if(result.Fail)
                        return result;

                    var names = Regs.RegNames(@class);
                    if(names.IsNonEmpty)
                        selected.Add(names);
                }
            }
            else
            {
                selected.Add(Regs.Gp8RegNames());
                selected.Add(Regs.Gp16RegNames());
                selected.Add(Regs.Gp32RegNames());
                selected.Add(Regs.Gp64RegNames());
                selected.Add(Regs.XmmRegNames());
                selected.Add(Regs.YmmRegNames());
                selected.Add(Regs.ZmmRegNames());
                selected.Add(Regs.MaskRegNames());
                selected.Add(Regs.MmxRegNames());
                selected.Add(Regs.SegRegNames());
                selected.Add(Regs.CrRegNames());
                selected.Add(Regs.DbRegNames());
                selected.Add(Regs.FpuRegNames());
            }

            var buffer = text.buffer();
            iter(selected, reg => buffer.AppendLine(string.Format("{0}:[{1}]", reg.Name, reg.Format())));
            Write(buffer.Emit());

            return result;
        }
    }
}