//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IUnaryBitLogic<T>
    {
       T not(T a);

       T identity(T a);
    }
}