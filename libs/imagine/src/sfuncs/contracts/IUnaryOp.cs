//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a unary operator
    /// </summary>
    /// <typeparam name="A">The operand type</typeparam>
    [Free, SFx]
    public interface IUnaryOp<A> : IFunc<A,A>
    {
        new UnaryOp<A> Operation
            => new UnaryOp<A>((this as IFunc<A,A>).Operation);
    }

    [Free, SFx]
    public interface IUnaryOpIn<A> : IFuncIn<A,A>
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 128-bit operands
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryOp128<T> : IUnaryOp<Vector128<T>>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 256-bit operands
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryOp256<T> : IUnaryOp<Vector256<T>>, IFunc256<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 128-bit operands that also supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryOp128D<T> : IUnaryOp128<T>, IUnaryOp<T>
        where T : unmanaged
    {
    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 256-bit operands also supports componentwise decomposition/evaluation
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryOp256D<T> : IUnaryOp256<T>, IUnaryOp<T>
        where T : unmanaged
    {

    }
}