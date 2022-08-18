// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    /// <summary>
    /// Defines grid-sort datatype classifiers
    /// </summary>
    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum ApiGridKind : uint
    {
        None = 0,

        Generic = ApiGridClass.Generic,

        Natural = ApiGridClass.Natural,

        Fixed = ApiGridClass.Fixed,

        Unfixed = ApiGridClass.Dynamic,

        Subgrid = ApiGridClass.Subgrid,

        Numeric = ApiGridClass.Numeric,

        GenericUnfixed = ApiGridClass.GenericDynamic,

        NaturalUnfixed = ApiGridClass.NaturalDynamic,

        FixedNatural = ApiGridClass.FixedNatural,

        FixedSubgrid = ApiGridClass.FixedSubgrid,

        NumericGeneric = ApiGridClass.NumericGeneric,

        Numeric16 = 16 | NumericGeneric,

        Numeric32 = 32 | NumericGeneric,

        Numeric64 = 64 | NumericGeneric,

        Natural16 = 16 | FixedNatural,

        Natural32 = 32 | FixedNatural,

        Natural64 = 64 | FixedNatural,

        Natural128 = 128 | FixedNatural,

        Natural256 = 256 | FixedNatural,

        Subgrid16 = 16 | FixedSubgrid,

        Subgrid32 = 32 | FixedSubgrid,

        Subgrid64 = 64 | FixedSubgrid,

        Subgrid128 = 128 | FixedSubgrid,

        Subgrid256 = 256 | FixedSubgrid,
    }
}