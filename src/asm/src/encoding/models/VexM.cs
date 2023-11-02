//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Specifies field bits m-mmmmm in the context of the VEX encoding scheme, Vol. 2A 2-15
/// </summary>
/// <remarks>
/// 2.3.6.1 3-byte VEX byte 1, bits[4:0] - m-mmmm
/// VEX.m-mmmm   | Implied Leading Opcode Bytes
/// 00000B       | Reserved
/// 00001B       | 0F
/// 00010B       | 0F 38
/// 00011B       | 0F 3A
/// 00100-11111B | Reserved
/// 2-byte VEX   | 0F
/// </remarks>
public enum VexM : byte
{
    None = 0b0,

    [Symbol("0F", "Specifies 0x0F as the leading opcode byte in the context of the VEX encoding scheme")]
    x0F = 0b01,

    [Symbol("V0F38", "Specifies 0F 38 as the leading opcode byte in the context of the VEX encoding scheme")]
    x0F38 = 0b10,

    [Symbol("V0F3A", "Specifies 0F 3A as the leading opcode byte in the context of the VEX encoding scheme")]
    x0F3A = 0b11,
}
