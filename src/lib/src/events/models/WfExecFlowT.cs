//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfExecFlow<T>: IDisposable
    {
        readonly IWfRuntime Wf;

        public T Data {get;}

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal WfExecFlow(IWfRuntime wf, T data, in ExecToken token)
        {
            Wf = wf;
            Data = data;
            Token = token;
        }

        [MethodImpl(Inline)]
        public WfExecFlow<string> WithMsg(string  msg)
            => new WfExecFlow<string>(Wf, msg, Token);

        public void Dispose()
            => Wf.Ran(Wf.Host.Type, this);
    }
}