//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedFieldWriter
{

}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static Sib sib(in XedFieldState src)
        => new (src.SIBBASE, src.SIBINDEX, src.SIBSCALE);
}