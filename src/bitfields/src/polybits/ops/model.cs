//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    public static BfModel model(BfOrigin origin, string name, Seq<BfSegModel> segs, DataSize size)
        => new (origin, name, segs, size);

    public static BfModel model(BfOrigin origin, string name, Seq<BfSegModel> segs)
        => model(origin, name, segs, minsize(segs.View));
}
