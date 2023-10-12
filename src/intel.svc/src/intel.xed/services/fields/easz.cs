//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

partial class XedFieldWriter
{
    [MethodImpl(Inline), Op]
    public static ref EASZ easz(ref XedFieldState src)
        => ref @as<EASZ>(src.EASZ);
}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly EASZ easz(in XedFieldState src)
        => ref @as<EASZ>(src.EASZ);
}
