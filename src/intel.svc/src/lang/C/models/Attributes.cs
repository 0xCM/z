//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public class Attributes
{
    public sealed record VectorSize : LanguageAttribute
    {
        public new const string Keyword = "__vector_size__";

        public readonly uint Width;

        public VectorSize(uint width)
            : base(Keyword)
        {
            Width = width;
        }

        public override ReadOnlySeq<string> Operands
            => new string[]{$"{Width}"};
    }
}


