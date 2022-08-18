//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ISpanSorter<T>
        where T : IComparable<T>
    {
        void Sort(Span<T> src);
    }
}