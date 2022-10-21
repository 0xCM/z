//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = OperationKind;

    public readonly struct ReceiverClass : IOperationClass<K>
    {
        public K Kind => K.Receiver;
    }

    public readonly struct ReceiverClass<T> : IOperationClassHost<ReceiverClass<T>,K,T>
        where T : unmanaged
    {
        public K Kind => K.Receiver;
    }
}