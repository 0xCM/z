//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.ClrQuery)]
[assembly: PartName("clr.query")]
namespace Z0.Parts
{
    public sealed class ClrQuery : Part<ClrQuery>
    {
    }
}

namespace Z0
{
    public static partial class XTend
    {
        const NumericKind Closure = UnsignedInts;
    }    
}