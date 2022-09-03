//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using BLK = BinaryBitLogicKind;

    public interface IBitVectorLogix
    {
        BinaryOp<ScalarBits<T>> Lookup<T>(BLK kind)
            where T : unmanaged;

        ScalarBits<T> EvalDirect<T>(BLK kind, ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged;

        ScalarBits<T> EvalRef<T>(BLK kind, ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged;
    }
}