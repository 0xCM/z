//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileWritten
    {
        readonly IWfRuntime Wf;

        public ExecToken Token {get;}

        public FS.FilePath Target {get;}

        public Count EmissionCount {get;}

        [MethodImpl(Inline)]
        internal FileWritten(IWfRuntime wf, FS.FilePath dst, in ExecToken token, uint count = 0)
        {
            Wf = wf;
            Token = token;
            Target = dst;
            EmissionCount = count;
        }

        [MethodImpl(Inline)]
        public FileWritten WithCount(Count count)
            => new FileWritten(Wf, Target, Token, count);

        [MethodImpl(Inline)]
        public FileWritten WithToken(ExecToken token)
            => new FileWritten(Wf, Target, token, EmissionCount);

        [MethodImpl(Inline)]
        public static implicit operator WfExecFlow(FileWritten src)
            => new WfExecFlow(src.Wf, src.Token);
    }
}