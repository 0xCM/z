//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface ICellIndex : ITextual
    {
        uint Row {get;}

        uint Col {get;}

        string ITextual.Format()
            => $"({Row},{Col})";
    }

    public interface ICellIndex<F> : ICellIndex
        where F : unmanaged, ICellIndex<F>
    {

    }

    public interface ICellIndex<F,T> : ICellIndex<F>
        where F : unmanaged, ICellIndex<F,T>
        where T : unmanaged
    {
        new T Row {get;}

        new T Col {get;}

        uint ICellIndex.Row
            => uint32(Row);

        uint ICellIndex.Col
            => uint32(Col);
    }
}