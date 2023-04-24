//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEcmaHeapKey
    {
        EcmaHeapKind HeapKind {get;}

        uint Value {get;}
    }

    public interface IEcmaHeapKey<K> : IEcmaHeapKey
        where K : struct, IEcmaHeapKey<K>
    {

    }
}