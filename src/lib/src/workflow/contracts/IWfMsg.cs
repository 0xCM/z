//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfMsg : IService, IDisposable
    {
        IWfRuntime Wf {get;}

        EventId Raise<E>(in E e)
            where E : IEvent
                => Wf.Raise(e);

        void Babble(string pattern, params object[] args)
            => Wf.Babble(HostType, string.Format(pattern,args));

        void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Wf.Status(HostType, content, flair);

        void Warn(string pattern, params object[] args)
            => Wf.Warn(string.Format(pattern,args));

        void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Error(HostType, core.require(content), caller, file, line);

        void Write<T>(T content)
            => Wf.Data(HostType, content);

        ExecFlow<Type> Creating(Type host)
            => Wf.Creating(host);

        ExecToken Created(ExecFlow<Type> flow)
            => Wf.Created(flow);

        ExecFlow<string> Running([CallerName] string msg = null)
            => Wf.Running(HostType, msg);

        ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null)
            => Wf.Ran(HostType, flow.WithMsg(msg));

        FileWritten EmittingFile(FilePath dst)
            => Wf.EmittingFile(HostType, dst);

        ExecToken EmittedFile(FileWritten flow, Count count)
            => Wf.EmittedFile(HostType, flow, count);

        TableFlow<T> EmittingTable<T>(FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(HostType, dst);

        ExecToken EmittedTable<T>(TableFlow<T> flow, Count count, FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(HostType, flow,count, dst);
    }
}