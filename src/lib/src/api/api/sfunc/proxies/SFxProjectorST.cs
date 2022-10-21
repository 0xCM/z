//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SFxProjector<S,T> : ISFxProjector<S,T>
    {
        readonly Func<S,T> Fx;

        [MethodImpl(Inline)]
        public SFxProjector(Func<S,T> fx)
            => Fx = fx;

        [MethodImpl(Inline)]
        public T Invoke(S a)
            => Fx(a);

        [MethodImpl(Inline)]
        public static implicit operator SFxProjector<S,T>(Func<S,T> fx)
            => new SFxProjector<S,T>(fx);
    }
}