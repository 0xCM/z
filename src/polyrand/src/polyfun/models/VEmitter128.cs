//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct VEmitter128<T> : IEmitter128<T>
        where T : unmanaged, IEquatable<T>
{
    public const string Name = "vemitter";

    static Vec128Kind<T> Kind => default;

    readonly ISource Source;

    [MethodImpl(Inline)]
    public VEmitter128(ISource source)
        => Source = source;

    public OpIdentity Id
        => SFxIdentity.identity(Name, Kind);

    [MethodImpl(Inline)]
    public Vector128<T> Invoke()
        => Source.CpuVector<T>(Kind);
}
