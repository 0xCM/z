//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AsmSyntaxDocs : ConstLookup<FS.FilePath,AsmSyntaxDoc>
    {
        public AsmSyntaxDocs(Dictionary<FS.FilePath, AsmSyntaxDoc> src)
            : base(src)
        {


        }

        public static implicit operator AsmSyntaxDocs(Dictionary<FS.FilePath, AsmSyntaxDoc> src)
            => new AsmSyntaxDocs(src);
    }
}