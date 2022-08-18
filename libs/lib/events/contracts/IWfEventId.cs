//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IWfEventId<T> : IComparable<T>, IEquatable<T>, IChronic<T>, ITextual
        where T : struct, IWfEventId<T>
    {

    }
}