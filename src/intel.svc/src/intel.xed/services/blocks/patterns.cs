//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial class XedZ
{        
    public static InstBlockPatterns patterns(ParallelQuery<InstBlockLineSpec> lines)
        => new(from line in lines select pattern(line));
}