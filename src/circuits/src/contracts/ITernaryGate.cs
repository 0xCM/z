//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a logic gate that receives 3 bits
    /// </summary>
    public interface ITernaryGate : ILogicGate
    {
        bit Invoke(bit a, bit b, bit c);
    }

    /// <summary>
    /// Characterizes a set of logic gates where each member accepts 3 bits of input
    /// </summary>
    /// <typeparam name="T">A type that defines a finite sequence of bits</typeparam>
    public interface ITernaryGate<T> : ITernaryGate, ITernaryOp<T>
        where T : unmanaged
    {

    }


    public interface ITernaryGate128<T> : ITernaryGate<Vector128<T>>
        where T : unmanaged
    {

    }

    public interface ITernaryGate256<T> : ITernaryGate<Vector256<T>>
        where T : unmanaged
    {

    }


}