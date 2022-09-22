//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IImmInjectors
    {
        /// <summary>
        /// Creates an immediate injector for unary operators with non-immediate operands of parametric width
        /// </summary>
        /// <typeparam name="W">The operand width</typeparam>
        IImmInjector UnaryInjector<W>()
            where W : ITypeWidth;

        /// <summary>
        /// Creates an immediate injector for binary operators with non-immediate operands of parametric width
        /// </summary>
        /// <typeparam name="W">The operand width</typeparam>
        IImmInjector BinaryInjector<W>()
            where W : ITypeWidth;

        /// <summary>
        /// Creates a 128-bit T-parametric unary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        IImmInjector<UnaryOp<Vector128<T>>> UnaryInjector<T>(W128 w)
            where T : unmanaged;

        /// <summary>
        /// Creates a 256-bit T-parametric unary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        IImmInjector<UnaryOp<Vector256<T>>> UnaryInjector<T>(W256 w)
            where T : unmanaged;

        /// <summary>
        /// Creates a 128-bit T-parametric binary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        IImmInjector<BinaryOp<Vector128<T>>> BinaryInjector<T>(W128 w)
            where T : unmanaged;

        /// <summary>
        /// Creates a 256-bit T-parametric binary immediate injector
        /// </summary>
        /// <param name="w">The vector operand width</param>
        /// <param name="k">The operator kind</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        IImmInjector<BinaryOp<Vector256<T>>> BinaryInjector<T>(W256 w)
            where T : unmanaged;
    }
}