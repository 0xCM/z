//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
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