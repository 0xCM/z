//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICounted<T> : ICounted
        where T : unmanaged
    {
        new T Count {get;}

        uint ICounted.Count
            => sys.@as<T,uint>(Count);
    }
}