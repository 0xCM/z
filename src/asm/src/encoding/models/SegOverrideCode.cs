//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// The segment override codes as specified by Intel Vol II, 2.1.1
/// </summary>
public enum SegOverrideCode : byte
{
    [Symbol("cs", "CS segment override")]
    CS = 0x2e,

    [Symbol("ss", "SS segment override")]
    SS = 0x36,

    [Symbol("ds","DS segment override")]
    DS = 0x3e,

    [Symbol("es", "ES segment override")]
    ES = 0x26,

    [Symbol("fs", "FS segment override")]
    FS = 0x64,

    [Symbol("gs", "GS segment override")]
    GS = 0x65,
}
