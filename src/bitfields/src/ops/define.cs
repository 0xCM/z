//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    public static BfDef define(Seq<BfSegDef> segs, DataSize size)
        => new (segs, size);

    public static BfDef define(Seq<BfSegDef> segs)
        => define(segs, minsize(segs.View));    
}
