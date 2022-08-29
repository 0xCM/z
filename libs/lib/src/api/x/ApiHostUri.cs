//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XApi
    {
        const NumericKind Closure = UnsignedInts;
        [Op]
        public static ApiHostUri ApiHostUri(this Type host)
        {
            if(host != null)
            {
                var tag = host.Tag<ApiHostAttribute>();
                var name = ifempty(tag.MapValueOrDefault(x => x.HostName), host.Name).ToLower();
                var owner = host.Assembly.Id();
                return new ApiHostUri(owner, name);
            }
            else
                return Z0.ApiHostUri.Empty;
        }

        public static ApiHostUri[] ApiHostUri(this Assembly src)
        {
            var dst = new List<ApiHostUri>();
            var types = src.Types().Tagged<ApiHostAttribute>();
            foreach(var t in types)
                dst.Add(t.ApiHostUri());
            return dst.ToArray();
        }

        public static ApiHostUri[] ApiHostUri(this Assembly[] src)
            => src.SelectMany(x => x.ApiHostUri());
    }
}