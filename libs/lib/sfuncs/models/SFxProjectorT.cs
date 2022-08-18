//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SFxProjector<T> : ISFxProjector<T>
    {
        readonly System.Func<T,T> Fx;

        [MethodImpl(Inline)]
        public SFxProjector(System.Func<T,T> fx)
            => Fx = fx;

        [MethodImpl(Inline)]
        public T Invoke(T a)
            => Fx(a);

        [MethodImpl(Inline)]
        public static implicit operator SFxProjector<T>(Func<T,T> fx)
            => new SFxProjector<T>(fx);
    }
}