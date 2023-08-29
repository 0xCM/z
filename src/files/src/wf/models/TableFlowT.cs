//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct TableFlow<T>
{
    readonly IEventChannel Channel;

    public readonly ExecToken Token;

    public readonly FilePath Target;

    public readonly Count EmissionCount;

    [MethodImpl(Inline)]
    public TableFlow(IEventChannel wf, FilePath dst, in ExecToken token, uint count = 0)
    {
        Channel = wf;
        Token = token;
        Target = dst;
        EmissionCount = count;
    }

    [MethodImpl(Inline)]
    public TableFlow<T> WithCount(Count count)
        => new (Channel, Target, Token, count);

    [MethodImpl(Inline)]
    public TableFlow<T> WithToken(ExecToken token)
        => new (Channel, Target, token, EmissionCount);

    [MethodImpl(Inline)]
    public static implicit operator ExecFlow(TableFlow<T> src)
        => new (src.Channel, src.Token);
}
