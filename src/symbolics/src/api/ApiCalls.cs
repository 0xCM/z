//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly partial struct ApiCalls
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static ApiCallData serialize<T>(in T call)
            where T : unmanaged, IApiCall<T>
                => new ApiCallData(call.Api, slice(bytes(call), 16));

        [MethodImpl(Inline)]
        public static void serialize<T>(in T call, Span<byte> dst)
            where T : unmanaged, IApiCall<T>
        {
            cpu.vstore(call.Api.V8u, ref first(dst));
            var remainder = slice(bytes(call), 16);
            var size = remainder.Length;
            var j=0;
            for(var i=16; i<size; i++)
                seek(dst,i) = skip(remainder,j++);
        }

        [MethodImpl(Inline)]
        public static ApiCall<R> call<R>(in ApiKey api, uint offset, in R result)
            where R : unmanaged
                => define(api, skip(result, offset));

        [MethodImpl(Inline)]
        public static ApiCall<A0,R> call<A0,R>(in ApiKey api, in A0 a0, in R result)
            where A0 : unmanaged
            where R : unmanaged
                => define(api, a0, result);

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, in A0 a0, in A1 a1, in R result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, a0, a1, result);

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,A2,R> call<A0,A1,A2,R>(in ApiKey api, in A0 a0, in A1 a1, A2 a2, in R result)
            where A0 : unmanaged
            where A1 : unmanaged
            where A2 : unmanaged
            where R : unmanaged
                => define(api, a0, a1, a2, result);

        [MethodImpl(Inline)]
        public static ApiCall<A0,R> call<A0,R>(in ApiKey api, uint offset, ReadOnlySpan<A0> a0, ReadOnlySpan<R> result)
            where A0 : unmanaged
            where R : unmanaged
                => define(api, skip(a0, offset), skip(result, offset));

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, uint offset, ReadOnlySpan<A0> a0, ReadOnlySpan<A1> a1, ReadOnlySpan<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, skip(a0, offset), skip(a1, offset), skip(result, offset));

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,A2,R> call<A0,A1,A2,R>(in ApiKey api, uint offset, ReadOnlySpan<A0> a0, ReadOnlySpan<A1> a1, ReadOnlySpan<A2> a2, ReadOnlySpan<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where A2 : unmanaged
            where R : unmanaged
                => define(api, skip(a0, offset), skip(a1, offset), skip(a2, offset), skip(result, offset));

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, uint offset, in SpanBlock32<A0> a0, in SpanBlock32<A1> a1, in SpanBlock32<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, a0[offset], a1[offset], result[offset]);

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, uint offset, in SpanBlock64<A0> a0, in SpanBlock64<A1> a1, in SpanBlock64<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, a0[offset], a1[offset], result[offset]);

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, uint offset, in SpanBlock128<A0> a0, in SpanBlock128<A1> a1, in SpanBlock128<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, a0[offset], a1[offset], result[offset]);

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, uint offset, in SpanBlock256<A0> a0, in SpanBlock256<A1> a1, in SpanBlock256<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, a0[offset], a1[offset], result[offset]);

        [MethodImpl(Inline)]
        public static ApiCall<A0,A1,R> call<A0,A1,R>(in ApiKey api, uint offset, in SpanBlock512<A0> a0, in SpanBlock512<A1> a1, in SpanBlock512<R> result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
                => define(api, a0[offset], a1[offset], result[offset]);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ApiCall<T,T,T> call<T>(in ApiKey api, uint offset, in ReadOnlySpan<T> a0, in ReadOnlySpan<T> a1, in ReadOnlySpan<T> result)
            where T : unmanaged
                => define(api, skip(a0, offset), skip(a1, offset), skip(result, offset));

        [MethodImpl(Inline), Op]
        public static ApiCall<uint,uint,uint> call(in ApiKey api, uint a0, uint a1, uint result)
            => define(api, a0, a1, result);

        [MethodImpl(Inline), Op]
        static ApiCall<Cell128,Cell128,Cell128> call(in ApiKey api, in Cell128 a0, in Cell128 a1, in Cell128 result)
            => define(api, a0, a1, result);

        [MethodImpl(Inline), Op]
        public static ApiCall<Cell256,Cell256,Cell256> call(in ApiKey api, in Cell256 a0, in Cell256 a1, in Cell256 result)
            => define(api, a0, a1, result);

        [MethodImpl(Inline), Op]
        public static ApiCall<Cell512,Cell512,Cell512> call(in ApiKey api, in Cell512 a0, in Cell512 a1, in Cell512 result)
            => define(api, a0, a1, result);

        [MethodImpl(Inline), Op]
        public static ApiCall<Cell8,Cell16,Cell32> call(in ApiKey api, in Cell8 a0, in Cell16 a1, in Cell32 result)
            => define(api, a0, a1, result);

        [MethodImpl(Inline), Op]
        public static ApiCall<Cell8,Cell16,Cell32,Cell64> call(in ApiKey api, in Cell8 a0, in Cell16 a1, in Cell32 a2, in Cell64 result)
            => define(api, a0, a1, a2, result);

        [MethodImpl(Inline), Op]
        public static ApiCall<Cell8,Cell16,Cell32,Cell64,Cell128> call(in ApiKey api, in Cell8 a0, in Cell16 a1, in Cell32 a2, in Cell64 a3, in Cell128 result)
            => define(api, a0, a1, a2, a3, result);

        [MethodImpl(Inline)]
        static ApiCall<R> define<R>(in ApiKey api, in R result)
            where R : unmanaged
        {
            var dst = new ApiCall<R>();
            dst.Api = api;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline)]
        static ApiCall<A0,R> define<A0,R>(in ApiKey api, in A0 a0, in R result)
            where A0 : unmanaged
            where R : unmanaged
        {
            var dst = new ApiCall<A0,R>();
            dst.Api = api;
            dst.Arg0 = a0;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline)]
        static ApiCall<A0,A1,R> define<A0,A1,R>(in ApiKey api, in A0 a0, in A1 a1, in R result)
            where A0 : unmanaged
            where A1 : unmanaged
            where R : unmanaged
        {
            var dst = new ApiCall<A0,A1,R>();
            dst.Api = api;
            dst.Arg0 = a0;
            dst.Arg1 = a1;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline)]
        static ApiCall<A0,A1,A2,R> define<A0,A1,A2,R>(in ApiKey api, in A0 a0, in A1 a1, in A2 a2, in R result)
            where A0 : unmanaged
            where A1 : unmanaged
            where A2 : unmanaged
            where R : unmanaged
        {
            var dst = new ApiCall<A0,A1,A2,R>();
            dst.Api = api;
            dst.Arg0 = a0;
            dst.Arg1 = a1;
            dst.Arg2 = a2;
            dst.Result = result;
            return dst;
        }

        [MethodImpl(Inline)]
        static ApiCall<A0,A1,A2,A3,R> define<A0,A1,A2,A3,R>(in ApiKey api, in A0 a0, in A1 a1, in A2 a2, in A3 a3, in R result)
            where A0 : unmanaged
            where A1 : unmanaged
            where A2 : unmanaged
            where A3 : unmanaged
            where R : unmanaged
        {
            var dst = new ApiCall<A0,A1,A2,A3,R>();
            dst.Api = api;
            dst.Arg0 = a0;
            dst.Arg1 = a1;
            dst.Arg2 = a2;
            dst.Arg3 = a3;
            dst.Result = result;
            return dst;
        }

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ApiCall<T,T,T> call<T>(in ApiKey api, uint offset, in T a0, in T a1, in T value)
        //     where T : unmanaged
        //         => define(api, skip(a0,offset), skip(a1, offset), skip(value, offset));

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ApiCall<T,T,T,T> call<T>(in ApiKey api, uint offset, in T a0, in T a1, in T a2, in T result)
        //     where T : unmanaged
        //         => define(api, skip(a0,offset), skip(a1, offset), skip(a2,offset), skip(result, offset));

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static void store<T>(in ApiCall<T,T,T> src, Span<byte> dst)
        //     where T : unmanaged
        //         => serialize(src, dst);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ApiCallData data<T>(in ApiCall<T,T,T> src)
        //     where T : unmanaged
        //         => ApiCallData.serialize(src);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ApiCallData data<T>(in ApiKey api, uint offset, in T a0, in T a1, in T result)
        //     where T : unmanaged
        //         => call<T>(api,offset, a0, a1, result);

        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static ApiCallData data<T>(in ApiKey api, uint offset, in T a0, in T a1, in T a2, in T result)
        //     where T : unmanaged
        //         => call<T>(api,offset, a0, a1, a2, result);
   }
}