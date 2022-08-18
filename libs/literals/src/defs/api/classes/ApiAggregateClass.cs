//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    using Id = ApiClassKind;

    [ApiClass, SymSource(api_classes)]
    public enum ApiAggregateClass : ushort
    {
        None = 0,

        Sum = Id.Sum,

        Avg = Id.Avg,

        AggMax = Id.AggMax,

        AggMin = Id.AggMin
    }
}