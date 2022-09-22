//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct V256BinaryOpImmInjector : IImmInjector
    {
        readonly IMultiDiviner Diviner;

        [MethodImpl(Inline)]
        public static IImmInjector Create(IMultiDiviner diviner)
            => new V256BinaryOpImmInjector(diviner);

        [MethodImpl(Inline)]
        public static V256BinaryOpImmInjector<T> Create<T>(IMultiDiviner diviner)
            where T : unmanaged
                => new V256BinaryOpImmInjector<T>(diviner);

        [MethodImpl(Inline)]
        internal V256BinaryOpImmInjector(IMultiDiviner diviner)
        {
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate Inject(MethodInfo src, byte imm)
            => DynamicImmediate.EmbedVBinaryOpImm(w256, src,imm, Diviner.Identify(src)).Require();
    }

    readonly struct V256BinaryOpImmInjector<T> : IImmInjector<BinaryOp<Vector256<T>>>
        where T : unmanaged
    {
        readonly IMultiDiviner Diviner;

        [MethodImpl(Inline)]
        public V256BinaryOpImmInjector(IMultiDiviner diviner)
        {
            Diviner = diviner;
        }

        [MethodImpl(Inline)]
        public DynamicDelegate<BinaryOp<Vector256<T>>> EmbedImmediate(MethodInfo src, byte imm)
        {
            var constructed = src.Reify(typeof(T));
            var id = Diviner.Identify(src).WithImm8(imm);
            var tOperand = typeof(Vector256<T>);
            var dst = DynamicImmediate.DynamicSignature(constructed.Name, constructed.DeclaringType, tOperand, tOperand, tOperand);
            dst.GetILGenerator().EmitImmBinaryCall(constructed,imm);
            return Delegates.dynamic<BinaryOp<Vector256<T>>>(id, constructed, dst);
        }
    }
}