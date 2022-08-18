//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Joins an operation with an input value and the output value obtained by evaluating 
    /// the operation the specified input
    /// </summary>
    public interface IOpEvaluation
    {
        IOperation Actor {get;}

        dynamic Input {get;}

        dynamic Output {get;}
    }


    public interface IOpEvaluation<S> : IOpEvaluation
    {
        new S Input {get;}

        dynamic IOpEvaluation.Input
            => Input;
    }

    public interface IOpEvaluation<S,T> : IOpEvaluation<S>
    {
        new T Output {get;}

        dynamic IOpEvaluation.Output
            => Output;
    }

    public interface IOpEvaluation<O,S,T> : IOpEvaluation<S,T>
        where O : IOperation
    {
        new O Actor {get;}

        IOperation IOpEvaluation.Actor
            => Actor;
    }    
}