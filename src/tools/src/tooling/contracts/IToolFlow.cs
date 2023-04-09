//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolFlow : IDisposable
    {
        void OnStart(ExecToken token);

        void OnFinish(ExecStatus status);

        void OnStatus(TextLine src);

        void OnError(TextLine src);

        ExecFlow<T> Running<T>(T msg);

        ExecToken Ran<T>(ExecFlow<T> flow, [CallerName] string msg = null);
    }
}