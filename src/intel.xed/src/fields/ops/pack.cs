//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;
using static sys;

using K = XedRules.FieldKind;
using CK = XedRules.RuleCellKind;

partial class XedFields
{    
    public static uint pack(InstFieldValues src, Fields dst, bool clear = true)
    {
        if(clear)
            dst.Clear();

        var result = Outcome.Success;
        var counter = 0u;
        var count = src.Count;
        var keys = src.Keys.Array();
        for(var i=0; i<count; i++)
        {
            var name = skip(keys,i);
            var value = src[name];
            result = XedParsers.parse(name, out K kind);
            result.Require();
            dst.Update(pack(value, kind));
            counter++;
        }
        return counter;
    }

    [Op]
    public static XedFieldPack pack(string src, K kind)
    {
        var result = true;
        var dst = XedFieldPack.Empty;
        dst.Field = kind;
        switch(kind)
        {
            case K.AMD3DNOW:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.ASZ:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.BASE0:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.BASE1:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.BCAST:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.BCRC:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.RELBR:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.BRDISP_WIDTH:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.CET:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.CHIP:
                result = XedParsers.parse(src, out dst.Chip);
            break;

            case K.CLDEMOTE:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.DEFAULT_SEG:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.DF32:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.DF64:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.DISP_WIDTH:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.DUMMY:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.EASZ:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.ELEMENT_SIZE:
                result = DataParser.parse(src, out dst.Word);
            break;

            case K.ENCODER_PREFERRED:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.ENCODE_FORCE:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.EOSZ:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.ESRC:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.FIRST_F2F3:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.HAS_MODRM:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.HAS_SIB:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.HINT:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.ICLASS:
                result = XedParsers.parse(src, out dst.Class);
            break;

            case K.ILD_F2:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.ILD_F3:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.ILD_SEG:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.IMM0:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.IMM0SIGNED:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.IMM1:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.IMM1_BYTES:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.IMM_WIDTH:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.INDEX:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.LAST_F2F3:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.LLRC:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.LOCK:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.LZCNT:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.MAP:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.MASK:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.MAX_BYTES:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.MEM_WIDTH:
                result = DataParser.parse(src, out dst.Word);
            break;

            case K.MEM0:
                dst.Bit = 1;
                result = true;
            break;

            case K.MEM1:
                dst.Bit = 1;
                result = true;
            break;

            case K.MOD:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.REG:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.MODRM_BYTE:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.MODE:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.MODEP5:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.MODEP55C:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.MODE_FIRST_PREFIX:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.MPXMODE:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.MUST_USE_EVEX:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.NEEDREX:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.NEED_MEMDISP:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.NEED_SIB:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.NELEM:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.NOMINAL_OPCODE:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.NOREX:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.NO_SCALE_DISP8:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.NPREFIXES:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.NREXES:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.NSEG_PREFIXES:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.OSZ:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.OUT_OF_BYTES:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.P4:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.POS_DISP:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.POS_IMM:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.POS_IMM1:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.POS_MODRM:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.POS_NOMINAL_OPCODE:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.POS_SIB:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.PREFIX66:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.PTR:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.REALMODE:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.OUTREG:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG0:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG1:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG2:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG3:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG4:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG5:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG6:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG7:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG8:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REG9:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.REP:
                result = DataParser.parse(src, out dst.Byte);
            break;

            case K.REX:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.REXB:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.REXR:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.REXRR:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.REXW:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.REXX:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.RM:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.ROUNDC:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.SAE:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.SCALE:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.SEG0:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.SEG1:
                result = XedParsers.parse(src, out dst.Reg);
            break;

            case K.SEG_OVD:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.SIBBASE:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.SIBINDEX:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.SIBSCALE:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.SMODE:
                result = XedParsers.parse(src, out dst.Byte);
                break;

            case K.SRM:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.TZCNT:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.UBIT:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.USING_DEFAULT_SEGMENT0:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.USING_DEFAULT_SEGMENT1:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.VEXDEST210:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.VEXDEST3:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.VEXDEST4:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.VEXVALID:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.VEX_C4:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.VEX_PREFIX:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.VL:
                result = XedParsers.parse(src, out dst.Byte);
            break;

            case K.WBNOINVD:
                result = XedParsers.parse(src, out dst.Bit);
            break;

            case K.ZEROING:
                result = XedParsers.parse(src, out dst.Bit);
            break;
        }

        if(!result)
            Errors.Throw(AppMsg.ParseFailure.Format(kind.ToString(), src));

        return dst;
    }
}