//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    using static Tools;

    partial class FileFlows
    {
        /// <summary>
        /// *.ll -> *.bc
        /// </summary>
        public class LlToBc : FileFlow<LlToBc,LlvmAs>
        {
            public LlToBc()
                : base(llvm_as, K.Llir, K.Bc)
            {

            }
        }
    }
}