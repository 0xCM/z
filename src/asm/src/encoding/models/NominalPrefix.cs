//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Classifies prefix domains
/// </summary>
public enum NominalPrefix : byte
{
    None = 0,

    /// <summary>
    /// Escape prefix
    /// </summary>
    Escape = 0x0F,

    /// <summary>
    /// CS seg override prefix
    /// </summary>
    CsSegOverride = 0x2E,

    /// <summary>
    /// SS seg override prefix
    /// </summary>
    SsSegOverride = 0x36,

    /// <summary>
    /// DS seg override prefix
    /// </summary>
    DsSegOverride = 0x3E,

    /// <summary>
    /// ES seg override prefix
    /// </summary>
    EsSegOverride = 0x26,

    /// <summary>
    /// FS seg override prefix
    /// </summary>
    FsSegOverride = 0x64,

    /// <summary>
    /// GS seg override prefix
    /// </summary>
    GsSegOverride = 0x65,

    /// <summary>
    /// Rex prefix
    /// </summary>
    Rex = 0x40,

    /// <summary>
    /// Operand size override
    /// </summary>
    OSZ = 0x66,

    /// <summary>
    /// Address size override
    /// </summary>
    ASZ = 0x67,

    /// <summary>
    /// Branch hint (taken)
    /// </summary>
    BranchTaken = 0x3E,

    /// <summary>
    /// Branch hint (not taken)
    /// </summary>
    BranchNotTaken = 0x2E,

    /// <summary>
    /// Lock prefix
    /// </summary>
    Lock = 0xF0,

    /// <summary>
    /// Repeat prefix (F2)
    /// </summary>
    RepF2 = 0xF2,

    /// <summary>
    /// Repeat prefix (F3)
    /// </summary>
    RepF3 = 0xF3,

    /// <summary>
    /// VEX C4 prefix
    /// </summary>
    VexC4 = 0xC4,

    /// <summary>
    /// VEX C5 prefix
    /// </summary>
    VexC5 = 0xC5,

    /// <summary>
    /// EVEX prefix
    /// </summary>
    Evex = 0xFF,
}
