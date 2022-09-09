//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEmissionLog : IDisposable, IEventSink<EmittedFileEvent>, IEventSink<EmittedTableEvent>
    {
        FilePath TargetPath {get;}
    }
}