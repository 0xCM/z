//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISortedSeq<T> : ISeq<T>
        where T : IComparable<T>
    {
        void ReSort();
    }
}