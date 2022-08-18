//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AssemblyRef<T> : IAssemblyRef<T>
        where T : IEquatable<T>, IComparable<T>
    {
        public readonly T Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public AssemblyRef(T src, T dst)
        {
            Source = src;
            Target = dst;
        }

        T IArrow<T,T>.Source
            => Source;

        T IArrow<T,T>.Target
            => Target;
    }
}