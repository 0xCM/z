//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public readonly record struct VarPattern
    {
        public readonly AsciSymbol Prefix;

        public readonly AsciFence Fence;

        public readonly AsciVarKind Kind;

        public VarPattern(AsciVarKind kind, AsciSymbol prefix, AsciFence fence)
        {
            Kind = kind;
            Prefix = prefix;
            Fence = fence;
        }
    }
}