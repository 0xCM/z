//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public static partial class XTend
    {
        public static LlvmList ToLlvmList(this LlvmListItem[] items, FS.FilePath path)
            => new LlvmList(path,items);
    }

}