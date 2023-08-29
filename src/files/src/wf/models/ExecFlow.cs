//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct ExecFlow : IDisposable
{
    readonly IEventChannel Channel;

    public readonly ExecToken Token;

    [MethodImpl(Inline)]
    public ExecFlow(IEventChannel wf, ExecToken token)
    {
        Channel = wf;
        Token = token;
    }

    public void Dispose()
        => Channel.Ran(this);
}
