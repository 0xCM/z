//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

partial class XedFieldWriter
{
    public static ref bit rexx(ref XedFieldState state)
        => ref state.REXX;

    public static ref bit rexr(ref XedFieldState state)
        => ref state.REXR;

    public static ref bit rexb(ref XedFieldState state)
        => ref state.REXB;

    public static ref bit rexw(ref XedFieldState state)
        => ref state.REXX;
}

partial class XedFields
{
    [MethodImpl(Inline), Op]
    public static RexPrefix rex(in XedFieldState src)
        => new (BitPack.pack(src.REXB, src.REXX, src.REXR, src.REXW,0b100));
}