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
        /// *.bc -> *.ll.bc
        /// </summary>
        public class BcToLlBc : FileFlow<BcToLlBc,LlvmDis>
        {
            public BcToLlBc()
                : base(llvm_dis, K.Bc, K.LlBc)
            {

            }
        }
    }
}