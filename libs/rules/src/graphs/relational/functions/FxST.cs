//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct PointFunctions
    {
        public readonly ref struct Fx<S,T>
            where S : unmanaged
            where T : unmanaged
        {
            public readonly ReadOnlySpan<S> Source;

            public readonly ReadOnlySpan<T> Target;

            public Fx(in Fx src)
            {
                Source = recover<S>(src.Domain);
                Target = recover<T>(src.Range);
            }

            [MethodImpl(Inline)]
            public static implicit operator Fx<S,T>(Fx src)
                => new Fx<S,T>(src);
        }
    }
}