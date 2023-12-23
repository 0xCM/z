//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class Delegates
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static UnaryOp<T> @operator<T>(System.Func<T,T> f)
        => new (f);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BinaryOp<T> @operator<T>(System.Func<T,T,T> f)
        => new (f);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static TernaryOp<T> @operator<T>(System.Func<T,T,T,T> f)
        => new (f);
}
