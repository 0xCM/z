//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial class XedZ
{        
    public static ParallelQuery<InstBlockPattern> patterns(ParallelQuery<InstBlockLineSpec> lines)
        => from line in lines select XedZ.pattern(line);
}