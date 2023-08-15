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
    public const string TableName = "xed.disasm.detail";

    public const byte FieldCount = 24;

    public uint Seq;

    public uint DocSeq;

    public EncodingId EncodingId;

    public InstructionId InstructionId;

    public MemoryAddress IP;

    public XedInstClass Instruction;

    public AsmHexCode Encoded;

    public Hex8 OpCode;

    public byte PSZ;

    public RexPrefix Rex;

    public VexPrefix Vex;

    public EvexPrefix Evex;

    public ModRm ModRm;

    public Sib Sib;

    public EmptyZero<Disp> Disp;

    public EmptyZero<Imm> Imm;

    public SizeOverride SZOV;

    public NativeSize EASZ;

    public NativeSize EOSZ;

    public AsmExpr Asm;

    public XedInstForm Form;

    public @string SourceName;

    public EncodingOffsets Offsets;

    public OpDetails Ops;

    public int CompareTo(XedDisasmDetailRow src)
    {
        var result = SourceName.CompareTo(src.SourceName);
        if(result == 0)
            result = IP.CompareTo(src.IP);
        return result;
    }

    public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
        AsmColWidths.Seq,
        AsmColWidths.DocSeq,
        AsmColWidths.EncodingId,
        AsmColWidths.InstructionId,
        AsmColWidths.IP,
        AsmColWidths.Mnemonic,
        AsmColWidths.EncodedHex,
        AsmColWidths.Hex8,
        AsmColWidths.Size,
        AsmColWidths.RexPrefx,
        AsmColWidths.VexPrefix,
        AsmColWidths.EvexPrefix,
        AsmColWidths.ModRm,
        AsmColWidths.Sib,
        AsmColWidths.Disp,
        AsmColWidths.Imm,
        AsmColWidths.Size,
        AsmColWidths.EASZ,
        AsmColWidths.EOSZ,
        AsmColWidths.AsmExpr,
        AsmColWidths.InstForm,
        AsmColWidths.OriginName,
        48,
        1};

    public static XedDisasmDetailRow Empty => default;
}
