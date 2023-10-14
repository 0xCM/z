//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


partial struct BitPatterns
{
    public static string format(in BpDef src)
        => string.Format("{0}[{1}]", src.Name, src.Pattern);

    public static string format<P>(in BpDef<P> src)
        where P : unmanaged, IBpDef<P>
            => string.Format("{0}[{1}]", src.Name, src.Pattern);
}