//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct EncodingExtract
    {
        public AsmHexCode Code;

        public EncodingOffsets Offsets;

        public Hex8 OpCode;

        public ModRm ModRm;

        public Sib Sib;

        public Imm Imm;

        public Imm Imm1;

        public Disp Disp;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Offsets.IsEmpty;
        }

        public static EncodingExtract Empty
        {
            get
            {
                var dst = default(EncodingExtract);
                dst.Offsets = EncodingOffsets.Empty;
                return dst;
            }
        }

        public string Format()
            => XedRender.format(this);

        public override string ToString()
            => Format();
    }
}
