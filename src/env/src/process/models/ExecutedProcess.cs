//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct ExecutedProcess
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

    public ProcessId Id => ExecSpec.Id;
}
