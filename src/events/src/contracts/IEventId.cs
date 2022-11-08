//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IEventId<T> : IComparable<T>, IEquatable<T>, IChronic<T>, ITextual
        where T : struct, IEventId<T>
    {

    }
}