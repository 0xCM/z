//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IEmissionLog : IDisposable, IEventSink<EmittedFileEvent>, IEventSink<EmittedTableEvent>
    {
        FS.FilePath TargetPath {get;}
    }
}