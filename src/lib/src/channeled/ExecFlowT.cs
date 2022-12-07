//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExecFlow<T>: IDisposable
    {
        readonly IWfChannel Wf;

        public T Data {get;}

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal ExecFlow(IWfChannel wf, T data, in ExecToken token)
        {
            Wf = wf;
            Data = data;
            Token = token;
        }

        [MethodImpl(Inline)]
        public ExecFlow<string> WithMsg(string  msg)
            => new ExecFlow<string>(Wf, msg, Token);

        public void Dispose()
            => Wf.Ran(this);

        [MethodImpl(Inline)]
        public static implicit operator ExecFlow(ExecFlow<T> src)
            => new ExecFlow(src.Wf, src.Token);

        public static ExecFlow<T> Empty => new ExecFlow<T>(null, default, default);
    }
}