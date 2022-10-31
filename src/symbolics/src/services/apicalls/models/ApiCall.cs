//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api =  ApiCalls;

    /// <summary>
    /// Rpresents an action invocation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public record struct ApiCall : IApiCall<ApiCall>
    {
        public ApiKey Api {get; set;}

        [MethodImpl(Inline)]
        public static implicit operator ApiCallData(ApiCall src)
            => api.serialize(src);
    }

    /// <summary>
    /// Rpresents an emitter invocation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public record struct ApiCall<R> : IApiCall<ApiCall<R>,R>
        where R : unmanaged
    {
        public ApiKey Api {get; set;}

        public R Result {get; set;}

        [MethodImpl(Inline)]
        public static implicit operator ApiCallData(ApiCall<R> src)
            => api.serialize(src);
    }

    /// <summary>
    /// Rpresents an unary function invocation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public record struct ApiCall<A0,R> : IApiCall<ApiCall<A0,R>,R>
        where A0 : unmanaged
        where R : unmanaged
    {
        public ApiKey Api {get; set;}

        public A0 Arg0;

        public R Result {get; set;}

        [MethodImpl(Inline)]
        public static implicit operator ApiCallData(ApiCall<A0,R> src)
            => api.serialize(src);
    }

    /// <summary>
    /// Rpresents a binary function invocation
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public record struct ApiCall<A0,A1,R> : IApiCall<ApiCall<A0,A1,R>,R>
        where A0 : unmanaged
        where A1 : unmanaged
        where R : unmanaged
    {
        public ApiKey Api {get; set;}

        public A0 Arg0;

        public A1 Arg1;

        public R Result {get; set;}

        public string Format()
            => $"{Api}:{Arg0} -> {Arg1} -> {Result}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiCallData(ApiCall<A0,A1,R> src)
            => api.serialize(src);
    }

    /// <summary>
    /// Rpresents a ternary function invocation
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=0)]
    public record struct ApiCall<A0,A1,A2,R> : IApiCall<ApiCall<A0,A1,A2,R>,R>
        where A0 : unmanaged
        where A1 : unmanaged
        where A2 : unmanaged
        where R : unmanaged
    {
        public ApiKey Api {get; set;}

        public A0 Arg0;

        public A1 Arg1;

        public A2 Arg2;

        public R Result {get; set;}

        [MethodImpl(Inline)]
        public static implicit operator ApiCallData(ApiCall<A0,A1,A2,R> src)
            => api.serialize(src);
    }

    [StructLayout(LayoutKind.Sequential)]
    public record struct ApiCall<A0,A1,A2,A3,R> : IApiCall<ApiCall<A0,A1,A2,A3,R>,R>
        where A0 : unmanaged
        where A1 : unmanaged
        where A2 : unmanaged
        where A3 : unmanaged
        where R : unmanaged
    {
        public ApiKey Api {get; set;}

        public A0 Arg0;

        public A1 Arg1;

        public A2 Arg2;

        public A3 Arg3;

        public R Result {get; set;}

        [MethodImpl(Inline)]
        public static implicit operator ApiCallData(ApiCall<A0,A1,A2,A3,R> src)
            => api.serialize(src);
    }
}