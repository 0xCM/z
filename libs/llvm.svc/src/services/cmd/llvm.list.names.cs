//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static Algs;

    partial class LlvmCmd
    {
        [CmdOp("llvm/list/names")]
        void ListNames()
        {
           iter(DataProvider.Lists(), list => Write(list.Name));
        }
    }
}