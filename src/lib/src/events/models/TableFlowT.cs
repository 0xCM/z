//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableFlow<T>
        where T : struct
    {
        readonly IWfRuntime Wf;

        public readonly ExecToken Token;

        public readonly FilePath Target;

        public readonly Count EmissionCount;

        [MethodImpl(Inline)]
        internal TableFlow(IWfRuntime wf, FilePath dst, in ExecToken token, uint count = 0)
        {
            Wf = wf;
            Token = token;
            Target = dst;
            EmissionCount = count;
        }

        [MethodImpl(Inline)]
        public TableFlow<T> WithCount(Count count)
            => new TableFlow<T>(Wf, Target, Token, count);

        [MethodImpl(Inline)]
        public TableFlow<T> WithToken(ExecToken token)
            => new TableFlow<T>(Wf, Target, token, EmissionCount);

        [MethodImpl(Inline)]
        public static implicit operator ExecFlow(TableFlow<T> src)
            => new ExecFlow(src.Wf, src.Token);
    }
}