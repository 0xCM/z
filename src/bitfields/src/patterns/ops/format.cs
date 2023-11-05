//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
     public static string format(in BfSegExpr src)
        => src.SegWidth == 1 ? string.Format("{0}[{1}]", src.SegName, src.MaxPos) : string.Format("{0}[{1}:{2}]", src.SegName, src.MaxPos, src.MinPos);
        
    public static string format(in BpDef src)
        => string.Format("{0}[{1}]", src.Name, src.Expr);

    public static string format<P>(in BpDef<P> src)
        where P : unmanaged, IBitPattern<P>
            => string.Format("{0}[{1}]", src.Name, src.Pattern);       
}