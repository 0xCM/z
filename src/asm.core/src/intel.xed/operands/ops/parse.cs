//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    using K = XedRules.FieldKind;

    partial class XedOps
    {
        public static bool parse(FieldKind field, string value, out FieldValue dst)
        {
            var result = true;
            dst = FieldValue.Empty;
            switch(field)
            {
                case K.AGEN:
                case K.AMD3DNOW:
                case K.ASZ:
                case K.CET:
                case K.CLDEMOTE:
                case K.DF32:
                case K.DF64:
                case K.DUMMY:
                case K.ENCODER_PREFERRED:
                case K.ENCODE_FORCE:
                case K.HAS_MODRM:
                case K.HAS_SIB:
                case K.ILD_F2:
                case K.ILD_F3:
                case K.IMM0:
                case K.IMM0SIGNED:
                case K.IMM1:
                case K.LOCK:
                case K.LZCNT:
                case K.MEM0:
                case K.MEM1:
                case K.MODE_FIRST_PREFIX:
                case K.MODE_SHORT_UD0:
                case K.MODEP5:
                case K.MODEP55C:
                case K.MPXMODE:
                case K.MUST_USE_EVEX:
                case K.NEEDREX:
                case K.NEED_SIB:
                case K.NOREX:
                case K.NO_RETURN:
                case K.NO_SCALE_DISP8:
                case K.REX:
                case K.OSZ:
                case K.OUT_OF_BYTES:
                case K.P4:
                case K.PREFIX66:
                case K.PTR:
                case K.REALMODE:
                case K.RELBR:
                case K.TZCNT:
                case K.UBIT:
                case K.USING_DEFAULT_SEGMENT0:
                case K.USING_DEFAULT_SEGMENT1:
                case K.VEX_C4:
                case K.VEXDEST3:
                case K.VEXDEST4:
                case K.WBNOINVD:
                case K.REXRR:
                case K.SAE:
                case K.BCRC:
                case K.ZEROING:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new(field, b);
                        result = true;
                    }
                }
                break;

                case K.REXW:
                {
                    if(XedParsers.parse(value, out bit b))
                    {
                        dst = new (field, b);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'w')
                    {
                        dst = new (FieldSeg.symbolic(field, 'w'));
                        result = true;
                    }
                }
                break;
                case K.REXR:
                {
                    if(XedParsers.parse(value, out bit x))
                    {
                        dst = new (field,x);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'r')
                    {
                        dst = new (FieldSeg.symbolic(field, 'r'));
                        result = true;
                    }
                }
                break;
                case K.REXX:
                {
                    if(XedParsers.parse(value, out bit x))
                    {
                        dst = new (field,x);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'x')
                    {
                        dst = new (FieldSeg.symbolic(field, 'x'));
                        result = true;
                    }
                }
                break;
                case K.REXB:
                {
                    if(XedParsers.parse(value, out bit x))
                    {
                        dst = new (field, x);
                        result = true;
                    }
                    else if(value.Length == 1 && value[0] == 'b')
                    {
                        dst = new (FieldSeg.symbolic(field, 'b'));
                        result = true;
                    }
                }
                break;

                case K.NELEM:
                case K.ELEMENT_SIZE:
                case K.MEM_WIDTH:
                {
                    if(ushort.TryParse(value, out ushort x))
                    {
                        dst = new (field,x);
                        result = true;
                    }
                }
                break;

                case K.SIBBASE:
                case K.HINT:
                case K.ROUNDC:
                case K.SEG_OVD:
                case K.VEXVALID:
                case K.MOD:
                case K.SIBSCALE:
                case K.EASZ:
                case K.EOSZ:
                case K.FIRST_F2F3:
                case K.LAST_F2F3:
                case K.DEFAULT_SEG:
                case K.MODE:
                case K.REP:
                case K.SMODE:
                case K.VEX_PREFIX:
                case K.VL:
                case K.LLRC:
                case K.MAP:
                case K.SCALE:
                case K.BRDISP_WIDTH:
                case K.DISP_WIDTH:
                case K.ILD_SEG:
                case K.IMM1_BYTES:
                case K.IMM_WIDTH:
                case K.MAX_BYTES:
                case K.MODRM_BYTE:
                case K.NPREFIXES:
                case K.NREXES:
                case K.NSEG_PREFIXES:
                case K.POS_DISP:
                case K.POS_IMM:
                case K.POS_IMM1:
                case K.POS_MODRM:
                case K.POS_NOMINAL_OPCODE:
                case K.POS_SIB:
                case K.NEED_MEMDISP:
                case K.RM:
                case K.SIBINDEX:
                case K.REG:
                case K.VEXDEST210:
                case K.MASK:
                case K.SRM:
                {
                    if(XedParsers.parse(value, out byte b))
                    {
                        dst = new (field,b);
                        result = true;
                    }
                }
                break;

                case K.ESRC:
                {
                    if(HexParser.parse(value, out Hex4 x))
                    {
                        dst = new (field,(byte)x);
                        result = true;
                    }
                }
                break;


                case K.NOMINAL_OPCODE:
                {
                    if(HexParser.parse(value, out Hex8 x))
                    {
                        dst = new (field, x);
                        result = true;
                    }
                }
                break;

                case K.DISP:
                case K.UIMM0:
                case K.UIMM1:
                {
                    result = byte.TryParse(value, out var b);
                    if(result)
                        dst = new (field,b);
                    else
                    {
                        if(XedParsers.IsSeg(value))
                        {
                            if(XedParsers.segdata(value, out var sd))
                            {
                                var type = InstSegTypes.type(sd);
                                if(type.IsNonEmpty)
                                    dst = new (field,type);
                                else
                                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(FieldValue), value));
                            }
                        }
                    }
                }
                break;

                case K.BASE0:
                case K.BASE1:
                case K.INDEX:
                case K.OUTREG:
                case K.SEG0:
                case K.SEG1:
                case K.REG0:
                case K.REG1:
                case K.REG2:
                case K.REG3:
                case K.REG4:
                case K.REG5:
                case K.REG6:
                case K.REG7:
                case K.REG8:
                case K.REG9:
                {
                    if(XedParsers.reg(field, value, out dst))
                        result = true;
                }
                break;
                case K.CHIP:
                {
                    if(XedParsers.parse(value, out ChipCode x))
                    {
                        dst = new (field, (ushort)x);
                        result = true;
                    }
                }
                break;

                case K.ERROR:
                {
                    if(XedParsers.parse(value, out ErrorKind x))
                    {
                        dst = new (field, (ushort)x);
                        result = true;
                    }
                }
                break;

                case K.ICLASS:
                {
                    if(XedParsers.parse(value, out AsmInstKind x))
                    {
                        dst = new (field, (ushort)x);
                        result = true;
                    }
                }
                break;

                case K.BCAST:
                {
                    if(XedParsers.parse(value, out BCastKind kind))
                    {
                        dst = new (field, (byte)kind);
                        result = true;
                    }
                }
                break;
            }

            return result;
        }
    }
}