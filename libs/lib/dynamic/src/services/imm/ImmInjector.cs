//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ImmInjector : IImmInjector
    {
        readonly IMultiDiviner Diviner;

        readonly IImmInjector Injective;

        [MethodImpl(Inline)]
        public DynamicDelegate Inject(MethodInfo method, byte imm)
            => Injective.Inject(method, imm);

        [MethodImpl(Inline)]
        public static ImmInjector<D> from<D>(IMultiDiviner diviner, IImmInjector<D> factory)
            where D : Delegate
                => new ImmInjector<D>(diviner, factory);

        [MethodImpl(Inline)]
        public static IImmInjector create(IMultiDiviner diviner, Vec128Type v, UnaryOperatorClass k)
            => new ImmInjector(diviner, v, k);

        [MethodImpl(Inline)]
        public static IImmInjector create(IMultiDiviner diviner, Vec256Type v, UnaryOperatorClass k)
            => new ImmInjector(diviner, v, k);

        [MethodImpl(Inline)]
        public static IImmInjector create(IMultiDiviner diviner, Vec128Type v, BinaryOperatorClass k)
            => new ImmInjector(diviner, v, k);

        [MethodImpl(Inline)]
        public static IImmInjector create(IMultiDiviner diviner, Vec256Type v, BinaryOperatorClass k)
            => new ImmInjector(diviner, v, k);

        [MethodImpl(Inline)]
        internal ImmInjector(IMultiDiviner diviner, Vec128Type vk, UnaryOperatorClass opk)
        {
            Injective = V128UnaryOpImmInjector.Create(diviner);
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        internal ImmInjector(IMultiDiviner diviner, Vec256Type vk, UnaryOperatorClass opk)
        {
            Injective = V256UnaryOpImmInjector.Create(diviner);
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        internal ImmInjector(IMultiDiviner diviner, Vec128Type vk, BinaryOperatorClass opk)
        {
            Injective = V128BinaryOpImmInjector.Create(diviner);
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        internal ImmInjector(IMultiDiviner diviner, Vec256Type vk, BinaryOperatorClass opk)
        {
            Injective = V256BinaryOpImmInjector.Create(diviner);
            Diviner = diviner;
        }
    }

    public readonly struct ImmInjector<D> : IImmInjector<D>
        where D : Delegate
    {
        readonly IImmInjector<D> Injective;

        public IMultiDiviner Diviner {get;}

        [MethodImpl(Inline)]
        public ImmInjector(IMultiDiviner diviner, IImmInjector<D> factory)
        {
            Diviner = diviner;
            Injective = factory;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate<D> EmbedImmediate(MethodInfo method, byte imm)
            => Injective.EmbedImmediate(method,imm);
    }
}