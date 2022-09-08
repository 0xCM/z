//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    public partial class Tools
    {
        public sealed class LlvmNm : Tool<LlvmNm>
        {
            public LlvmNm()
                : base(N.llvm_nm)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }
    }
}