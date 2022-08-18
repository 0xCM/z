//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a logic gate that receives 1 bit
    /// </summary>
    public interface IUnaryGate : ILogicGate
    {
        bit Invoke(bit a);
    }

    /// <summary>
    /// Characterizes a set of logic gates where each member accepts 1 bit of input
    /// </summary>
    /// <typeparam name="T">A type that defines a finite sequence of bits</typeparam>
    public interface IUnaryGate<T> : IUnaryGate, IUnaryOp<T>
        where T : unmanaged
    {

    }

    public interface IUnaryGate128<T> : IUnaryGate<Vector128<T>>
        where T : unmanaged
    {

    }

    public interface IUnaryGate256<T> : IUnaryGate<Vector256<T>>
        where T : unmanaged
    {

    }

    public interface IUnaryGate512<T> : IUnaryGate<Vector512<T>>
        where T : unmanaged
    {

    }
}