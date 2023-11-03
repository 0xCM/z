//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly VexValid vexvalid(in XedFieldState src)
        => ref @as<VexValid>(src.VEXVALID);
}