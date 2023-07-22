//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IHalfAdder
    {
        ConstPair<bit> Invoke(bit a, bit b);

        ConstPair<T> Invoke<T>(T a, T b)
            where T : unmanaged;

        ConstPair<Vector128<T>> Invoke<T>(Vector128<T> a, Vector128<T> b)
            where T : unmanaged;

        ConstPair<Vector256<T>> Invoke<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged;
    }

    public interface IHalfAdder<T> :
        IHalfAdder64<T>,
        IHalfAdder128<T>,
        IHalfAdder256<T>
            where T : unmanaged
    {

    }

    public interface IHalfAdder<F,T> : IHalfAdder<T>
        where F : unmanaged, IHalfAdder<F,T>
        where T : unmanaged
    {}

    public interface IHalfAdder64<A> : IFunc<A,A,ConstPair<A>>
    {


    }

    public interface IHalfAdderT<A> : IFunc<A,A,ConstPair<A>>
    {


    }

    public interface IHalfAdderIn<A> : IFuncIn<A,A,ConstPair<A>>
    {


    }

    public interface IHalfAdder128<T> :  IHalfAdderT<Vector128<T>>
        where T : unmanaged
    {

    }

    public interface IHalfAdder256<T> : IHalfAdderT<Vector256<T>>
        where T : unmanaged
    {

    }


}
