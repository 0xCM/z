//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedRules;
using static XedModels;
using static XedRender;
using static sys;

using K = XedRules.FieldKind;

public class XedFieldRender
{
    public static XedFieldRender create()
        => new ();

    public const string Columns = "{0,-24} | {1}";

    public const sbyte ColWidth = 24;

    public const byte Count = 128;

    readonly Index<FieldKind,Func<ushort,string>> Functions;

    public XedFieldRender()
    {
        Functions = alloc<Func<ushort,string>>(Count);
        init(this);
    }

    public ref Func<ushort,string> this[FieldKind kind]
    {
        [MethodImpl(Inline)]
        get => ref Functions[kind];
    }

    static void init(XedFieldRender r)
    {
        for(var i=0; i<XedFieldRender.Count; i++)
        {
            var kind = (FieldKind)i;
            switch(kind)
            {
                case K.AGEN:
                    r.Functions[kind] = x => x.ToString();
                break;

                case K.ASZ:
                    r.Functions[kind] = x => format((ASZ)x);
                break;

                case K.BCAST:
                    r.Functions[kind] = x => format((BroadcastKind)x);
                break;

                case K.DISP:
                case K.DF32:
                case K.DF64:
                case K.REX:
                case K.CET:
                case K.CLDEMOTE:
                case K.BCRC:
                    r.Functions[kind] = x => ((bit)x).Format();
                break;

                case K.DISP_WIDTH:
                case K.BRDISP_WIDTH:
                    r.Functions[kind] = x => format((DispWidth)x);
                break;

                case K.CHIP:
                    r.Functions[kind] = x => format((ChipCode)x);
                break;

                case K.MODE:
                    r.Functions[kind] = x => format((MachineMode)x);
                break;

                case K.SMODE:
                    r.Functions[kind] = x => format((SMODE)x,DataFormatCode.BitWidth);
                break;

                case K.EASZ:
                    r.Functions[kind] = x => format((EASZ)x, DataFormatCode.BitWidth);
                break;

                case K.EOSZ:
                    r.Functions[kind] = x => format((EOSZ)x, DataFormatCode.BitWidth);
                break;

                case K.ESRC:
                    r.Functions[kind] = x => format((ESRC)x);
                break;

                case K.ICLASS:
                    r.Functions[kind] = x => format((XedInstClass)x);
                break;

                case K.MASK:
                    r.Functions[kind] = x => format((MaskReg)x);
                break;

                case K.OSZ:
                    r.Functions[kind] = x => format((OSZ)x, DataFormatCode.BitWidth);
                break;

                case K.MAP:
                    r.Functions[kind] = (x => format((byte)x));
                break;

                case K.ELEMENT_SIZE:
                    r.Functions[kind] = x => format((ushort)x);
                break;

                case K.MODRM_BYTE:
                    r.Functions[kind] = x => string.Format("0x{0:X2} [{1}]", (byte)x, ((ModRm)x).Bitstring());
                break;

                case K.NOMINAL_OPCODE:
                    r.Functions[kind] = x => format((Hex8)x);
                break;

                case K.REP:
                    r.Functions[kind] = x => format((XedModels.RepPrefix)x);
                break;

                case K.REXB:
                case K.REXW:
                case K.REXR:
                case K.REXX:
                    r.Functions[kind] = x => format((uint1)x);
                break;

                case K.SIBSCALE:
                case K.MOD:
                    r.Functions[kind] = x => format((uint2)x);
                break;

                case K.SIBBASE:
                case K.REG:
                    r.Functions[kind] = x => format((num3)x);
                break;

                case K.SIBINDEX:
                case K.RM:
                    r.Functions[kind] = x => format((num3)x);
                break;

                case K.SRM:
                    r.Functions[kind] = x => format((num3)x);
                break;

                case K.VEXDEST210:
                    r.Functions[kind] = x => format((num3)x);
                break;
                case K.VEXDEST4:
                case K.VEXDEST3:
                    r.Functions[kind] = x => format((bit)x);
                break;
                case K.VEXVALID:
                    r.Functions[kind] = x => format((VexValid)x);
                break;
                case K.VEX_PREFIX:
                    r.Functions[kind] = x => format((XedVexKind)x);
                break;
                case K.VL:
                    r.Functions[kind] = x => format((AsmVL)x, DataFormatCode.BitWidth);
                break;

                case K.BASE0:
                case K.BASE1:
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
                case K.OUTREG:
                    r.Functions[kind] = x => format((RegExpr)x);
                break;
                default:
                    r.Functions[kind] = x => x.ToString();
                break;
            }
        }
    }
}
