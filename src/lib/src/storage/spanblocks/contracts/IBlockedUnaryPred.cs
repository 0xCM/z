//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IBlockedUnaryPred8<T> : IBlockedFunc<W8,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock8<T> src, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryPred16<T> : IBlockedFunc<W16,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock16<T> src, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryPred32<T> : IBlockedFunc<W32,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock32<T> src, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryPred64<T> : IBlockedFunc<W64,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock64<T> src, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryPred128<T> : IBlockedFunc<W128,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock128<T> src, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryPred256<T> : IBlockedFunc<W256,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock256<T> src, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedUnaryPred512<T> : IBlockedFunc<W512,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock512<T> src, Span<bit> dst);
    }
}