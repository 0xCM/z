// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum FixedNaturalGridKind : uint
    {
        None = 0,

        FN16 = 16 | ApiGridClass.FixedNatural,

        FN32 = 32 | ApiGridClass.FixedNatural,

        FN64 = 64 | ApiGridClass.FixedNatural,

        FN128 = 128 | ApiGridClass.FixedNatural,

        FN256 = 256 | ApiGridClass.FixedNatural,
    }
}