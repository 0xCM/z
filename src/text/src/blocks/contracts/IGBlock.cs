//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IGBlock : ISized
    {

    }

    [Free]
    public interface IGBlock<G> : IGBlock
        where G : unmanaged, IGBlock<G>
    {
        ByteSize ISized.ByteCount
            => sys.size<G>();
        
        BitWidth ISized.BitWidth
            => sys.width<G>();
    }
}