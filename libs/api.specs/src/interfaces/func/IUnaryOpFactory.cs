//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IUnaryOpFactory<T> : IOperatorFactory<Func<T,T>,T>
    {

    }
}