//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a receiver-predicated sink
    /// </summary>
    public readonly struct Sink<T> : ISink<T>
    {
        readonly Receiver<T> Target;

        [MethodImpl(Inline)]
        public Sink(Receiver<T> dst)
            => Target = dst;

        [MethodImpl(Inline)]
        public void Deposit(T src)
            => Target(src);
    }
}