//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.ClrMsil)]
namespace Z0.Parts
{
    public sealed class ClrMsil : Part<ClrMsil>
    {
    }
}

namespace Z0
{
    class SymbolicQuery{}

    class Root
    {

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

    }
}
