//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang;

using C;

using static C.Attributes;
using static C.DeclSpecs;

public class c
{
    public static TypeDef typedef(string defined, string alias)
        => new(defined, alias);

    public static VectorSize __vector_size__(uint width)
        => new(width);

    public static Align align(uint width)
        => Align.create(width);

    public static void render(ref uint indent, TypeDef src, ITextEmitter dst)
    {
        dst.IndentLineFormat(indent, "typedef {0} {1}", src.Defined, src.Alias);
    }

    public static void render(ref uint indent, VectorSize src, ITextEmitter dst)
    {
        dst.IndentLineFormat(indent, "{0}(({1}({2})))", 
            LanguageAttribute.Keyword,
            src.AttributeName,
            src.Width
            );
    }
}
