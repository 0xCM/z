//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static RexPrefix rex(in XedFieldState src)
        => new (src.REXB, src.REXX, src.REXR, src.REXW);
}