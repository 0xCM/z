//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a binary function F:A -> byte -> A that accepts an 8-bit immediate value in the second parameter.
    /// </summary>
    /// <typeparam name="A">The operand type</typeparam>
    /// <remarks>
    /// Immediates are constant values, embedded directly in an instruction. So, given such a function
    /// when closed over a constant value, it effectively becomes a unary operator. This observation
    /// justifies the contract name
    /// </remarks>
    [Free, SFx]
    public interface IUnaryImm8Op<A> :  IFunc<A,byte,A>
    {

    }

    /// <summary>
    /// Characterizes a ternary function F:A -> byte -> byte -> A that accepts 8-bit
    /// immediate values in the second and third parameters.
    /// </summary>
    /// <typeparam name="A">The operand type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8x2Op<A> : IFunc<A,byte,byte,A>
    {

    }

    /// <summary>
    /// Characterizes a unary vectorized operator that accepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="W">The bit-width type</typeparam>
    /// <typeparam name="V">The operand type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8Op<W,V,T> : IUnaryImm8Op<V>
        where W : unmanaged, ITypeWidth
    {
    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 128-bit operands that acepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8Op128<T> : IUnaryImm8Op<W128,Vector128<T>,T>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 256-bit operands that acepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8Op256<T> : IUnaryImm8Op<W256,Vector256<T>,T>, IFunc256<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a unary function that accepts a 128-bit vector and an 8-bit immediate and returns a scalar value
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface IUnaryScalarImm8Op128<T,K> : IFunc<Vector128<T>,byte,K>, IFunc128<T>
        where T : unmanaged
        where K : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a unary function that accepts a 256-bit vector argument along with an 8-bit immediate and returns a scalar value
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    /// <typeparam name="K">The scalar result type</typeparam>
    [Free, SFx]
    public interface IUnaryScalarImm8Op256<T,K> : IFunc<Vector256<T>,byte,K>, IFunc256<T>
        where K : unmanaged
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a unary vectorized operator that accepts two 8-bit immediates
    /// </summary>
    /// <typeparam name="W">The bit-width type</typeparam>
    /// <typeparam name="V">The operand type</typeparam>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8x2Op<W,V,T> : IUnaryImm8x2Op<V>
        where W : unmanaged, ITypeWidth
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 128-bit operands that acepts two 8-bit immediates
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8x2Op128<T> : IUnaryImm8x2Op<W128,Vector128<T>,T>, IFunc128<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 256-bit operands that acepts two 8-bit immediates
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8x2Op256<T> : IUnaryImm8x2Op<W256,Vector256<T>,T>, IFunc256<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 128-bit operands that acepts two 8-bit immediates
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8x2Op128D<T> : IUnaryImm8x2Op128<T>, IUnaryImm8x2Op<T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a vectorized unary operator over 256-bit operands that acepts an 8-bit immediate
    /// </summary>
    /// <typeparam name="T">The vector component type</typeparam>
    [Free, SFx]
    public interface IUnaryImm8x2Op256D<T> : IUnaryImm8x2Op256<T>, IUnaryImm8x2Op<T>
        where T : unmanaged
    {

    }

}