//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        public static _ApiHostUri host(Type t)
            => new _ApiHostUri(t.Assembly.Id(), hostname(t));

        public static _ApiHostUri host(PartId part, string name)
            => new _ApiHostUri(part,name);

        public static string hostname(Type t)
        {
            var tag = t.Tag<ApiHostAttribute>();
            var name = tag.Exists && !string.IsNullOrWhiteSpace(tag.Value.HostName) ? tag.Value.HostName :  t.Name;
            return name.ToLowerInvariant();
        }
    }
}