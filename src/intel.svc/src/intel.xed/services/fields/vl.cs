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
    public static ref AsmVL vl(ref XedFieldState src)
        => ref src.VL;
}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static ref readonly AsmVL vl(in XedFieldState src)
        => ref src.VL;
}

