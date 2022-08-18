//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a function that accepts an input of parametric type
    /// </summary>
    /// <typeparam name="T">The input type</typeparam>
    [Free]
    public delegate void Receiver<T>(in T src);

    /// <summary>
    /// Characterizes a function that accepts two inputs of parametric type
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <typeparam name="A">The first operand type</typeparam>
    /// <typeparam name="B">The second operand type</typeparam>
    [Free]
    public delegate void Receiver<A,B>(in A a, in B b);

    /// <summary>
    /// Characterizes a receiver that accepts a pointer
    /// </summary>
    /// <typeparam name="T">The stream element type</typeparam>
    [Free]
    public unsafe delegate void PointedReceiver<T>(T* pSrc)
        where T : unmanaged;
}