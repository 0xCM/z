//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataCalcs
    {
        public Index<LlvmList> CalcLists(Index<LlvmEntity> src, ReadOnlySpan<string> classes)
        {
            var emitted = sys.bag<LlvmList>();
            iter(classes, c => emitted.Add(CalcList(src,c)), true);
            return emitted.ToArray();
        }
    }
}