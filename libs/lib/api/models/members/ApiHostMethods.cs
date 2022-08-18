//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiHostMethods : IIndex<MethodInfo>
    {
        [MethodImpl(Inline), Op]
        public static ApiHostMethods load(IApiHost host, MethodInfo[] methods)
            => ApiQuery.methods(host,methods);

        [MethodImpl(Inline), Op]
        public static ApiHostMethods load(IApiHost src)
            => ApiQuery.methods(src);

        public readonly IApiHost Host;

        public readonly MethodInfo[] Storage;

        [MethodImpl(Inline)]
        public ApiHostMethods(IApiHost host, MethodInfo[] src)
        {
            Host = host;
            Storage = src;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Storage?.Length ?? 0;
        }

        public uint OpCount
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ReadOnlySpan<ClrMethodAdapter> View
        {
            [MethodImpl(Inline)]
            get => sys.recover<MethodInfo,ClrMethodAdapter>(sys.@readonly(Storage));
        }

        public static ApiHostMethods Empty
        {
            [MethodImpl(Inline)]
            get => new ApiHostMethods(ApiHost.Empty, sys.array<MethodInfo>());
        }

        MethodInfo[] IIndex<MethodInfo>.Storage 
            => Storage;

        [MethodImpl(Inline)]
        public static implicit operator MethodInfo[](ApiHostMethods src)
            => src.Storage;
    }
}