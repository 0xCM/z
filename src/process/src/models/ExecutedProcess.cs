//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class ExecutedProcess
    {
        public readonly ExecutingProcess ExecSpec;

        public readonly Timestamp Finished;

        public readonly ExecToken Token;

        public ExecutedProcess(ExecutingProcess spec, Timestamp finished, ExecToken token)
        {
            ExecSpec = spec;
            Finished = finished;
            Token = token;
        }
        public ref readonly ProcessId Id => ref ExecSpec.Id;
    }
}