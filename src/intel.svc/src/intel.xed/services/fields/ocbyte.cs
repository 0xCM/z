//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly Hex8 ocbyte(in XedFieldState src)
        => ref @as<Hex8>(src.NOMINAL_OPCODE);
}