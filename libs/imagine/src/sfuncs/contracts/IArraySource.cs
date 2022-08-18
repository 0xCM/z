//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IArraySource<T> : ISpanProvider<T>
    {
        new T[] Data();

        Span<T> ISpanProvider<T>.Data()
            => Data();
    }
}