//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;
using static MachineModes;
using static XedRules;

using K = XedRules.FieldKind;
using M = XedModels;

[Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
public record struct XedFieldState
{
    public const string TableId = "xed.fields.state";

    [RuleField(K.DF32, num1.Width, typeof(bit))]
    public bit DF32;

    [RuleField(K.DF64, num1.Width, typeof(bit), "Specifies whether, in 64-bit mode, to default to 64 bit-width")]
    public bit DF64;

    [RuleField(K.NO_SCALE_DISP8, num1.Width, typeof(bit), "When enabled, indicates that displacement is not scaled by the number of elements")]
    public bit NO_SCALE_DISP8;

    [RuleField(K.BCRC, num1.Width, typeof(bit))]
    public bit BCRC;

    [RuleField(K.CET, num1.Width, typeof(bit))]
    public bit CET;

    [RuleField(K.CLDEMOTE, num1.Width, typeof(bit))]
    public bit CLDEMOTE;

    [RuleField(K.IMM0, num1.Width, typeof(bit))]
    public bit IMM0;

    [RuleField(K.IMM0SIGNED, num1.Width, typeof(bit))]
    public bit IMM0SIGNED;

    [RuleField(K.IMM1, num1.Width, typeof(bit))]
    public bit IMM1;

    [RuleField(K.MODEP5, num1.Width, typeof(bit))]
    public bit MODEP5;

    [RuleField(K.MODEP55C, num1.Width, typeof(bit))]
    public bit MODEP55C;

    [RuleField(K.ASZ, num1.Width, typeof(bit), "Specifies whether the 0x67 prefix is applicable")]
    public bit ASZ;

    [RuleField(K.OSZ, num1.Width, typeof(bit), "Specifies whether the 0x66 prefix is applicable")]
    public bit OSZ;

    [RuleField(K.LOCK, num1.Width, typeof(bit), "Specifies whether the 0xF0 prefix is applicable")]
    public bit LOCK;

    [RuleField(K.PREFIX66, num1.Width, typeof(bit))]
    public bit PREFIX66;

    [RuleField(K.NEEDREX, num1.Width, typeof(bit))]
    public bit NEEDREX;

    [RuleField(K.NOREX, num1.Width, typeof(bit))]
    public bit NOREX;

    [RuleField(K.REX, num1.Width, typeof(bit))]
    public bit REX;

    [RuleField(K.VEX_C4, num1.Width, typeof(bit))]
    public bit VEX_C4;

    [RuleField(K.MUST_USE_EVEX, num1.Width, typeof(bit))]
    public bit MUST_USE_EVEX;

    [RuleField(K.MODE_FIRST_PREFIX, num1.Width, typeof(bit))]
    public bit MODE_FIRST_PREFIX;

    [RuleField(K.MODE_SHORT_UD0, num1.Width, typeof(bit))]
    public bit MODE_SHORT_UD0;

    [RuleField(K.MPXMODE, num1.Width, typeof(bit))]
    public bit MPXMODE;

    [RuleField(K.REALMODE, num1.Width, typeof(bit))]
    public bit REALMODE;

    [RuleField(K.P4, num1.Width, typeof(bit))]
    public bit P4;

    [RuleField(K.PTR, num1.Width, typeof(bit))]
    public bit PTR;

    [RuleField(K.AGEN, num1.Width, typeof(bit))]
    public bit AGEN;

    [RuleField(K.MEM0, num1.Width, typeof(bit))]
    public bit MEM0;

    [RuleField(K.MEM1, num1.Width, typeof(bit))]
    public bit MEM1;

    [RuleField(K.HAS_MODRM, num1.Width, typeof(bit))]
    public bit HAS_MODRM;

    [RuleField(K.HAS_SIB, num1.Width, typeof(bit))]
    public bit HAS_SIB;

    [RuleField(K.NEED_SIB, num1.Width, typeof(bit))]
    public bit NEED_SIB;

    [RuleField(K.ZEROING, num1.Width, typeof(bit), "Specifies whether zero-masking is enabled, if applicable")]
    public bit ZEROING;

    [RuleField(K.SAE, num1.Width, typeof(bit))]
    public bit SAE;

    [RuleField(K.UBIT, num1.Width, typeof(bit))]
    public bit UBIT;

    [RuleField(K.WBNOINVD, num1.Width, typeof(bit))]
    public bit WBNOINVD;

    [RuleField(K.NO_RETURN, num1.Width, typeof(bit))]
    public bit NO_RETURN;

    [RuleField(K.RELBR, num1.Width, typeof(bit))]
    public bit RELBR;

    [RuleField(K.UIMM0, num1.Width, typeof(bit))]
    public bit UIMM0;

    [RuleField(K.UIMM1, num1.Width, typeof(bit))]
    public bit UIMM1;

    [RuleField(K.DUMMY, num1.Width, typeof(bit))]
    public bit DUMMY;

    [RuleField(K.DISP, num1.Width, typeof(bit))]
    public bit DISP;

    [RuleField(K.AMD3DNOW, num1.Width, typeof(bit))]
    public bit AMD3DNOW;

    [RuleField(K.USING_DEFAULT_SEGMENT0, num1.Width, typeof(bit))]
    public bit USING_DEFAULT_SEGMENT0;

    [RuleField(K.USING_DEFAULT_SEGMENT1, num1.Width, typeof(bit))]
    public bit USING_DEFAULT_SEGMENT1;

    [RuleField(K.LZCNT, num1.Width, typeof(bit))]
    public bit LZCNT;

    [RuleField(K.TZCNT, num1.Width, typeof(bit))]
    public bit TZCNT;

    [RuleField(K.ILD_F2, num1.Width, typeof(bit))]
    public bit ILD_F2;

    [RuleField(K.ILD_F3, num1.Width, typeof(bit))]
    public bit ILD_F3;

    [RuleField(K.ENCODER_PREFERRED, num1.Width, typeof(bit))]
    public bit ENCODER_PREFERRED;

    [RuleField(K.ENCODE_FORCE, num1.Width, typeof(bit))]
    public bit ENCODE_FORCE;

    [RuleField(K.OUT_OF_BYTES, num1.Width, typeof(bit))]
    public bit OUT_OF_BYTES;

    [RuleField(K.MASK, num1.Width, typeof(bit))]
    public bit MASK;

    [RuleField(K.MODE, num3.Width, typeof(MachineModeClass), "Specifies one of {Mode16,Mode32,Mode64,Not64} if applicable")]
    public byte MODE;

    [RuleField(K.SMODE, num2.Width, typeof(M.SMODE), "Specifies one of {SMode16,SMode32,SMode64} if applicable")]
    public byte SMODE;

    [RuleField(K.REP, num2.Width, typeof(M.RepPrefix), "Specifies one of {NOF3,REPF2,REPF3} if applicable")]
    public byte REP;

    [RuleField(K.DEFAULT_SEG, num2.Width, typeof(num2))]
    public byte DEFAULT_SEG;

    [RuleField(K.FIRST_F2F3, num2.Width, typeof(num2))]
    public byte FIRST_F2F3;

    [RuleField(K.LAST_F2F3, num2.Width, typeof(num2))]
    public byte LAST_F2F3;

    [RuleField(K.EASZ, num3.Width, typeof(M.EASZ), "Specifies one of {EASZ16,EASZ32,EASZ64,EASZNot16} if applicable")]
    public byte EASZ;

    [RuleField(K.EOSZ, num3.Width, typeof(M.EOSZ), "Specifies one of {EOSZ8,EOSZ16,EOSZ32,EOSZ64,EASZNot64} if applicable")]
    public byte EOSZ;

    [RuleField(K.NEED_MEMDISP, num7.Width, typeof(M.DispWidth))]
    public byte NEED_MEMDISP;

    [RuleField(K.BRDISP_WIDTH, num7.Width, typeof(M.DispWidth), "Specifies the bit-width of a branch displacement, if applicable")]
    public byte BRDISP_WIDTH;

    [RuleField(K.ELEMENT_SIZE, num3.Width, typeof(M.ElementSize))]
    public byte ELEMENT_SIZE;

    [RuleField(K.DISP_WIDTH, num7.Width, typeof(M.DispWidth))]
    public byte DISP_WIDTH;

    [RuleField(K.NPREFIXES, num3.Width, typeof(num3))]
    public byte NPREFIXES;

    [RuleField(K.NREXES, num3.Width, typeof(num3))]
    public byte NREXES;

    [RuleField(K.NSEG_PREFIXES, num3.Width, typeof(num3))]
    public byte NSEG_PREFIXES;

    [RuleField(K.SEG_OVD, num3.Width, typeof(M.SegPrefixKind), "Defines the value of the seg override prefix, if any")]
    public byte SEG_OVD;

    [RuleField(K.HINT, num3.Width, typeof(M.HintKind))]
    public byte HINT;

    [RuleField(K.IMM_WIDTH, num3.Width, typeof(NativeSizeCode), "Specifies the native size code of the IMM field, if applicable")]
    public byte IMM_WIDTH;

    [RuleField(K.IMM1_BYTES, num3.Width, typeof(num3))]
    public byte IMM1_BYTES;

    [RuleField(K.SCALE, num4.Width, typeof(MemoryScale), "Specifies the scaling factor applied to an index register, if applicable")]
    public byte SCALE;

    [RuleField(K.NELEM, num11.Width, typeof(num11), "Specifies an element bit-width, if applicable")]
    public ushort NELEM;

    [RuleField(K.POS_NOMINAL_OPCODE, num4.Width, typeof(num4), "Specifies the 0-based index of the NOMINAL_OPCODE field, if applicable")]
    public byte POS_NOMINAL_OPCODE;

    [RuleField(K.POS_MODRM, num4.Width, typeof(num4), "Specifies the 0-based index of the encoded MODRM field, if applicable")]
    public byte POS_MODRM;

    [RuleField(K.POS_SIB, num4.Width, typeof(num4), "Specifies the 0-based index of the encoded SIB field, if applicable")]
    public byte POS_SIB;

    [RuleField(K.POS_IMM, num4.Width, typeof(num4), "Specifies the 0-based index of the encoded IMM field, if applicable")]
    public byte POS_IMM;

    [RuleField(K.POS_IMM1, num4.Width, typeof(num4), "Specifies the 0-based index of the encoded IMM1 field, if applicable")]
    public byte POS_IMM1;

    [RuleField(K.POS_DISP, num4.Width, typeof(num4), "Specifies the 0-based index of the encoded DISP field, if applicable")]
    public byte POS_DISP;

    [RuleField(K.MAP, num4.Width, typeof(XedMapNumber))]
    public byte MAP;

    [RuleField(K.MAX_BYTES, num4.Width, typeof(num4))]
    public byte MAX_BYTES;

    [RuleField(K.MEM_WIDTH, num7.Width, typeof(num7), "The size of referenced memory, in bytes")]
    public byte MEM_WIDTH;

    [RuleField(K.ILD_SEG, num8.Width, typeof(byte))]
    public byte ILD_SEG;

    [RuleField(K.NOMINAL_OPCODE, num8.Width, typeof(Hex8), "Specifies the nominal opcode value")]
    public byte NOMINAL_OPCODE;

    [RuleField(K.MODRM_BYTE, num8.Width, typeof(Hex8))]
    public Hex8 MODRM_BYTE;

    [RuleField(K.MOD, num2.Width, typeof(num2), "Specifies the value of the MOD segment of the ModRM bitfield, if applicable")]
    public num2 MOD;

    [RuleField(K.REG, num3.Width, typeof(num3), "Specifies the value of the REG segment of the ModRM bitfield, if applicable")]
    public num3 REG;

    [RuleField(K.RM, num3.Width, typeof(num3), "Specifies the value of the RM segment of the ModRM bitfield, if applicable")]
    public num3 RM;

    [RuleField(K.SIBSCALE, num2.Width, typeof(num2))]
    public byte SIBSCALE;

    [RuleField(K.SIBINDEX, num3.Width, typeof(num3))]
    public byte SIBINDEX;

    [RuleField(K.SIBBASE, num3.Width, typeof(num3))]
    public byte SIBBASE;

    [RuleField(K.REXW, num1.Width, typeof(bit), "Specifies the 'W' bit of the REX prefix, if applicable")]
    public bit REXW;

    [RuleField(K.REXR, num1.Width, typeof(bit), "Specifies the 'R' bit of the REX prefix, if applicable")]
    public bit REXR;

    [RuleField(K.REXX, num1.Width, typeof(bit), "Specifies the 'X' bit of the REX prefix, if applicable")]
    public bit REXX;

    [RuleField(K.REXB, num1.Width, typeof(bit), "Specifies the 'B' bit of the REX prefix, if applicable")]
    public bit REXB;

    [RuleField(K.REXRR, num1.Width, typeof(bit))]
    public bit REXRR;

    [RuleField(K.VEXDEST4, num1.Width, typeof(bit))]
    public bit VEXDEST4;

    [RuleField(K.VEXDEST3, num1.Width, typeof(bit))]
    public bit VEXDEST3;

    [RuleField(K.VEXDEST210, num3.Width, typeof(num3))]
    public num3 VEXDEST210;

    [RuleField(K.ROUNDC, num3.Width, typeof(RoundingKind))]
    public byte ROUNDC;

    [RuleField(K.LLRC, num2.Width, typeof(LLRC))]
    public LLRC LLRC;

    [RuleField(K.SRM, num3.Width, typeof(num3))]
    public num3 SRM;

    [RuleField(K.ESRC, num4.Width, typeof(ESRC))]
    public byte ESRC;

    [RuleField(K.VEXVALID, num3.Width, typeof(VexValid), "Specifies one of {VV0,VV1,EVV,XOPV,KVV}, if applicable")]
    public byte VEXVALID;

    [RuleField(K.VEX_PREFIX, num2.Width, typeof(XedVexKind), "Specifies one of {VNP,V66,VF2,VF3}, if applicable")]
    public byte VEX_PREFIX;

    [RuleField(K.VL, num3.Width, typeof(VL), "Specifies one of {V128,V256,V512}, if applicable")]
    public byte VL;

    [RuleField(K.BCAST, num5.Width, typeof(BroadcastKind))]
    public BroadcastKind BCAST;

    [RuleField(K.ERROR, num5.Width, typeof(M.ErrorKind))]
    public ErrorKind ERROR;

    [RuleField(K.ICLASS, num11.Width, typeof(XedInstKind))]
    public XedInstKind ICLASS;

    [RuleField(K.CHIP, num7.Width, typeof(M.ChipCode))]
    public ChipCode CHIP;

    [RuleField(K.REG0, num9.Width, typeof(XedRegId), "Specifies the value of a first register operand, if applicable")]
    public XedRegId REG0;

    [RuleField(K.REG1, num9.Width, typeof(XedRegId), "Specifies the value of a second register operand, if applicable")]
    public XedRegId REG1;

    [RuleField(K.REG2, num9.Width, typeof(XedRegId), "Specifies the value of a third register operand, if applicable")]
    public XedRegId REG2;

    [RuleField(K.REG3, num9.Width, typeof(XedRegId), "Specifies the value of a fourth register operand, if applicable")]
    public XedRegId REG3;

    [RuleField(K.REG4, num9.Width, typeof(XedRegId), "Specifies the value of a fifth register operand, if applicable")]
    public XedRegId REG4;

    [RuleField(K.REG5, num9.Width, typeof(XedRegId), "Specifies the value of a sixth register operand, if applicable")]
    public XedRegId REG5;

    [RuleField(K.REG6, num9.Width, typeof(XedRegId), "Specifies the value of a seventh register operand, if applicable")]
    public XedRegId REG6;

    [RuleField(K.REG7, num9.Width, typeof(XedRegId), "Specifies the value of an eighth register operand, if applicable")]
    public XedRegId REG7;

    [RuleField(K.REG8, num9.Width, typeof(XedRegId), "Specifies the value of a ningth register operand, if applicable")]
    public XedRegId REG8;

    [RuleField(K.REG9, num9.Width, typeof(XedRegId), "Specifies the value of a tenth register operand, if applicable")]
    public XedRegId REG9;

    [RuleField(K.BASE0, num9.Width, typeof(XedRegId))]
    public XedRegId BASE0;

    [RuleField(K.BASE1, num9.Width, typeof(XedRegId))]
    public XedRegId BASE1;

    [RuleField(K.INDEX, num9.Width, typeof(XedRegId), "Specifies an index register, if applicable")]
    public XedRegId INDEX;

    [RuleField(K.SEG0, num9.Width, typeof(XedRegId))]
    public XedRegId SEG0;

    [RuleField(K.SEG1, num9.Width, typeof(XedRegId))]
    public XedRegId SEG1;

    [RuleField(K.OUTREG, num9.Width, typeof(XedRegId))]
    public XedRegId OUTREG;

    public static XedFieldState Empty => default;
}
