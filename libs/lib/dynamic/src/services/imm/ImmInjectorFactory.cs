//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using I = Z0;
    using K = OperatorClasses;

    public readonly struct ImmInjectorFactory : IImmInjectors
    {
        [MethodImpl(Inline)]
        public static ImmInjectorFactory service()
            => new ImmInjectorFactory(MultiDiviner.Service);

        readonly IMultiDiviner Diviner;

        [MethodImpl(Inline)]
        internal ImmInjectorFactory(IMultiDiviner diviner)
            => Diviner = diviner;

        /// <summary>
        /// Creates a 128-bit T-parametric unary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        public IImmInjector<UnaryOp<Vector128<T>>> UnaryInjector<T>(W128 w)
            where T : unmanaged
                => ImmInjector.from(Diviner, I.V128UnaryOpImmInjector.Create<T>(Diviner));

        /// <summary>
        /// Creates a 256-bit T-parametric unary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public IImmInjector<UnaryOp<Vector256<T>>> UnaryInjector<T>(W256 w)
            where T : unmanaged
                => ImmInjector.from(Diviner, I.V256UnaryOpImmInjector.Create<T>(Diviner));

        /// <summary>
        /// Creates a 128-bit T-parametric binary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline)]
        public IImmInjector<BinaryOp<Vector128<T>>> BinaryInjector<T>(W128 w)
            where T : unmanaged
                => ImmInjector.from(Diviner, I.V128BinaryOpImmInjector.Create<T>(Diviner));

        /// <summary>
        /// Creates a 256-bit T-parametric binary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        public IImmInjector<BinaryOp<Vector256<T>>> BinaryInjector<T>(W256 w)
            where T : unmanaged
                => ImmInjector.from(Diviner, I.V256BinaryOpImmInjector.Create<T>(Diviner));

        IImmInjector IImmInjectors.UnaryInjector<W>()
        {
            if(typeof(W) == typeof(W128))
                return ImmInjector.create(Diviner, I.VK.v128, K.unary());
            else if(typeof(W) == typeof(W256))
                return ImmInjector.create(Diviner, I.VK.v256, K.unary());
            else
                throw no<W>();
        }

        IImmInjector IImmInjectors.BinaryInjector<W>()
        {
            if(typeof(W) == typeof(W128))
                return ImmInjector.create(Diviner, I.VK.v128, K.binary());
            else if(typeof(W) == typeof(W256))
                return ImmInjector.create(Diviner, I.VK.v256, K.binary());
            else
                throw no<W>();
        }
    }
}