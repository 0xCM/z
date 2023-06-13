//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GBlocks
    {
        [Free]
        public interface IBlockReader<G,T>
            where T : unmanaged
            where G : unmanaged, IGBlock
        {
            G Read(ReadOnlySpan<T> src);
        }

    }   
}