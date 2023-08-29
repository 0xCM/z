//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public struct CellCycle<T>
    where T : unmanaged
{
    Index<T> Cells;

    ulong Current;

    ulong Last;

    [MethodImpl(Inline)]
    public CellCycle(Index<T> src)
    {
        Cells = src;
        Current = 0;
        Last = (ulong)src.Length - 1ul;
    }

    [MethodImpl(Inline)]
    public ref readonly T Next()
    {
        ref readonly var x = ref Cells[Current++];
        if(Current == Last)
            Current = 0;
        return ref x;
    }
}
