//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct WfExecFlow : IDisposable
    {
        readonly IWfRuntime Wf;

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal WfExecFlow(IWfRuntime wf, in ExecToken token)
        {
            Wf = wf;
            Token = token;
        }

        public void Dispose()
            => Wf.Completed(this);
    }
}