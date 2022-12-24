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

    [Free]
    public interface IBlockMap<G,T>
        where T : unmanaged
        where G : unmanaged, IGBlock
    {
        G Map(ReadOnlySpan<T> src);

    }

    [ApiHost, Free]
    public class GBlocks
    {
        const NumericKind Closure = UnsignedInts;
       
        public static void cells<G,R>(in G src, R dst)
            where G : unmanaged, IGBlock
            where R : unmanaged, IBlockMap<G,R>
        {
            
        }
    }
}