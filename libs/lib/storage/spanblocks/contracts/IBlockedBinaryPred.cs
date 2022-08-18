//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IBlockedBinaryPred8<T> : IBlockedFunc<W8,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock8<T> a, in SpanBlock8<T> b, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryPred16<T> : IBlockedFunc<W16,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock16<T> a, in SpanBlock16<T> b, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryPred32<T> : IBlockedFunc<W32,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock32<T> a, in SpanBlock32<T> b, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryPred64<T> : IBlockedFunc<W64,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock64<T> a, in SpanBlock64<T> b, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryPred128<T> : IBlockedFunc<W128,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock128<T> a, in SpanBlock128<T> b, Span<bit> dst);
    }

    [Free, SFx]
    public interface IBlockedBinaryPred256<T> : IBlockedFunc<W256,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock256<T> a, in SpanBlock256<T> b, Span<bit> dst);
    }

    [Free, SFx]
    public interface ISBBinaryPred512Api<T> : IBlockedFunc<W512,T>
        where T : unmanaged
    {
        Span<bit> Invoke(in SpanBlock512<T> a, in SpanBlock512<T> b, Span<bit> dst);
    }
}