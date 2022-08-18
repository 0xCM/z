//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    /// <summary>
    /// Characterizes an unmanaged expression reification with unmanaged <typeparamref name='T'/> operands
    /// </summary>
    /// <typeparam name="F">The expression kind</typeparam>
    /// <typeparam name="T">The operand type</typeparam>
    [Free]
    public interface IFreeExpr<F,T> : IFreeExpr<F>
        where F : IFreeExpr<F,T>
        where T : unmanaged
    {
        uint IFreeExpr.Size
            => (uint)SizeOf<T>();
    }

    /// <summary>
    /// Characterizes a kinded unmanaged expression reification with unmanaged <typeparamref name='T'/> operands
    /// </summary>
    /// <typeparam name="F">The expression kind</typeparam>
    /// <typeparam name="T">The operand type</typeparam>
    [Free]
    public interface IFreeExpr<F,K,T> : IFreeExpr<F,T>
        where F : IFreeExpr<F,T>
        where T : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes an unmanaged expression
    /// </summary>
    [Free]
    public interface IFreeExpr : IExpr
    {
        uint Size {get;}

        bool INullity.IsEmpty
            => Size == 0;

        bool INullity.IsNonEmpty
            => Size != 0;

        string IExpr.Format()
            => EmptyString;
    }

    /// <summary>
    /// Characterizes an unmanaged expression reification
    /// </summary>
    /// <typeparam name="F">The concrete expression type</typeparam>
    [Free]
    public interface IFreeExpr<F> : IFreeExpr
        where F : IFreeExpr<F>
    {
    }

    [Free]
    public interface IFreeCmpPred : IFreeExpr
    {

    }

    [Free]
    public interface IFreeCmpPred<H> : IFreeCmpPred
        where H : IFreeCmpPred<H>
    {

    }


}