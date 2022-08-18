//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = FileKind;

    partial class Tools
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