// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using NBK = NumericBaseKind;

    [SymSource(api_kinds, NBK.Base16), Flags]
    public enum DynamicGridKind : uint
    {
        None = 0,

        Generic = ApiGridClass.GenericDynamic,

        Natural = ApiGridClass.NaturalDynamic
    }
}