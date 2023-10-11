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
    public static ref readonly RoundingKind rounding(in XedFieldState src)
        => ref @as<RoundingKind>(src.ROUNDC);
}