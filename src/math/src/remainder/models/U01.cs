//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a unit interval
    /// </summary>
    public readonly struct U01<T>
        where T : unmanaged, IEquatable<T>
    {
        public T Left
        {
            [MethodImpl(Inline)]
            get => zero<T>();
        }

        public T Right
        {
            [MethodImpl(Inline)]
            get => one<T>();
        }

        [MethodImpl(Inline)]
        public static implicit operator ClosedInterval<T>(U01<T> src)
            => new ClosedInterval<T>(src.Left, src.Right);
    }
}