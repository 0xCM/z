//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEvent : IChronic, IExpr, INullary
    {
        EventId EventId {get;}

        FlairKind Flair
            => FlairKind.Status;

        bool IsError
            => Flair == FlairKind.Error;
    }

    public interface IEvent<E> : IEvent, INullary<E>
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
    public interface IAppEvent : IEvent
    {

    }
}