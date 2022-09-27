//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AsmSyntaxDoc : TableDoc<AsmSyntaxRow>
    {
        public AsmSyntaxDoc(FilePath src, AsmSyntaxRow[] rows)
            : base(src,rows)
        {

        }
    }
}