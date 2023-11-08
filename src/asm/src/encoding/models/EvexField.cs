//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public enum EvexField : byte
{
    /// <summary>
    /// EVEX.mmm[2:0] Access to up to eight decoding maps; Currently, only the following decoding maps are supported: 1,2, 3, 5, and 6.
    /// </summary>    
    [Bitfield(0,2), Symbol("EVEX.mmm", "Access to up to eight decoding maps; Currently, only the following decoding maps are supported: 1,2, 3, 5, and 6.")]
    mmm,

    /// <summary>
    /// Reserved; must be 0
    /// </summary>
    [Bitfield(3), Symbol("0","Reserved; must be 0")]
    d0,

    /// <summary>
    /// Evex.R'[4] Combine with EVEX.R and ModR/M.reg; This bit is stored in inverted format
    /// </summary>
    [Bitfield(4), Symbol("EVEX.R'", "Combine with EVEX.R and ModR/M.reg; This bit is stored in inverted format")]
    Rp,
    
    /// <summary>
    /// EVEX.RXB[7:5] Next-8 register specifier modifier; Combine with ModR/M.reg, ModR/M.rm (base, index/vidx). This field is encoded in bit inverted format.
    /// </summary>
    [Bitfield(5,7), Symbol("EVEX.RXB","Next-8 register specifier modifier; Combine with ModR/M.reg, ModR/M.rm (base, index/vidx). This field is encoded in bit inverted format.")]
    RXB,

    /// <summary>
    /// EVEX.X[6] Combine with EVEX.B and ModR/M.rm, when SIB/VSIB absent 
    /// </summary>
    [Bitfield(6), Symbol("EVEX.X", "Combine with EVEX.B and ModR/M.rm, when SIB/VSIB absent ")]
    X,

    /// <summary>
    /// EVEX.pp[9:8]: Compressed legacy prefix; Identical to VEX.pp
    /// </summary>
    [Bitfield(8,9), Symbol("EVEX.pp", "Compressed legacy prefix; Identical to VEX.pp")]
    pp,

    /// <summary>
    /// Reserved; must be 1
    /// </summary>
    [Bitfield(10), Symbol("1", "Reserved; must be 1")]
    d1,

    /// <summary>
    /// EVEX.vvvv: VVVV register specifier; Same as VEX.vvvv. This field is encoded in bit inverted format.
    /// </summary>
    [Bitfield(11,14), Symbol("EVEX.vvvv","VVVV register specifier; Same as VEX.vvvv. This field is encoded in bit inverted format.")]
    vvvv,

    /// <summary>
    /// EVEX.W: Operand size promotion/Opcode extension
    /// </summary>
    [Bitfield(15), Symbol("EVEX.W", "Operand size promotion/Opcode extension")]
    W,

    /// <summary>
    /// EVEX.aaa: Embedded opmask register specifier
    /// </summary>
    [Bitfield(16,18), Symbol("EVEX.aaa","Embedded opmask register specifier")]
    aaa,

    /// <summary>
    /// EVEX.V': High-16 VVVV/VIDX register specifier; Combine with EVEX.vvvv or when VSIB present. This bit is stored in inverted format.
    /// </summary>
    [Bitfield(19), Symbol("EVEX.V'","High-16 VVVV/VIDX register specifier; Combine with EVEX.vvvv or when VSIB present. This bit is stored in inverted format.")]
    Vp,

    /// <summary>
    /// EVEX.b: Broadcast/RC/SAE Context
    /// </summary>
    [Bitfield(20), Symbol("b", "Broadcast/RC/SAE Context")]
    b,

    /// <summary>
    /// EVEX.L'L Vector length/RC
    /// </summary>
    [Bitfield(21,22), Symbol("EVEX.L'L", "Vector length/RC")]
    VL,

    /// <summary>
    /// EVEX.z Zeroing/Merging
    /// </summary>
    [Bitfield(23), Symbol("EVEX.z", "Zeroing/Merging")]
    z, 
}
