//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IBvUnaryOp<T> : IUnaryOp<ScalarBits<T>>
        where T : unmanaged
    {
        T Invoke(T a);
    }

    [Free, SFx]
    public interface IBvBinaryOp<T> : IBinaryOp<ScalarBits<T>>
        where T : unmanaged
    {
        T Invoke(T a, T b);
    }

    [Free, SFx]
    public interface IBvTernaryOp<T> : ITernaryOp<ScalarBits<T>>
        where T : unmanaged
    {

        T Invoke(T a, T b, T c);
    }

    [Free, SFx]
    public interface IBvUnaryPred<T> : IFunc<ScalarBits<T>, bit>
        where T : unmanaged
    {
        bit Invoke(T a);
    }

    [Free, SFx]
    public interface IBvBinaryPred<T> : IFunc<ScalarBits<T>,ScalarBits<T>,bit>
        where T : unmanaged
    {
        bit Invoke(T a, T b);
    }
}