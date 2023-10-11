//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly XedVexKind vexkind(in XedFieldState src)
        => ref @as<XedVexKind>(src.VEX_PREFIX);
}