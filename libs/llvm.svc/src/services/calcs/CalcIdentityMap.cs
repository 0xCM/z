//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public IdentityMap<uint> CalcIdentityMap(LineMap<string> src)
        {
            var lookup = new IdentityMap<uint>();
            iteri(src.View, (i,entry) => lookup.Include(entry.Id, (entry.MinLine, entry.MaxLine)));
            return lookup.Seal();
        }
    }
}