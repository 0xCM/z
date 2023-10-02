//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedRules;
using static XedModels;

[StructLayout(LayoutKind.Sequential, Pack=1), Record(TableName)]
public record struct XedDisasmDetailRow : IComparable<XedDisasmDetailRow>
{
    const string TableName = "xed.disasm.detail";

    public const byte FieldCount = 24;

    [Render(AsmColWidths.Seq)]
    public uint Seq;

    [Render(AsmColWidths.DocSeq)]
    public uint DocSeq;

    [Render(AsmColWidths.EncodingId)]
    public EncodingId EncodingId;

    [Render(AsmColWidths.InstructionId)]
    public InstructionId InstructionId;

    [Render(AsmColWidths.IP)]
    public MemoryAddress IP;

    [Render(AsmColWidths.Mnemonic)]
    public XedInstClass Instruction;

    [Render(AsmColWidths.EncodedHex)]
    public AsmHexCode Encoded;

    [Render(AsmColWidths.EncodedHex)]
    public Hex8 OpCode;

    [Render(AsmColWidths.Size)]
    public byte PrefixSize;

    [Render(AsmColWidths.PrefixBytes)]
    public ByteBlock8 PrefixBytes;
    
    [Render(AsmColWidths.RexPrefx)]
    public RexPrefix Rex;

    [Render(AsmColWidths.VexPrefix)]
    public VexPrefix Vex;

    [Render(AsmColWidths.EvexPrefix)]
    public EvexPrefix Evex;

    [Render(AsmColWidths.ModRm)]
    public ModRm ModRm;

    [Render(AsmColWidths.Sib)]
    public Sib Sib;

    [Render(AsmColWidths.Disp)]
    public EmptyZero<Disp> Disp;

    [Render(AsmColWidths.Imm)]
    public EmptyZero<Imm> Imm;

    [Render(AsmColWidths.Size)]
    public SizeOverride SZOV;

    [Render(AsmColWidths.EASZ)]
    public NativeSize EASZ;

    [Render(AsmColWidths.EOSZ)]
    public NativeSize EOSZ;

    [Render(AsmColWidths.AsmExpr)]
    public AsmExpr Asm;

    [Render(AsmColWidths.InstForm)]
    public XedInstForm Form;

    [Render(AsmColWidths.OriginName)]
    public @string SourceName;

    [Render(48)]
    public EncodingOffsets Offsets;

    [Render(1)]
    public OpDetails Ops;

    public int CompareTo(XedDisasmDetailRow src)
    {
        var result = SourceName.CompareTo(src.SourceName);
        if(result == 0)
            result = IP.CompareTo(src.IP);
        return result;
    }

    public static XedDisasmDetailRow Empty => default;
}
