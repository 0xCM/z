//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBlockedRender
    {
        uint Render<S,B>(in S src, ref uint i, ref B dst)
            where B : unmanaged, ICharBlock<B>;

        void Render<S,B>(in S src, ref B dst)
            where B : unmanaged, ICharBlock<B>;
    }

    public interface IBlockedRender<S,B>
        where B : unmanaged, ICharBlock<B>
    {
        uint Render(in S src, ref uint i, ref B dst);

        void Render(in S src, ref B dst);
    }
}