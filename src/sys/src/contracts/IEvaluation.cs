//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IEvaluation
    {
        dynamic Input {get;}

        dynamic Output {get;}
    }

    [Free]
    public interface IEvaluation<S,T> : IEvaluation
    {
        new S Input {get;}

        new T Output {get;}

        dynamic IEvaluation.Input
            => Input;

        dynamic IEvaluation.Output
            => Output;
    }
}