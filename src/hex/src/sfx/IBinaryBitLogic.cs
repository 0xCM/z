//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Free]
public interface IBinaryBitLogic<T>
{
    T and(T a, T b);

    T or(T a, T b);

    T xor(T a, T b);

    T nand(T a, T b);

    T nor(T a, T b);

    T xnor(T a, T b);

    T impl(T a, T b);

    T nonimpl(T a, T b);

    T cimpl(T a, T b);

    T cnonimpl(T a, T b);

    T eval<K>(T a, T b, K kind = default)
        where K : unmanaged, IApiBitLogicClass;
}
