//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class BlockedRender<S,B> : IBlockedRender<S,B>
        where B : unmanaged, ICharBlock<B>
    {
        public abstract uint Render(in S src, ref uint i, ref B dst);

        public abstract void Render(in S src, ref B dst);
    }
}