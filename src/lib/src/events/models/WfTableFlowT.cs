//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfTableFlow<T>
        where T : struct
    {
        readonly IWfRuntime Wf;

        public readonly ExecToken Token;

        public readonly FilePath Target;

        public readonly Count EmissionCount;

        [MethodImpl(Inline)]
        internal WfTableFlow(IWfRuntime wf, FilePath dst, in ExecToken token, uint count = 0)
        {
            Wf = wf;
            Token = token;
            Target = dst;
            EmissionCount = count;
        }

        [MethodImpl(Inline)]
        public WfTableFlow<T> WithCount(Count count)
            => new WfTableFlow<T>(Wf, Target, Token, count);

        [MethodImpl(Inline)]
        public WfTableFlow<T> WithToken(ExecToken token)
            => new WfTableFlow<T>(Wf, Target, token, EmissionCount);

        [MethodImpl(Inline)]
        public static implicit operator WfExecFlow(WfTableFlow<T> src)
            => new WfExecFlow(src.Wf, src.Token);
    }
}