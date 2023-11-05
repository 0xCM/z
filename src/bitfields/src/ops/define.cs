//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct Bitfields
{
    public static BfDef define(string name, Seq<BfSegDef> segs, DataSize size)
        => new (name, segs, size);

    public static BfDef define(string name, Seq<BfSegDef> segs)
        => define(name, segs, minsize(segs.View));    
}
