//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free, SFx]
    public interface IBlockedBinaryOp8<T> : IBlockedFunc<W8,T>
        where T : unmanaged
    {
        SpanBlock8<T> Invoke(SpanBlock8<T> a, SpanBlock8<T> b, SpanBlock8<T> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryOp16<T> : IBlockedFunc<W16,T>
        where T : unmanaged
    {
        SpanBlock16<T> Invoke(SpanBlock16<T> a, SpanBlock16<T> b, SpanBlock16<T> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryOp32<T> : IBlockedFunc<W32,T>
        where T : unmanaged
    {
        SpanBlock32<T> Invoke(SpanBlock32<T> a, SpanBlock32<T> b, SpanBlock32<T> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryOp64<T> : IBlockedFunc<W64,T>
        where T : unmanaged
    {
        SpanBlock64<T> Invoke(SpanBlock64<T> a, SpanBlock64<T> b, SpanBlock64<T> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryOp128<T> : IBlockedFunc<W128,T>
        where T : unmanaged
    {
        SpanBlock128<T> Invoke(SpanBlock128<T> a, SpanBlock128<T> b, SpanBlock128<T> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryOp256<T> : IBlockedFunc<W256,T>
        where T : unmanaged
    {
        SpanBlock256<T> Invoke(SpanBlock256<T> a, SpanBlock256<T> b, SpanBlock256<T> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryOp512<T> : IBlockedFunc<W512,T>
        where T : unmanaged
    {
        SpanBlock512<T> Invoke(SpanBlock512<T> a, SpanBlock512<T> b, SpanBlock512<T> dst);
    }
}