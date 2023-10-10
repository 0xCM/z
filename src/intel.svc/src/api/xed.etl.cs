//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using System.Linq;

using static sys;
using static XedModels;
using static XedRules;
using static XedFlows;
using static XedZ;

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
        EmitInstPatterns();
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }


    void EmitInstPatterns()
    {
        var path =  XedPaths.DocSource(XedDocKind.RuleBlocks);
        var patterns = bag<XedInstBlockPattern>();
        XedZ.BlockLines(path, spec => {
            var attribs = list<Attribute>();
            var result = true;
            var pattern = new XedInstBlockPattern{Form = spec.Form};
            patterns.Add(pattern);

            foreach(var line in spec.Lines)
            {                
                if(XedZ.parse(line, out Attribute attrib))
                {
                    attribs.Add(attrib);
                    switch(attrib.Field)
                    {
                        case InstBlockField.iclass:
                        {
                            XedParsers.parse(attrib.Value, out pattern.Instruction);
                        }
                        break;
                        case InstBlockField.pattern:
                        {
                            result = XedInstParser.parse(attrib.Value, out pattern.Body);
                        }
                        break;
                        
                        case InstBlockField.operands:
                        break;
                    }
                }
                if(!result)                
                {
                    Channel.Error(line);
                    break;
                }                
            }
        });

        var records = patterns.OrderBy(x => x.Form).ThenBy(x => x.Body.CellCount).Array().Sort();
        var form = XedInstForm.Empty;
        var j=z8;
        for(var i=0u; i<records.Length; i++)
        {
            ref var record = ref seek(records,i);
            if(record.Form != form)
            {
                j=0;
                form = record.Form;
            }
            record.Seq = i;
            record.Index=j++;
        }

        Channel.TableEmit(records, XedPaths.ImportTable<XedInstBlockPattern>());
    }

}
