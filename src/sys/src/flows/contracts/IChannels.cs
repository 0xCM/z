//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMsgChannel<M>
    {
        
    }

    public interface IInputChannel<M> : IMsgChannel<M>
    {
        M Input();
    }

    public interface IStatusChannel<S> : IMsgChannel<S>
    {
        void Status(S msg);
    }

    public interface IErrorChannel<E> : IMsgChannel<E>
    {
        void Error(E msg);

    }

    public interface ISysIO : IStatusChannel<string>, IErrorChannel<string>, IInputChannel<string>
    {

    }
}