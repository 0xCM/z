//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class XedFieldWriter
{
    [MethodImpl(Inline), Op]
    public static ref XedInstClass iclass(ref XedFieldState src)
        => ref @as<XedInstKind,XedInstClass>(src.ICLASS);
}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly XedInstClass iclass(in XedFieldState src)
        => ref @as<XedInstKind,XedInstClass>(src.ICLASS);
}