//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct ApiHosts : IIndex<IApiHost>
    {
        static bool host(ApiHosts src, ApiHostUri uri, out IApiHost host)
        {   var count = src.Count;
            for(var i=0; i<count; i++)
            {
                var terms = src.View;
                ref readonly var candidate = ref skip(terms,i);
                if(candidate.HostUri == uri)
                {
                    host = candidate;
                    return true;
                }
            }
            host = null;
            return false;
        }

        static bool host(ApiHosts src, Type t, out IApiHost host)
        {   var count = src.Count;
            for(var i=0; i<count; i++)
            {
                var terms = src.View;
                ref readonly var candidate = ref skip(terms,i);
                if(candidate.GetType() == t)
                {
                    host = candidate;
                    return true;
                }
            }
            host = null;
            return false;
        }

        readonly Index<IApiHost> Data;

        [MethodImpl(Inline)]
        public ApiHosts(IApiHost[] src)
            => Data = src;

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public Span<IApiHost> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<IApiHost> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref IApiHost First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public IApiHost[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool Host(Type t, out IApiHost h)
            => host(this, t, out h);

        public bool Host(ApiHostUri uri, out IApiHost h)
            => host(this, uri, out h);

        public string Format()
            => Seq.format(Storage,Eol);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiHosts(IApiHost[] src)
            => new ApiHosts(src);

        [MethodImpl(Inline)]
        public static implicit operator IApiHost[](ApiHosts src)
            => src.Data;
    }
}