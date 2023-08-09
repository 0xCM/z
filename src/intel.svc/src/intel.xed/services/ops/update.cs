//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static sys;

    using K = XedRules.FieldKind;

    partial class XedOps
    {
        public static ref XedOperandState update(in Fields src, ReadOnlySpan<FieldKind> fields, ref XedOperandState dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
                update(src[skip(fields,i)], ref dst);
            return ref dst;
        }

        public static Dictionary<FieldKind,FieldValue> update(Index<FieldValue> src, ref XedOperandState state)
        {
            update(src.View, ref state);
            return src.Map(x => (x.Field, x)).ToDictionary();
        }

        static ref XedOperandState update(ReadOnlySpan<FieldValue> src, ref XedOperandState dst)
        {
            for(var i=0; i<src.Length; i++)
                update(skip(src,i), ref dst);
            return ref dst;
        }

        static ref XedOperandState update(in FieldValue src, ref XedOperandState dst)
        {
            var result = Outcome.Success;
            switch(src.Field)
            {
                case K.AMD3DNOW:
                    dst.AMD3DNOW = src;
                break;

                case K.ASZ:
                    dst.ASZ = src;
                break;

                case K.BASE0:
                    dst.BASE0 = src.ToReg();
                break;

                case K.BASE1:
                    dst.BASE1 = src.ToReg();
                break;

                case K.BCAST:
                    dst.BCAST = src.ToByte();
                break;

                case K.BCRC:
                    dst.BCRC = src;
                break;

                case K.RELBR:
                    dst.RELBR = src;
                break;

                case K.BRDISP_WIDTH:
                    dst.BRDISP_WIDTH = src.ToByte();
                break;

                case K.CET:
                    dst.CET = src;
                break;

                case K.CHIP:
                    dst.CHIP = src;
                break;

                case K.CLDEMOTE:
                    dst.CLDEMOTE = src;
                break;

                case K.DEFAULT_SEG:
                    dst.DEFAULT_SEG = src.ToByte();
                break;

                case K.DF32:
                    dst.DF32 = src;
                break;

                case K.DF64:
                    dst.DF64 = src;
                break;

                case K.DISP:
                    dst.DISP = src;
                break;

                case K.DISP_WIDTH:
                    dst.DISP_WIDTH = src.ToByte();
                break;

                case K.DUMMY:
                    dst.DUMMY = src;
                break;

                case K.EASZ:
                    dst.EASZ = src.ToByte();
                break;

                case K.ELEMENT_SIZE:
                    dst.ELEMENT_SIZE = src.ToByte();
                break;

                case K.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = src;
                break;

                case K.ENCODE_FORCE:
                    dst.ENCODE_FORCE = src;
                break;

                case K.EOSZ:
                    dst.EOSZ = src.ToByte();
                break;

                case K.ESRC:
                    dst.ESRC = src.ToByte();
                break;

                case K.FIRST_F2F3:
                    dst.FIRST_F2F3 = src.ToByte();
                break;

                case K.HAS_MODRM:
                    dst.HAS_MODRM = src;
                break;

                case K.HAS_SIB:
                    dst.HAS_SIB = src;
                break;

                case K.HINT:
                    dst.HINT  = src.ToByte();
                break;

                case K.ICLASS:
                    dst.ICLASS = src;
                break;

                case K.ILD_F2:
                    dst.ILD_F2 = src;
                break;

                case K.ILD_F3:
                    dst.ILD_F3 = src;
                break;

                case K.ILD_SEG:
                    dst.ILD_SEG = src.ToByte();
                break;

                case K.IMM0:
                    dst.IMM0 = src;
                break;

                case K.IMM0SIGNED:
                    dst.IMM0SIGNED = src;
                break;

                case K.IMM1:
                    dst.IMM1 = src;
                break;

                case K.IMM1_BYTES:
                    dst.IMM1_BYTES = src.ToByte();
                break;

                case K.IMM_WIDTH:
                    dst.IMM_WIDTH = src.ToByte();
                break;

                case K.INDEX:
                    dst.INDEX = src.ToReg();
                break;

                case K.LAST_F2F3:
                    dst.LAST_F2F3 = src.ToByte();
                break;

                case K.LLRC:
                    dst.LLRC = src.ToByte();
                break;

                case K.LOCK:
                    dst.LOCK = src;
                break;

                case K.LZCNT:
                    dst.LZCNT = src;
                break;

                case K.MAP:
                    dst.MAP = src.ToByte();
                break;

                case K.MASK:
                    dst.MASK = src.ToBit();
                break;

                case K.MAX_BYTES:
                    dst.MAX_BYTES = src.ToByte();
                break;

                case K.MEM_WIDTH:
                    dst.MEM_WIDTH = src.ToByte();
                break;

                case K.MOD:
                    dst.MOD = src.ToByte();
                break;

                case K.REG:
                    dst.REG = src.ToByte();
                break;

                case K.MODRM_BYTE:
                    dst.MODRM_BYTE = src.ToHex8();
                break;

                case K.MODE:
                    dst.MODE = src.ToByte();
                break;

                case K.MODEP5:
                    dst.MODEP5 = src;
                break;

                case K.MODEP55C:
                    dst.MODEP55C = src;
                break;

                case K.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = src;
                break;

                case K.MPXMODE:
                    dst.MPXMODE = src;
                break;

                case K.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = src;
                break;

                case K.NEEDREX:
                    dst.NEEDREX = src;
                break;

                case K.NEED_MEMDISP:
                    dst.NEED_MEMDISP = src.ToByte();
                break;

                case K.NEED_SIB:
                    dst.NEED_SIB = src;
                break;

                case K.NELEM:
                    dst.NELEM = src.ToWord();
                break;

                case K.NOMINAL_OPCODE:
                    dst.NOMINAL_OPCODE = src.ToByte();
                break;

                case K.NOREX:
                    dst.NOREX = src;
                break;

                case K.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = src;
                break;

                case K.NPREFIXES:
                    dst.NPREFIXES = src.ToByte();
                break;

                case K.NREXES:
                    dst.NREXES = src.ToByte();
                break;

                case K.NSEG_PREFIXES:
                    dst.NSEG_PREFIXES = src.ToByte();
                break;

                case K.OSZ:
                    dst.OSZ = src;
                break;

                case K.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = src;
                break;

                case K.P4:
                    dst.P4 = src;
                break;

                case K.POS_DISP:
                    dst.POS_DISP = src.ToByte();
                break;

                case K.POS_IMM:
                    dst.POS_IMM = src.ToByte();
                break;

                case K.POS_IMM1:
                    dst.POS_IMM1 = src.ToByte();
                break;

                case K.POS_MODRM:
                    dst.POS_MODRM = src.ToByte();
                break;

                case K.POS_NOMINAL_OPCODE:
                    dst.POS_NOMINAL_OPCODE = src.ToByte();
                break;

                case K.POS_SIB:
                    dst.POS_SIB = src.ToByte();
                break;

                case K.PREFIX66:
                    dst.PREFIX66 = 1;
                break;

                case K.PTR:
                    dst.PTR = 1;
                break;

                case K.REALMODE:
                    dst.REALMODE = 1;
                break;

                case K.OUTREG:
                    dst.OUTREG = src.ToReg();
                break;

                case K.REG0:
                    dst.REG0 = src.ToReg();
                break;

                case K.REG1:
                    dst.REG1 = src.ToReg();
                break;

                case K.REG2:
                    dst.REG2 = src.ToReg();
                break;

                case K.REG3:
                    dst.REG3 = src.ToReg();
                break;

                case K.REG4:
                    dst.REG4  = src.ToReg();
                break;

                case K.REG5:
                    dst.REG5 = src.ToReg();
                break;

                case K.REG6:
                    dst.REG6 = src.ToReg();
                break;

                case K.REG7:
                    dst.REG7 = src.ToReg();
                break;

                case K.REG8:
                    dst.REG8 = src.ToReg();
                break;

                case K.REG9:
                    dst.REG9 = src.ToReg();
                break;

                case K.REP:
                    dst.REP = src.ToByte();
                break;

                case K.REX:
                    dst.REX = src;
                break;

                case K.REXB:
                    dst.REXB = src;
                break;

                case K.REXR:
                    dst.REXR = src;
                break;

                case K.REXRR:
                    dst.REXRR = src;
                break;

                case K.REXW:
                    dst.REXW = src;
                break;

                case K.REXX:
                    dst.REXX = src;
                break;

                case K.RM:
                    dst.RM = src.ToByte();
                break;

                case K.ROUNDC:
                    dst.ROUNDC = src.ToByte();
                break;

                case K.SAE:
                    dst.SAE = src;
                break;

                case K.SCALE:
                    dst.SCALE = src.ToByte();
                break;

                case K.SEG0:
                    dst.SEG0 = src.ToReg();
                break;

                case K.SEG1:
                    dst.SEG1 = src.ToReg();
                break;

                case K.SEG_OVD:
                    dst.SEG_OVD = src.ToByte();
                break;

                case K.SIBBASE:
                    dst.SIBBASE = src.ToByte();
                break;

                case K.SIBINDEX:
                    dst.SIBINDEX = src.ToByte();
                break;

                case K.SIBSCALE:
                    dst.SIBSCALE = src.ToByte();
                break;

                case K.SMODE:
                    dst.SMODE = src.ToByte();
                    break;

                case K.SRM:
                    dst.SRM = src.ToByte();
                break;

                case K.TZCNT:
                    dst.TZCNT = src;
                break;

                case K.UBIT:
                    dst.UBIT = src;
                break;

                case K.UIMM0:
                    dst.UIMM0 = src;
                break;

                case K.UIMM1:
                    dst.UIMM1 = src;
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = src;
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = src;
                break;

                case K.VEXDEST210:
                    dst.VEXDEST210 = src.ToByte();
                break;

                case K.VEXDEST3:
                    dst.VEXDEST3 = src;
                break;

                case K.VEXDEST4:
                    dst.VEXDEST4 = src;
                break;

                case K.VEXVALID:
                    dst.VEXVALID = src.ToByte();
                break;

                case K.VEX_C4:
                    dst.VEX_C4 = src;
                break;

                case K.VEX_PREFIX:
                    dst.VEX_PREFIX = src.ToByte();
                break;

                case K.VL:
                    dst.VL = src.ToByte();
                break;

                case K.WBNOINVD:
                    dst.WBNOINVD = src;
                break;

                case K.ZEROING:
                    dst.ZEROING = src;
                break;

                case K.MEM0:
                    dst.MEM0 = src;
                break;

                case K.MEM1:
                    dst.MEM1 = src;
                break;

                case K.AGEN:
                    dst.AGEN = src;
                break;
            }

            return ref dst;
        }

        static ref XedOperandState update(in Field src, ref XedOperandState dst)
        {
            switch(src.Kind)
            {
                case K.AMD3DNOW:
                    dst.AMD3DNOW = src;
                break;

                case K.ASZ:
                    dst.ASZ = src;
                break;

                case K.BASE0:
                    dst.BASE0 = src;
                break;

                case K.BASE1:
                    dst.BASE1 = src;
                break;

                case K.BCAST:
                    dst.BCAST = src;
                break;

                case K.BCRC:
                    dst.BCRC = src;
                break;

                case K.RELBR:
                    dst.RELBR = src;
                break;

                case K.BRDISP_WIDTH:
                    dst.BRDISP_WIDTH = src;
                break;

                case K.CET:
                    dst.CET = src;
                break;

                case K.CHIP:
                    dst.CHIP = src;
                break;

                case K.CLDEMOTE:
                    dst.CLDEMOTE = src;
                break;

                case K.DEFAULT_SEG:
                    dst.DEFAULT_SEG = src;
                break;

                case K.DF32:
                    dst.DF32 = src;
                break;

                case K.DF64:
                    dst.DF64 = src;
                break;

                case K.DISP:
                    dst.DISP = src;
                break;

                case K.DISP_WIDTH:
                    dst.DISP_WIDTH = src;
                break;

                case K.DUMMY:
                    dst.DUMMY = src;
                break;

                case K.EASZ:
                    dst.EASZ = src;
                break;

                case K.ELEMENT_SIZE:
                    dst.ELEMENT_SIZE = src;
                break;

                case K.ENCODER_PREFERRED:
                    dst.ENCODER_PREFERRED = src;
                break;

                case K.ENCODE_FORCE:
                    dst.ENCODE_FORCE = src;
                break;

                case K.EOSZ:
                    dst.EOSZ = src;
                break;

                case K.ESRC:
                    dst.ESRC = src;
                break;

                case K.FIRST_F2F3:
                    dst.FIRST_F2F3 = src;
                break;

                case K.HAS_MODRM:
                    dst.HAS_MODRM = src;
                break;

                case K.HAS_SIB:
                    dst.HAS_SIB = src;
                break;

                case K.HINT:
                    dst.HINT = src;
                break;

                case K.ICLASS:
                    dst.ICLASS = src;
                break;

                case K.ILD_F2:
                    dst.ILD_F2 = src;
                break;

                case K.ILD_F3:
                    dst.ILD_F3 = src;
                break;

                case K.ILD_SEG:
                    dst.ILD_SEG = src;
                break;

                case K.IMM0:
                    dst.IMM0 = src;
                break;

                case K.IMM0SIGNED:
                    dst.IMM0SIGNED = src;
                break;

                case K.IMM1:
                    dst.IMM1 = src;
                break;

                case K.IMM1_BYTES:
                    dst.IMM1_BYTES = src;
                break;

                case K.IMM_WIDTH:
                    dst.IMM_WIDTH = src;
                break;

                case K.INDEX:
                    dst.INDEX = src;
                break;

                case K.LAST_F2F3:
                    dst.LAST_F2F3 = src;
                break;

                case K.LLRC:
                    dst.LLRC = src;
                break;

                case K.LOCK:
                    dst.LOCK = src;
                break;

                case K.LZCNT:
                    dst.LZCNT = src;
                break;

                case K.MAP:
                    dst.MAP = src;
                break;

                case K.MASK:
                    dst.MASK = src;
                break;

                case K.MAX_BYTES:
                    dst.MAX_BYTES = src;
                break;

                case K.MEM_WIDTH:
                    dst.MEM_WIDTH = src;
                break;

                case K.MOD:
                    dst.MOD = src;
                break;

                case K.REG:
                    dst.REG = src;
                break;

                case K.MODRM_BYTE:
                    dst.MODRM_BYTE = src;
                break;

                case K.MODE:
                    dst.MODE = src;
                break;

                case K.MODEP5:
                    dst.MODEP5 = src;
                break;

                case K.MODEP55C:
                    dst.MODEP55C = src;
                break;

                case K.MODE_FIRST_PREFIX:
                    dst.MODE_FIRST_PREFIX = src;
                break;

                case K.MPXMODE:
                    dst.MPXMODE = src;
                break;

                case K.MUST_USE_EVEX:
                    dst.MUST_USE_EVEX = src;
                break;

                case K.NEEDREX:
                    dst.NEEDREX = src;
                break;

                case K.NEED_MEMDISP:
                    dst.NEED_MEMDISP = src;
                break;

                case K.NEED_SIB:
                    dst.NEED_SIB = src;
                break;

                case K.NELEM:
                    dst.NELEM = src;
                break;

                case K.NOMINAL_OPCODE:
                    dst.NOMINAL_OPCODE = src;
                break;

                case K.NOREX:
                    dst.NOREX = src;
                break;

                case K.NO_SCALE_DISP8:
                    dst.NO_SCALE_DISP8 = src;
                break;

                case K.NPREFIXES:
                    dst.NPREFIXES = src;
                break;

                case K.NREXES:
                    dst.NREXES = src;
                break;

                case K.NSEG_PREFIXES:
                    dst.NSEG_PREFIXES = src;
                break;

                case K.OSZ:
                    dst.OSZ = src;
                break;

                case K.OUT_OF_BYTES:
                    dst.OUT_OF_BYTES = src;
                break;

                case K.P4:
                    dst.P4 = src;
                break;

                case K.POS_DISP:
                    dst.POS_DISP = src;;
                break;

                case K.POS_IMM:
                    dst.POS_IMM = src;
                break;

                case K.POS_IMM1:
                    dst.POS_IMM1 = src;
                break;

                case K.POS_MODRM:
                    dst.POS_MODRM = src;
                break;

                case K.POS_NOMINAL_OPCODE:
                    dst.POS_NOMINAL_OPCODE = src;
                break;

                case K.POS_SIB:
                    dst.POS_SIB = src;
                break;

                case K.PREFIX66:
                    dst.PREFIX66 = 1;
                break;

                case K.PTR:
                    dst.PTR = 1;
                break;

                case K.REALMODE:
                    dst.REALMODE = 1;
                break;

                case K.OUTREG:
                    dst.OUTREG = src;
                break;

                case K.REG0:
                    dst.REG0 = src;
                break;

                case K.REG1:
                    dst.REG1 = src;
                break;

                case K.REG2:
                    dst.REG2 = src;
                break;

                case K.REG3:
                    dst.REG3 = src;
                break;

                case K.REG4:
                    dst.REG4 = src;
                break;

                case K.REG5:
                    dst.REG5 = src;
                break;

                case K.REG6:
                    dst.REG6 = src;
                break;

                case K.REG7:
                    dst.REG7 = src;
                break;

                case K.REG8:
                    dst.REG8 = src;
                break;

                case K.REG9:
                    dst.REG9 = src;
                break;

                case K.REP:
                    dst.REP = src;
                break;

                case K.REX:
                    dst.REX = src;
                break;

                case K.REXB:
                    dst.REXB = src;
                break;

                case K.REXR:
                    dst.REXR = src;
                break;

                case K.REXRR:
                    dst.REXRR = src;
                break;

                case K.REXW:
                    dst.REXW = src;
                break;

                case K.REXX:
                    dst.REXX = src;
                break;

                case K.RM:
                    dst.RM = src;
                break;

                case K.ROUNDC:
                    dst.ROUNDC = src;
                break;

                case K.SAE:
                    dst.SAE = src;
                break;

                case K.SCALE:
                    dst.SCALE = src;
                break;

                case K.SEG0:
                    dst.SEG0 = src;
                break;

                case K.SEG1:
                    dst.SEG1 = src;
                break;

                case K.SEG_OVD:
                    dst.SEG_OVD = src;
                break;

                case K.SIBBASE:
                    dst.SIBBASE = src;
                break;

                case K.SIBINDEX:
                    dst.SIBINDEX = src;
                break;

                case K.SIBSCALE:
                    dst.SIBSCALE = src;
                break;

                case K.SMODE:
                    dst.SMODE = src;
                    break;

                case K.SRM:
                    dst.SRM = src;
                break;

                case K.TZCNT:
                    dst.TZCNT = src;
                break;

                case K.UBIT:
                    dst.UBIT = src;
                break;

                case K.UIMM0:
                    dst.UIMM0 = src;
                break;

                case K.UIMM1:
                    dst.UIMM1 = src;
                break;

                case K.USING_DEFAULT_SEGMENT0:
                    dst.USING_DEFAULT_SEGMENT0 = src;
                break;

                case K.USING_DEFAULT_SEGMENT1:
                    dst.USING_DEFAULT_SEGMENT1 = src;
                break;

                case K.VEXDEST210:
                    dst.VEXDEST210 = src;
                break;

                case K.VEXDEST3:
                    dst.VEXDEST3 = src;
                break;

                case K.VEXDEST4:
                    dst.VEXDEST4 = src;
                break;

                case K.VEXVALID:
                    dst.VEXVALID = src;
                break;

                case K.VEX_C4:
                    dst.VEX_C4 = src;
                break;

                case K.VEX_PREFIX:
                    dst.VEX_PREFIX = src;
                break;

                case K.VL:
                    dst.VL = src;
                break;

                case K.WBNOINVD:
                    dst.WBNOINVD = src;
                break;

                case K.ZEROING:
                    dst.ZEROING = src;
                break;

                case K.MEM0:
                    dst.MEM0 = src;
                break;

                case K.MEM1:
                    dst.MEM1 = src;
                break;

                case K.AGEN:
                    dst.AGEN = src;
                break;

            }
            return ref dst;
        }
    }
}