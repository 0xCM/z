//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = OperationKind;

    public readonly struct UnaryActionClass : IOperationClass<K>
    {
        public K Kind => K.UnaryAction;
    }

    public readonly struct UnaryActionClass<T> : IOperationClassHost<UnaryActionClass<T>,K,T>
        where T : unmanaged
    {
        public K Kind => K.UnaryAction;
    }
}