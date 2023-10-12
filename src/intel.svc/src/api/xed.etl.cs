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
using static XedZ;

public readonly record struct InstSegPattern
{
    readonly ReadOnlySeq<CellValue> Cells;

    public readonly XedInstForm Form;

    public InstSegPattern(XedInstForm form, ReadOnlySeq<CellValue> src)
    {
        Form = form;
        Cells = src;
    }


    public string Format()
    {
        var dst = text.emitter();
        dst.Append($"{Form,-54} | ");
        for(var i=0; i<Cells.Count; i++)
        {
            if(i!=0)
                dst.Append(Chars.Space);            
            dst.Append(Cells[i]);
        }

        return dst.Emit();
    }

    public override string ToString()
        => Format();

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
        //var blocks = XedImport.blocks();
        //XedImport.Emit(blocks);
        //var domain = XedImport.domain(blocks);
        //XedImport.Emit(domain);
        //EmitInstPatterns();
        var patterns = CollectSegPatterns();
        var dst = text.emitter();
        dst.AppendLineFormat("{0,-54} | {1}", "Form", "Segments");
        foreach(var pattern in patterns)
            dst.AppendLine(pattern.Format());
        Channel.FileEmit(dst.Emit(), XedPaths.Imports().Path("xed.instblock.segs", FileKind.Csv));
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }

    ReadOnlySeq<InstSegPattern> CollectSegPatterns()
    {
        var path =  XedPaths.DocSource(XedDocKind.RuleBlocks);
        var patterns = list<InstSegPattern>();
        XedZ.lines(path, spec => {
            var field = BlockField.Empty;
            foreach(var line in spec.Lines)
            {                
                if(BlockFieldParser.parse(line, out field))
                {
                    switch(field.Name)                
                    {
                        case BlockFieldName.pattern:
                        {
                            var cells = (InstCells)field;
                            var segs = list<CellValue>();
                            var segexpr = EmptyString;
                            for(var i=0; i<cells.Count; i++)
                            {
                                ref readonly var cell = ref cells[i];
                                switch(cell.CellKind)
                                {
                                    case RuleCellKind.BitLit:
                                    case RuleCellKind.HexLit:
                                    case RuleCellKind.InstSeg:
                                        segs.Add(cell);
                                    break;
                                }
                            }
                            patterns.Add(new (spec.Form, segs.Array()));
                        }
                        break;
                    }            
                }
            }
        });
        return patterns.Array();
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
                        {
                            pattern.Body = (InstCells)field;
                            var cells = pattern.Body;
                            var segexpr = EmptyString;
                            for(var i=0; i<cells.Count; i++)
                            {
                                ref readonly var cell = ref cells[i];
                                switch(cell.CellKind)
                                {
                                    case RuleCellKind.InstSeg:
                                    {
                                        if(nonempty(segexpr))
                                            segexpr += " ";
                                         segexpr += cell.AsInstSeg();
                                    }
                                    break;
                                    case RuleCellKind.HexLit:
                                    {
                                        if(nonempty(segexpr))
                                            segexpr += " ";
                                         
                                         segexpr += "0x";
                                         segexpr += cell.AsHexLit();
                                    }                                    
                                    break;
                                    case RuleCellKind.BitLit:
                                        if(nonempty(segexpr))
                                            segexpr += " ";
                                        segexpr += cell.AsBitLit();
                                    break;
                                }
                            }
                            Channel.Row($"{spec.Form,-54} {segexpr}");
                        }
                        break;

                        case BlockFieldName.operands:
                        {
                            var ops = (PatternOps)field;
                            for(var i=z8; i<ops.Count; i++)
                            {
                                ref readonly var op = ref ops[i];
                                if(op.Nonterminal(out var nonterm))
                                {
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
