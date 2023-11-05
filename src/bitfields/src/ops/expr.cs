//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Bitfields
{
    public static BfSegExpr expr<K>(in BfInterval<K> src)
        where K : unmanaged
            => new (src.Field.ToString(), src);

    [MethodImpl(Inline), Op]
    public static BfSegExpr expr(in BfInterval src)
        => new (EmptyString, src);

    public static BfSegExpr expr(in BfSegDef src)
        => new (src.SegName, src.Interval);

    public static BfSegExpr expr<K>(in BfSegDef<K> src)
        where K : unmanaged
            => new (src.SegName, src.Interval);    
}
