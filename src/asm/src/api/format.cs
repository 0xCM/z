//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    partial struct asm
    {
        [Op]
        public static string format(in AsmHexCode src)
        {
            var size = src.Size;
            Span<char> dst = stackalloc char[64];
            var count = HexRender.render(LowerCase, src.Bytes, dst);
            return sys.@string(slice(dst, 0, count));
        }

        public static string format(in EncodingOffsets src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = Z0.text.emitter();
            dst.Append(Chars.LBrace);
            dst.AppendFormat("{0}={1}", "opcode", src.OpCode);
            if(src.ModRm > 0)
                dst.AppendFormat(", {0}={1}", "modrm", src.ModRm);
            if(src.Sib > 0)
                dst.AppendFormat(", {0}={1}", "sib",  src.Sib);
            if(src.Disp > 0)
                dst.AppendFormat(", {0}={1}", "disp", src.Disp);
            if(src.Imm0 > 0)
                dst.AppendFormat(", {0}={1}", "imm0", src.Imm0);
            if(src.Imm1 > 0)
                dst.AppendFormat(", {0}={1}", "imm1", src.Imm1);
            dst.Append(Chars.RBrace);
            return dst.Emit();
        }
    }
}