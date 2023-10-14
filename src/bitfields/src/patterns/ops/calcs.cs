//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    // [MethodImpl(Inline), Op]
    // public static BpCalcs calcs<P>(string name, in BitPattern pattern, P src)
    //     where P : unmanaged
    //         => calcs(def(name,pattern,src));

    // [MethodImpl(Inline), Op]
    // public static BpCalcs calcs(string name, in BitPattern pattern, BfOrigin origin)
    //     => calcs(def(name, pattern, origin));

    [MethodImpl(Inline), Op]
    public static BpCalcs calcs(in BpDef def)
        => new (def);

    [MethodImpl(Inline), Op]
    public static BpCalcs<P> calcs<P>()
        where P : unmanaged, IBpDef<P>
            => default(P);
}

