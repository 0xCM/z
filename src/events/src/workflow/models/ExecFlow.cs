//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ExecFlow : IDisposable
    {
        readonly IEventChannel Channel;

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        public ExecFlow(IEventChannel wf, ExecToken token)
        {
            Channel = wf;
            Token = token;
        }

        public void Dispose()
            => Channel.Ran(this);
    }
}