//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ExecFlow : IDisposable
    {
        readonly IWfChannel Wf;

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal ExecFlow(IWfChannel wf, ExecToken token)
        {
            Wf = wf;
            Token = token;
        }

        public void Dispose()
            => Wf.Ran(this);
    }
}