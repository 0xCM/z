//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VEmitter256<T> : IEmitter256<T>
        where T : unmanaged
    {
        public const string Name = "vemitter";

        readonly ISource Source;

        static Vec256Kind<T> Kind => default;

        [MethodImpl(Inline)]
        public VEmitter256(ISource src)
            => Source = src;

        public OpIdentity Id
            => SFxIdentity.identity(Name, Kind);

        [MethodImpl(Inline)]
        public Vector256<T> Invoke()
            => Source.CpuVector<T>(Kind);
    }
}