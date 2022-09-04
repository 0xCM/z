//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct VEmitter512<T> : IEmitter512<T>
        where T : unmanaged
    {
        public const string Name = "vemitter";

        readonly ISource Source;

        static Vec512Kind<T> Kind => default;

        [MethodImpl(Inline)]
        public VEmitter512(ISource src)
            => Source = src;

        public _OpIdentity Id
            => SFxIdentity.identity(Name, Kind);

        [MethodImpl(Inline)]
        public Vector512<T> Invoke()
            => Source.CpuVector<T>(Kind);
    }
}