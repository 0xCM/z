//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = OperationKind;

    public readonly struct ActionClass : IOperationClass<K>
    {
        public K Kind => K.Action;
    }
}