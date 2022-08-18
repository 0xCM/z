//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = OperationKind;

    public readonly struct TernaryActionClass : IOperationClass<K>
    {
        public K Kind => K.TernaryAction;
    }

    public readonly struct TernaryActionClass<T> : IOperationClass<K,T>
            where T : unmanaged
    {
        public K Kind => K.TernaryAction;
    }
}