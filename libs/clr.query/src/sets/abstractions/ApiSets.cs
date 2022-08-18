//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiComplete]
    public sealed class ApiSets : IApiSets
    {
        [MethodImpl(Inline)]
        static ReadOnlySeq<Type> hosts(Assembly src)
            => src.Types().Tagged<ApiSetAttribute>();

        [MethodImpl(Inline)]
        static ReadOnlySeq<MethodInfo> ops(ReadOnlySeq<Type> src)
            => src.Storage.Methods().Tagged<ApiAttribute>();

        readonly Assembly _Source;

        readonly ReadOnlySeq<Type> _Hosts;

        readonly ReadOnlySeq<MethodInfo> _Ops;

        [MethodImpl(Inline)]
        public ApiSets(Assembly src)
        {
            _Source = src;
            _Hosts = hosts(src);
            _Ops = ops(_Hosts);
        }

        public ref readonly Assembly Source
        {
            [MethodImpl(Inline)]
            get => ref _Source;
        }

        public ref readonly ReadOnlySeq<Type> Hosts
        {
            [MethodImpl(Inline)]
            get => ref _Hosts;
        }

        public ref readonly ReadOnlySeq<MethodInfo> Ops
        {
            [MethodImpl(Inline)]
            get => ref _Ops;
        }
    }
}