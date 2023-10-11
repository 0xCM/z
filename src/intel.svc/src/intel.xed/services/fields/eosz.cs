//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static sys;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly EOSZ eosz(in XedFieldState src)
        => ref @as<EOSZ>(src.EOSZ);
}
