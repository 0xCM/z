//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly ref struct ApiCallData
    {
        public readonly ApiKey Api;

        public readonly ReadOnlySpan<byte> Bytes;

        [MethodImpl(Inline)]
        public ApiCallData(ApiKey api, ReadOnlySpan<byte> src)
        {
            Bytes = src;
            Api = api;
        }
    }
}