//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct InstDetail : IComparable<InstDetail>
        {
            public uint Seq;

            public uint DocSeq;

            public Hex32 OriginId;

            public @string OriginName;

            public EncodingId EncodingId;

            public InstructionId InstructionId;

            public MemoryAddress IP;

            public AsmInstClass InstClass;

            public AsmHexCode Encoded;

            public Hex8 OpCode;

            public byte PSZ;

            public RexPrefix Rex;

            public VexPrefix Vex;

            public EvexPrefix Evex;

            public ModRm ModRm;

            public Sib Sib;

            public Disp Disp;

            public Imm Imm;

            public SizeOverride SZOV;

            public NativeSize EASZ;

            public NativeSize EOSZ;

            public AsmExpr Asm;

            public InstForm InstForm;

            public @string SourceName;

            public EncodingOffsets Offsets;

            public Index<InstOpDetail> Operands;

            public AsmRowKey Key
            {
                [MethodImpl(Inline)]
                get => (Seq,DocSeq,OriginId);
            }

            public int CompareTo(InstDetail src)
            {
                var result = SourceName.CompareTo(src.SourceName);
                if(result == 0)
                    result = IP.CompareTo(src.IP);
                return result;
            }
        }
    }
}