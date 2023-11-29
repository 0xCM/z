//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedRules;
using static sys;

public ref struct AsmEncodingCase
{
    public readonly ReadOnlySpan<char> Asm;

    public readonly ReadOnlySpan<byte> Code;
    
    public AsmEncodingCase(string asm, ReadOnlySpan<byte> code)
    {
        Asm = asm;
        Code = code;
    }

    public static AsmEncodingCase Empty => default;
}

public class EvexCases
{
    static ReadOnlySpan<byte> VmovDqa64_0 => new byte[]{0x62,0xf1,0xfd,0x48,0x6f,0x0a};
    
    static ReadOnlySpan<byte> VmovDqa64_1 => new byte[]{0x62,0xd1,0xfd,0x48,0x6f,0x10};
    
    static ReadOnlySpan<byte> VmovDqa64_2 => new byte[]{0x62,0xd1,0xfd,0x48,0x6f,0x19};

    static ReadOnlySpan<byte> VmovDqa64_3 => new byte[]{0x62,0x01,0xfd,0x48,0x6f,0xf5};

    static ReadOnlySpan<byte> Vpcmpgtw_1 => new byte[]{0x62, 0xf1, 0x7d, 0x28, 0x65, 0x02};
    /*
	vmovdqa64 zmm1, zmmword ptr [rdx] # encoding: [0x62,0xf1,0xfd,0x48,0x6f,0x0a]
	vmovdqa64 zmm2, zmmword ptr [r8]  # encoding: [0x62,0xd1,0xfd,0x48,0x6f,0x10]
	vmovdqa64 zmm3, zmmword ptr [r9]  # encoding: [0x62,0xd1,0xfd,0x48,0x6f,0x19]
	vmovdqa64 zmm30, zmm29 # encoding: [0x62,0x01,0xfd,0x48,0x6f,0xf5]
    */
    public static AsmEncodingCase @case(uint index) =>
        index switch {
            0 => new("vmovdqa64 zmm1, zmmword ptr [rdx]", VmovDqa64_0),
            1 => new("vmovdqa64 zmm2, zmmword ptr [r8]", VmovDqa64_1),
            2 => new("vmovdqa64 zmm3, zmmword ptr [r9]", VmovDqa64_2),
            3 => new("vmovdqa64 zmm30, zmm29", VmovDqa64_3),
            4 => new("vpcmpgtw k0, ymm0, ymmword ptr [rdx]", Vpcmpgtw_1),
            _ => AsmEncodingCase.Empty
        };

    public const uint Count = 5;
}
partial class XedCmd
{
    static void render(AsmEncodingCase @case, BpInfo pattern, ITextEmitter dst)
    {
        dst.AppendLine($"{@case.Asm}");
        dst.AppendLine($"{@case.Code.FormatHex()}");
        dst.AppendLine($"{pattern.Expr}");
        dst.AppendLine(BitPatterns.bitstring(pattern.Expr, @as<uint>(@case.Code)));
        var bitstring = @span(@case.Code.FormatBits());
        var segs = pattern.Segs;
        var offset = 0u;
        for(var i=0; i<segs.Count; i++)
        {
            ref readonly var seg = ref segs[i];
            var content = slice(bitstring, offset, seg.Width);
            offset += seg.Width;
            if(i!= 0)
                dst.Append(Chars.Space);
            dst.Append(content);
        }
        dst.AppendLine();
    }
    [CmdOp("asm/check/evex")]
    void CheckEvex(CmdArgs args)
    {
        var dst = text.emitter();

        var pattern = AsmBitPatterns.Evex;
        for(var i=0u; i<EvexCases.Count; i++)
        {
            render(EvexCases.@case(i), pattern, dst);
            dst.AppendLine();

        }
        Channel.Row(dst.Emit());

    }

    [CmdOp("xed/check/cells")]
    void CheckXedCells()
    {
        var dst = text.emitter();
        var tables = XedTables.CellTables();
        foreach(var table in tables.View)
        {
            var fields = table.Rows.SelectMany(x => x.Cells).Where(x => x.IsCellExpr).Select(x => x.Value.AsCellExpr().Field).Distinct();
            Channel.Row($"{table.Identity}: {fields.Delimit()}");
            
        }
    }

    [CmdOp("xed/check/fields")]
    void CheckXedFields()
    {
        const string ReportFormat = "{0,-8} | {1,-64} | {2,-16} | {3,-16} | {4}";
        var headers = new string[]{"Seq", "Form", "Field", "Kind", "Value"};
        var instructions = XedTables.Instructions();
        var fields = XedFields.allocate();    
        var report = text.emitter();
        report.AppendLineFormat(ReportFormat, headers);
        Span<FieldKind> members = stackalloc FieldKind[128];
        var counter = 0u;
        foreach(var def in instructions.Defs)
        {
            fields.Clear();
            members.Clear();
            var formexpr = $"{def.FormIndex} {def.Form}";
            var cells = def.Pattern.Body;
            var layout = EmptyString;
            for(var i=0; i<cells.Count; i++)
            {
                ref readonly var cell = ref cells[i];

                if(cell.Field == 0 || cell.CellKind == RuleCellKind.InstSeg)
                {
                    if(nonempty(layout))
                        layout += " ";

                    layout += $"{cell.Format()}";
                }
                else
                    report.AppendLineFormat(ReportFormat, counter++, formexpr, cell.Field, cell.CellKind, cell.Format());
            }
            if(nonempty(layout))
                report.AppendLineFormat(ReportFormat, counter++, formexpr, "", "Layout", layout);

            for(var i=0; i<def.Operands.Count; i++)
            {
                ref readonly var op = ref def.Operands[i];
                report.AppendLineFormat(ReportFormat, counter++, formexpr, "Operand", i, op.Format());
            }

            report.AppendLine();
            // var set = XedFields.pack(cells, fields);
            // var count = set.Members(members);
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var kind = ref members[i];
            //     var value = fields[kind];
            //     Channel.Row($"{kind}:{value}");                
            // }
        }
        Channel.FileEmit(report.Emit(), XedPaths.Imports().Path("xed.instblock.cells", FileKind.Csv));
    }

    XedImport XedImport => Wf.XedImport();

    [CmdOp("xed/check/bits")]
    void CheckBitfields()
    {
        // var pattern = BitPatterns.def<RexPrefix>();
        // var dst = text.emitter();
        // pattern.Symbolic(dst);
        // Channel.Row(dst.Emit());

        var a = num3.One;
        for(var i=0; i<50; i++)
        {
            a++;
            Channel.Row($"{(byte)a} | {a}");
        }       
    }


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
        var rules = XedTables.Instructions();
        XedImport.Emit(rules);
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}