//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IBlockedUnaryOp8<T> : IBlockedFunc<W8,T>
        where T : unmanaged
    {
        ref readonly SpanBlock8<T> Invoke(in SpanBlock8<T> src, in SpanBlock8<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryOp16<T> : IBlockedFunc<W16,T>
        where T : unmanaged
    {
        ref readonly SpanBlock16<T> Invoke(in SpanBlock16<T> src, in SpanBlock16<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryOp32<T> : IBlockedFunc<W32,T>
        where T : unmanaged
    {
        ref readonly SpanBlock32<T> Invoke(in SpanBlock32<T> src, in SpanBlock32<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryOp64<T> : IBlockedFunc<W64,T>
        where T : unmanaged
    {
        ref readonly SpanBlock64<T> Invoke(in SpanBlock64<T> src, in SpanBlock64<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryOp128<T> : IBlockedFunc<W128,T>
        where T : unmanaged
    {
        ref readonly SpanBlock128<T> Invoke(in SpanBlock128<T> src, in SpanBlock128<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryOp256<T> : IBlockedFunc<W256,T>
        where T : unmanaged
    {
        ref readonly SpanBlock256<T> Invoke(in SpanBlock256<T> src, in SpanBlock256<T> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryOp512<T> : IBlockedFunc<W512,T>
        where T : unmanaged
    {
        ref readonly SpanBlock512<T> Invoke(in SpanBlock512<T> src, in SpanBlock512<T> dst);
    }

}