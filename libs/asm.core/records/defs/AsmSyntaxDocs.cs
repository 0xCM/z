//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AsmSyntaxDocs : ConstLookup<FilePath,AsmSyntaxDoc>
    {
        public AsmSyntaxDocs(Dictionary<FilePath, AsmSyntaxDoc> src)
            : base(src)
        {


        }

        public static implicit operator AsmSyntaxDocs(Dictionary<FilePath, AsmSyntaxDoc> src)
            => new AsmSyntaxDocs(src);
    }
}