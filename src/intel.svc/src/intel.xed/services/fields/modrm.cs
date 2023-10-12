//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;

partial class XedFieldWriter
{
    [MethodImpl(Inline), Op]
    public static ref ModRm modrm(ref XedFieldState src)
        => ref @as<Hex8,ModRm>(src.MODRM_BYTE);
}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly ModRm modrm(in XedFieldState src)
        => ref @as<Hex8,ModRm>(src.MODRM_BYTE);
}