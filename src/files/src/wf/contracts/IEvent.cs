//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public interface IEvent : IChronic, IExpr, INullary
{
    EventId EventId {get;}

    LogLevel EventLevel {get;}

    bool IsWarning
        => EventLevel == LogLevel.Warning;

    bool IsError
        => EventLevel == LogLevel.Error;

    FlairKind Flair
        => FlairKind.Status;

}

public interface IEvent<E> : IEvent, INullary<E>
    where E : IEvent<E>, new()
{

}
