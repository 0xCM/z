//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFixedCells : ICellSeq
    {
        uint Capacity {get;}
    }

    public interface IFixedCells<T> : ISeq<T>, IEnumerable<T>
        where T : unmanaged
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => sys.@throw<IEnumerator<T>>();

        IEnumerator IEnumerable.GetEnumerator()
            => sys.@throw<IEnumerator>();
    }
}