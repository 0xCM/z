//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public interface IEvent : IChronic, IExpr
    {
        FlairKind Flair
            => FlairKind.Status;

        bool IsError
            => Flair == FlairKind.Error;
    }

    public interface IEvent<E> : IEvent
        where E : IEvent<E>, new()
    {

    }

    public interface IEvent<E,D> : IEvent<E>
        where E : IEvent<E>, new()
        where D : INullity
    {
        D Payload {get;}

        bool INullity.IsEmpty
            => Payload.IsEmpty;
    }

    /// <summary>
    /// Characterizes a correlated message, accompanied by arbitrary content,
    /// that describes an occurrence of something interesting
    /// </summary>
    [Free]
    public interface IAppEvent : ITextual, IChronic
    {
        FlairKind Flair
            => FlairKind.Status;

        bool IsError
            => Flair == FlairKind.Error;
    }

    /// <summary>
    /// Characterizes a reified application event
    /// </summary>
    /// <typeparam name="F">The reification type</typeparam>
    [Free]
    public interface IAppEvent<F> : IAppEvent, INullary<F>, IChronic
        where F : IAppEvent<F>, new()
    {
        F INullary<F>.Zero
            => new F();
    }
}