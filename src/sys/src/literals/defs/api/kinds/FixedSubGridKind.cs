// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum FixedSubGridKind : uint
    {
        None = 0,

        FSG16 = 16 | ApiGridClass.FixedSubgrid,

        FSG32 = 32 | ApiGridClass.FixedSubgrid,

        FSG64 = 64 | ApiGridClass.FixedSubgrid,

        FSG128 = 128 | ApiGridClass.FixedSubgrid,

        FSG256 = 256 | ApiGridClass.FixedSubgrid,
    }
}