//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public struct CellCycle<T>
    where T : unmanaged
{
    readonly Seq<T> Cells;

    uint Current;

    uint Last;

    [MethodImpl(Inline)]
    public CellCycle(Seq<T> src)
    {
        Cells = src;
        Current = 0;
        Last = (uint)src.Length - 1u;
    }

    [MethodImpl(Inline)]
    public ref readonly T Next()
    {
        ref var x = ref Cells[Current++];
        if(Current == Last)
            Current = 0;
        return ref x;
    }
}
