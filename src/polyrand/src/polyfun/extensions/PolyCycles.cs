//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public static class PolyCycles
{
    const NumericKind Closure = AllNumeric;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ValueCycle<T> valuecycle<T>(Seq<T> src)
        where T : unmanaged
            => new (src);

    [MethodImpl(Inline)]
    public static CellCycle<T> cellcycle<T>(Seq<T> src)
        where T : unmanaged, IDataCell<T>
            => new (src);

    [MethodImpl(Inline)]
    public static ref readonly T next<T>(in CellCycle<T> src)
        where T : unmanaged, IDataCell<T>
            => ref src.Next();

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ref readonly T next<T>(in ValueCycle<T> src)
        where T : unmanaged
            => ref src.NextRef();
}
