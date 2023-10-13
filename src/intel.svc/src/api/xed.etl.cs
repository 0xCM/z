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

public record InstSegPattern
{
    [Record(TableName)]
    public struct Operand
    {
        const string TableName = "xed.instblock.operands";

        [Render(64)]
        public XedInstForm Form;

        [Render(8)]
        public byte Index;

        [Render(8)]
        public OpName Name;

        [Render(8)]
        public OpKind Kind;

        [Render(12)]
        public OperandWidth Indicator;

        [Render(8)]
        public ushort BitWidth;

        [Render(16)]
        public BitSegType SegType;

        [Render(16)]
        public Register Register;

        [Render(1)]
        public string SourceExpr;
    }

    public Seq<CellValue> Cells;

    public XedInstForm Form;

    public Seq<Operand> Operands;

    public InstSegPattern()
    {
        Cells = sys.empty<CellValue>();
        Form = default;
        Operands = sys.empty<Operand>();
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
        var patterns = CollectSegPatterns();
        var operands = list<InstSegPattern.Operand>();
        foreach(var pattern in patterns)
        {   
            var count = pattern.Operands.Count;
            for(var i=0; i<count; i++)
            {
                operands.Add(pattern.Operands[i]);
            }
        }


        Channel.TableEmit(operands.ViewDeposited(), XedPaths.ImportTable<InstSegPattern.Operand>());
        
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }

    ReadOnlySeq<InstSegPattern> CollectSegPatterns()
    {
        var path =  XedPaths.RuleBlockSource();
        var patterns = list<InstSegPattern>();
        var lines = XedZ.lines(path);
        iter(lines, spec => {
            var field = BlockField.Empty;
            var mode = MachineMode.Default;
            var pattern = new InstSegPattern{
                Form = spec.Form
            };
            patterns.Add(pattern);
            foreach(var line in spec.Lines)
            {                
                if(XedZ.parse(line, out field))
                {
                    switch(field.Name)                
                    {
                        case BlockFieldName.mode_restriction:
                            mode = (MachineMode)field;
                        break;
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
                            pattern.Cells = segs.Array();
                        }
                        break;
                        case BlockFieldName.operands:
                        {
                            var ops = (PatternOps)field;
                            pattern.Operands = sys.alloc<InstSegPattern.Operand>(ops.Count);
                            for(var i=z8; i<ops.Count;i++)
                            {
                                ref var target = ref pattern.Operands[i];
                                ref readonly var op = ref ops[i];
                                target.Index = i;
                                target.Form = spec.Form;
                                target.Name = op.Name;
                                target.Kind = op.Kind;
                                target.SourceExpr = op.SourceExpr;
                                op.Width(out target.Indicator);
                                op.RegLiteral(out target.Register);
                                if(target.Register.IsNonEmpty && !target.Register.IsNonterminal)
                                {
                                    target.BitWidth = XedWidths.width(target.Register);
                                }
                                if(target.Register.IsEmpty && op.Nonterminal(out var nt))
                                {   
                                    target.Register = nt;
                                }
                                if(target.Indicator.IsNonEmpty)
                                {
                                    var wi = XedWidths.describe(target.Indicator);
                                    if(wi.ElementCount > 1 && wi.ElementWidth != 0)
                                        target.SegType = wi.SegType;
                                    if(target.BitWidth == 0)
                                        target.BitWidth = XedWidths.bitwidth(mode,target.Indicator);
                                }                                                                 
                            }
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
        var path =  XedPaths.RuleBlockSource();
        var patterns = bag<InstBlockPattern>();
        var lines = XedZ.lines(path);
        piter(lines.AsParallel(), spec => {
            var fields = list<BlockField>();
            var result = true;
            patterns.Add(XedZ.pattern(spec));
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
