//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public enum ModRmField : byte
{
    /// <summary>
    /// nnn[2:0]
    /// </summary>
    nnn,

    /// <summary>
    /// rrr[5:3]
    /// </summary>
    rrr,

    /// <summary>
    /// mm[7:6]
    /// </summary>
    mm,
}
