//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedFieldWriter
{

}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly XedVexClass vexclass(in XedFieldState src)
        => ref @as<XedVexClass>(src.VEXVALID);
}