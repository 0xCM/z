//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    // [Free]
    // public interface IProducer
    // {
    //     Type TargetType {get;}

    //     Type SourceType {get;}
    // }

    // [Free]
    // public interface IProducer<T> : IProducer
    //     where T : IExpr
    // {
    //     Type IProducer.TargetType
    //         => typeof(T);
    // }

    // [Free]
    // public interface IProducer<S,T> : IProducer<T>
    //     where S : IRuleExpr
    //     where T : IExpr
    // {
    //     ReadOnlySpan<T> Produce(ReadOnlySpan<S> src);

    //     Type IProducer.SourceType
    //         => typeof(S);
    // }
}