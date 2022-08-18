//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICount : ICounted, ITextual
    {

    }

    [Free]
    public interface ICount<F,T> : ICount, ICounted<T>
        where T : unmanaged
        where F : unmanaged, ICount<F,T>
    {
        string ITextual.Format()
            => Count.ToString();
    }
}