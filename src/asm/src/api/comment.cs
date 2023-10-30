//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static AsmComment comment(string src)
        => new (src);

    [MethodImpl(Inline), Op]
    public static AsmInlineComment comment(AsmCommentMarker marker, string src)
        => new (marker,src);
}
