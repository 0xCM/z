//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct Count<T> : ICount<Count<T>,T>
        where T : unmanaged
    {
        public T Value;

        [MethodImpl(Inline)]
        public Count(T value)
            => Value = value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        T ICounted<T>.Count
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator Count<T>(T value)
            => new Count<T>(value);
    }
}