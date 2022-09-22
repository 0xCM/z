//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct Operand<K,T> : IOperand<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public readonly K Kind;

        public readonly T Value;

        [MethodImpl(Inline)]
        public Operand(K kind, T value)
        {
            Kind = kind;
            Value = value;
        }

        K IOperand<K,T>.Kind
            => Kind;

        T IOperand<T>.Value
            => Value;
    }

}