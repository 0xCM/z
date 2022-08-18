//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    public class BlockedRender
    {
        readonly ConcurrentDictionary<uint,IBlockedRender> Services;

        public BlockedRender()
        {
            Services = new();
        }
    }

    readonly struct BlockedRenderService<S,B> : IBlockedRender<S,B>
        where B : unmanaged, ICharBlock<B>
    {

        readonly BlockedRender<S,B> Actor;

        [MethodImpl(Inline)]
        internal BlockedRenderService(BlockedRender<S,B> actor)
        {
            Actor = actor;
        }

        [MethodImpl(Inline)]
        public uint Render(in S src, ref uint i, ref B dst)
            => Actor.Render(src, ref i, ref dst);

        [MethodImpl(Inline)]
        public void Render(in S src, ref B dst)
            => Actor.Render(src, ref dst);
    }

    public class HexRenderTypes
    {

        public abstract class HexRender<C,S,B> : BlockedRender<S,B>
            where S : unmanaged
            where B : unmanaged, ICharBlock<B>
            where C : unmanaged, ILetterCase<C>
        {
            protected HexRender()
            {
                Spec = HexSpecKind.PreSpec;
            }

            public virtual HexSpecKind Spec {get;}

            public static C Case => default;

            [MethodImpl(Inline)]
            public override void Render(in S src, ref B dst)
            {
                var j=0u;
                if(Spec == HexSpecKind.PreSpec)
                {
                    dst[j++] = Chars.D0;
                    dst[j++] = Chars.x;
                }

                Render(src, ref j, ref dst);

                if(Spec == HexSpecKind.PostSpec)
                {
                    dst[j++] = Chars.h;
                }
            }

            [MethodImpl(Inline)]
            public void Render(ReadOnlySpan<S> src, Span<B> dst)
            {
                for(var i=0; i<src.Length; i++)
                    Render(skip(src,i), ref seek(dst,i));;
            }

        }

        public sealed class RenderL8u : HexRender<LowerCased,Hex8,CharBlock4>
        {
            [MethodImpl(Inline)]
            public override uint Render(in Hex8 src, ref uint i, ref CharBlock4 dst)
            {
                var i0 = i;
                Hex.render(Case,src, ref i, dst.Data);
                return i - i0;

            }
        }

        public sealed class Render8u : HexRender<UpperCased,Hex8,CharBlock4>
        {
            [MethodImpl(Inline)]
            public  override uint Render(in Hex8 src, ref uint i, ref CharBlock4 dst)
            {
                var i0 = i;
                Hex.render(Case,src, ref i, dst.Data);
                return i - i0;
            }
        }
    }
}