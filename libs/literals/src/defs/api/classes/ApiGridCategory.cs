// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;
    using static Pow2Scalars;

    [ApiClass, SymSource(api_classes), Flags]
    public enum ApiGridClass : uint
    {
        None = 0,

        Generic = T16,

        Natural = T17,

        Fixed = T18,

        Dynamic = T19,

        Subgrid = T20,

        Numeric = T21,

        GenericDynamic = Generic | Dynamic,

        NaturalDynamic = Natural | Dynamic,

        FixedNatural = Fixed | Natural,

        FixedSubgrid = FixedNatural | Subgrid,

        NumericGeneric = Fixed | Numeric | Generic,
    }
}