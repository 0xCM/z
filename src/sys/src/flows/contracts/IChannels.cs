//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMsgChannel<M>
    {
        
    }

    public interface IStatusChannel<S> : IMsgChannel<S>
    {
        void Status(S msg);

    }

    public interface IErrorChannel<E> : IMsgChannel<E>
    {
        void Error(E msg);

    }

    public interface IStdIO : IStatusChannel<string>, IErrorChannel<string>
    {

    }

}