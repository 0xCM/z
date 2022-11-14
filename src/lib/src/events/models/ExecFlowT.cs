//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExecFlow<T>: IDisposable
    {
        readonly IWfRuntime Wf;

        public T Data {get;}

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal ExecFlow(IWfRuntime wf, T data, in ExecToken token)
        {
            Wf = wf;
            Data = data;
            Token = token;
        }

        [MethodImpl(Inline)]
        public ExecFlow<string> WithMsg(string  msg)
            => new ExecFlow<string>(Wf, msg, Token);

        public void Dispose()
            => Wf.Ran(Wf.Host.Type, this);

        public static ExecFlow<T> Empty => new ExecFlow<T>(null, default, default);
    }
}