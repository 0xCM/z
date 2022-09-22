//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public static partial class XTend
    {
        public static LlvmList ToLlvmList(this LlvmListItem[] items, FilePath path)
            => new LlvmList(path,items);
    }

}