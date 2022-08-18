//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free, SFx]
    public interface IReadOnlySpanFactory<S,T> : IFunc
    {
        ReadOnlySpan<T> Invoke(in S src);
    }


    [Free, SFx]
    public interface IReadOnlySpanFactory<H,S,T> : IReadOnlySpanFactory<S,T>
        where H : struct, IReadOnlySpanFactory<H,S,T>
    {

    }
}