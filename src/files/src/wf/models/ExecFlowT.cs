//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ExecFlow<T>: IDisposable
    {
        readonly IEventChannel Channel;

        public T Data {get;}

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        public ExecFlow(IEventChannel wf, T data, in ExecToken token)
        {
            Channel = wf;
            Data = data;
            Token = token;
        }

        [MethodImpl(Inline)]
        public ExecFlow<string> WithMsg(string  msg)
            => new ExecFlow<string>(Channel, msg, Token);

        public void Dispose()
            => Channel.Ran(this);

        [MethodImpl(Inline)]
        public static implicit operator ExecFlow(ExecFlow<T> src)
            => new ExecFlow(src.Channel, src.Token);

        public static ExecFlow<T> Empty => new ExecFlow<T>(null, default, default);
    }
}