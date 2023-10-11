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
        //var blocks = XedImport.blocks();
        //XedImport.Emit(blocks);
        //var domain = XedImport.domain(blocks);
        //XedImport.Emit(domain);
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
        var patterns = bag<InstBlockPattern>();
        XedZ.lines(path, spec => {
            var fields = list<BlockField>();
            var result = true;
            var pattern = new InstBlockPattern();
            patterns.Add(pattern);

            var field = BlockField.Empty;
            foreach(var line in spec.Lines)
            {                
                if(BlockFieldParser.parse(line, out field))
                {
                    fields.Add(field);
                    switch(field.Name)
                    {
                        case BlockFieldName.iclass:
                            pattern.Instruction = (XedInstClass)field;
                            break;
                        case BlockFieldName.iform:
                            pattern.Form = (XedInstForm)field;
                            break;
                        case BlockFieldName.pattern:
                            pattern.Body = (InstCells)field;
                            break;

                        case BlockFieldName.operands:
                        {
                            var ops = (PatternOps)field;
                            for(var i=z8; i<ops.Count; i++)
                            {
                                ref readonly var op = ref ops[i];
                                if(op.Nonterminal(out var nonterm))
                                {
                                    Channel.Row(nonterm);
                                }   
                            }
                        }
                        break;
                    }
                }
            }
        });

        var records = patterns.OrderBy(x => x.Form).ThenBy(x => x.Body.Count).Array().Sort();
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

        Channel.TableEmit(records, XedPaths.ImportTable<InstBlockPattern>());
    }

}
