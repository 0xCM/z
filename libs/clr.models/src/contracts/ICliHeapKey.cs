//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICliHeapKey
    {
        CliHeapKind HeapKind {get;}

        uint Value {get;}
    }

    public interface ICliHeapKey<K> : ICliHeapKey
        where K : struct, ICliHeapKey<K>
    {

    }
}