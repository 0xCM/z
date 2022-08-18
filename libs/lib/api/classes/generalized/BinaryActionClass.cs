//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = OperationKind;

    public readonly struct BinaryActionClass : IOperationClass<K>
    {
        public K Kind => K.BinaryAction;
    }

    public readonly struct BinaryActionClass<T> : IOperationClassHost<BinaryActionClass<T>, K,T>
        where T : unmanaged
    {
        public K Kind => K.BinaryAction;
    }
}