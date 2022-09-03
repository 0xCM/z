//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct V256UnaryOpImmInjector : IImmInjector
    {
        public IMultiDiviner Diviner {get;}

        [MethodImpl(Inline)]
        public static IImmInjector Create(IMultiDiviner diviner)
            => new V256UnaryOpImmInjector(diviner);

        [MethodImpl(Inline)]
        public static V256UnaryOpImmInjector<T> Create<T>(IMultiDiviner diviner)
            where T : unmanaged
                => new V256UnaryOpImmInjector<T>(diviner);

        [MethodImpl(Inline)]
        internal V256UnaryOpImmInjector(IMultiDiviner diviner)
        {
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate Inject(MethodInfo src, byte imm)
            => DynamicImmediate.EmbedV256UnaryOpImm(src,imm,Diviner.Identify(src));
    }

    readonly struct V256UnaryOpImmInjector<T> : IImmInjector<UnaryOp<Vector256<T>>>
        where T : unmanaged
    {
        public IMultiDiviner Diviner {get;}

        [MethodImpl(Inline)]
        public V256UnaryOpImmInjector(IMultiDiviner diviner)
        {
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate<UnaryOp<Vector256<T>>> EmbedImmediate(MethodInfo src, byte imm)
            => DynamicImmediate.EmbedVUnaryOpImm(VK.vk256<T>(), Diviner.Identify(src), src, imm);
    }
}