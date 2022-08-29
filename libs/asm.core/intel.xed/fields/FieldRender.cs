//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static XedLiterals;
    using static core;

    using K = XedRules.FieldKind;

    partial class XedFields
    {
        public class FieldRender
        {
            public static FieldRender create()
                => new FieldRender();

            public const string Columns = "{0,-24} | {1}";

            public const sbyte ColWidth = 24;

            public const byte Count = 128;

            readonly Index<FieldKind,Func<ushort,string>> Functions;

            public FieldRender()
            {
                Functions = alloc<Func<ushort,string>>(Count);
                init(this);
            }

            public ref Func<ushort,string> this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Functions[kind];
            }

            static void init(FieldRender r)
            {
                for(var i=0; i<FieldRender.Count; i++)
                {
                    var kind = (FieldKind)i;
                    switch(kind)
                    {
                        case K.AGEN:
                            r.Functions[kind] = (x => x.ToString());
                        break;

                        case K.ASZ:
                            r.Functions[kind] = (x => XedRender.format((ASZ)x));
                        break;

                        case K.BCAST:
                            r.Functions[kind] = (x => XedRender.format((BCastKind)x));
                        break;

                        case K.DISP:
                        case K.DF32:
                        case K.DF64:
                        case K.REX:
                        case K.CET:
                        case K.CLDEMOTE:
                        case K.BCRC:
                            r.Functions[kind] = (x => ((bit)x).Format());
                        break;

                        case K.DISP_WIDTH:
                        case K.BRDISP_WIDTH:
                            r.Functions[kind] = (x => XedRender.format((DispWidth)x));
                        break;

                        case K.CHIP:
                            r.Functions[kind] = (x => XedRender.format((ChipCode)x));
                        break;

                        case K.MODE:
                            r.Functions[kind] = (x => MachineModes.format((MachineMode)x));
                        break;

                        case K.SMODE:
                            r.Functions[kind] = (x => XedRender.format((SMODE)x,DataFormatCode.BitWidth));
                        break;

                        case K.EASZ:
                            r.Functions[kind] = (x => XedRender.format((EASZ)x, DataFormatCode.BitWidth));
                        break;

                        case K.EOSZ:
                            r.Functions[kind] = (x => XedRender.format((EOSZ)x, DataFormatCode.BitWidth));
                        break;

                        case K.ESRC:
                            r.Functions[kind] = (x => XedRender.format((ESRC)x));
                        break;

                        case K.ICLASS:
                            r.Functions[kind] = (x => XedRender.format((AmsInstClass)x));
                        break;

                        case K.MASK:
                            r.Functions[kind] = (x => XedRender.format((MaskReg)x));
                        break;

                        case K.OSZ:
                            r.Functions[kind] = (x => XedRender.format((OSZ)x, DataFormatCode.BitWidth));
                        break;

                        case K.MAP:
                            r.Functions[kind] = (x => XedRender.format((byte)x));
                        break;

                        case K.ELEMENT_SIZE:
                            r.Functions[kind] = (x => XedRender.format((ushort)x));
                        break;

                        case K.MODRM_BYTE:
                            r.Functions[kind] = (x => string.Format("0x{0:X2} [{1}]", (byte)x, ((ModRm)x).ToBitString()));
                        break;

                        case K.NOMINAL_OPCODE:
                            r.Functions[kind] = (x => XedRender.format((Hex8)x));
                        break;

                        case K.REP:
                            r.Functions[kind] = (x => XedRender.format((XedModels.RepPrefix)x));
                        break;

                        case K.REXB:
                        case K.REXW:
                        case K.REXR:
                        case K.REXX:
                            r.Functions[kind] = (x => XedRender.format((uint1)x));
                        break;

                        case K.SIBSCALE:
                        case K.MOD:
                            r.Functions[kind] = (x => XedRender.format((uint2)x));
                        break;

                        case K.SIBBASE:
                        case K.REG:
                            r.Functions[kind] = (x => XedRender.format((uint3)x));
                        break;

                        case K.SIBINDEX:
                        case K.RM:
                            r.Functions[kind] = (x => XedRender.format((uint3)x));
                        break;

                        case K.SRM:
                            r.Functions[kind] = (x => XedRender.format((uint3)x));
                        break;

                        case K.VEXDEST210:
                            r.Functions[kind] = (x => XedRender.format((uint3)x));
                        break;
                        case K.VEXDEST4:
                        case K.VEXDEST3:
                            r.Functions[kind] = (x => XedRender.format((uint1)x));
                        break;
                        case K.VEXVALID:
                            r.Functions[kind] = (x => XedRender.format((XedVexClass)x));
                        break;
                        case K.VEX_PREFIX:
                            r.Functions[kind] = (x => XedRender.format((XedVexKind)x));
                        break;
                        case K.VL:
                            r.Functions[kind] = (x => XedRender.format((AsmVL)x, DataFormatCode.BitWidth));
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
                            r.Functions[kind] = (x => XedRender.format((Register)x));
                        break;
                        default:
                            r.Functions[kind] = (x => x.ToString());
                        break;
                    }
                }
            }
        }
    }
}