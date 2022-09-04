//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ResolvedHost : IComparable<ResolvedHost>
    {
        public readonly _ApiHostUri Host;

        public readonly Index<ResolvedMethod> Methods;

        public readonly MemoryAddress BaseAddress;

        [MethodImpl(Inline)]
        public ResolvedHost(_ApiHostUri uri, MemoryAddress @base, Index<ResolvedMethod> methods)
        {
            Host = uri;
            Methods = methods;
            BaseAddress = @base;
        }

        public Type HostType
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? typeof(void) : Methods.First.HostType;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Host.IsEmpty;
        }

        public Assembly Component
        {
            [MethodImpl(Inline)]
            get => IsEmpty ? typeof(void).Assembly : HostType.Assembly;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Host.IsNonEmpty && Methods.IsNonEmpty;
        }

        public uint MethodCount
        {
            [MethodImpl(Inline)]
            get => Methods.Count;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ResolvedHost src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public string Format()
            => IsEmpty ? "<empty>" : string.Format("{0}::{1}:{2}", BaseAddress.Format(), Component.Format(), HostType.Format());


        public override string ToString()
            => Format();

        public static ResolvedHost Empty
        {
            [MethodImpl(Inline)]
            get => new ResolvedHost(_ApiHostUri.Empty, default, sys.empty<ResolvedMethod>());
        }
    }
}