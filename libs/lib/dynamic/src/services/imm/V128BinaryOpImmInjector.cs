//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct V128BinaryOpImmInjector : IImmInjector
    {
        public IMultiDiviner Diviner {get;}

        [MethodImpl(Inline)]
        public static IImmInjector Create(IMultiDiviner diviner)
            => new V128BinaryOpImmInjector(diviner);

        [MethodImpl(Inline)]
        public static V128BinaryOpImmInjector<T> Create<T>(IMultiDiviner diviner)
            where T : unmanaged
                => new V128BinaryOpImmInjector<T>(diviner);

        [MethodImpl(Inline)]
        internal V128BinaryOpImmInjector(IMultiDiviner diviner)
        {
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate Inject(MethodInfo src, byte imm)
            => DynamicImmediate.EmbedVBinaryOpImm(w128, src,imm, Diviner.Identify(src)).Require();
    }

    readonly struct V128BinaryOpImmInjector<T> : IImmInjector<BinaryOp<Vector128<T>>>
        where T : unmanaged
    {
        public IMultiDiviner Diviner {get;}

        [MethodImpl(Inline)]
        public V128BinaryOpImmInjector(IMultiDiviner diviner)
        {
            this.Diviner = diviner;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate<BinaryOp<Vector128<T>>> EmbedImmediate(MethodInfo src, byte imm)
            => DynamicImmediate.EmbedVBinaryOpImm(VK.vk128<T>(), Diviner.Identify(src), src, imm);
    }
}