//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ApiResolver : WfSvc<ApiResolver>
    {
        readonly HashSet<string> Exclusions;

        readonly IMultiDiviner Identity;

        public ApiResolver()
        {
            Identity = MultiDiviner.Service;
            Exclusions = hashset("ToString","GetHashCode", "Equals", "ToString", "Format", "CompareTo");
        }

        [Op]
        public static uint MethodCount(ReadOnlySpan<ResolvedPart> src)
        {
            var counter = 0u;
            var k0 = (uint)src.Length;
            for(var i0=0u; i0<k0; i0++)
            {
                ref readonly var part = ref skip(src,i0);
                var hosts = part.Hosts.View;
                var k1 = (uint)hosts.Length;
                for(var i1=0u; i1<k1; i1++)
                    counter += skip(hosts, i1).Methods.Count;
            }
            return counter;
        }

        [Op]
        public static uint methods(ReadOnlySpan<ResolvedPart> src, Span<ResolvedMethod> dst)
        {
            var k0 = src.Length;
            var counter = 0u;
            for(var i0=0; i0<k0; i0++)
            {
                ref readonly var part = ref skip(src,i0);
                var hosts = part.Hosts.View;
                var k1 = (uint)hosts.Length;
                for(var i1=0u; i1<k1; i1++)
                {
                    var methods = skip(hosts,i1).Methods.View;
                    var k2 = methods.Length;
                    for(var i2=0; i2<k2; i2++)
                        seek(dst, counter++) = skip(methods,i2);
                }
            }
            return counter;
        }

        /// <summary>
        /// Resolves the methods defined in a specifed set of parts
        /// </summary>
        /// <param name="src">The source parts</param>
        public static ReadOnlySpan<ResolvedMethod> methods(ReadOnlySpan<ResolvedPart> src)
        {
            var dst = list<ResolvedMethod>();
            for(var i=0; i<src.Length; i++)
            {
                var hosts = skip(src,i).Hosts.View;
                for(var j=0; j<hosts.Length; j++)
                {
                    var methods = skip(hosts,j).Methods.View;
                    iter(methods, m => dst.Add(m));
                }
            }
            return dst.ViewDeposited();
        }

        public Index<ApiMemberInfo> Describe(in ResolvedPart src)
        {
            var buffer = alloc<ApiMemberInfo>(src.MethodCount);
            Describe(src,buffer);
            return buffer;
        }

        public Index<ApiMemberInfo> ResolveParts(Index<PartId> src, Index<ResolvedPart> dst)
        {
            for(var i=0; i<src.Length; i++)
                dst[i] = ResolvePart(src[i]);
            var methods = alloc<ApiMemberInfo>(MethodCount(dst));
            Members(dst.View, methods);
            return methods;
        }

        public void Members(ReadOnlySpan<ResolvedPart> src, Index<ApiMemberInfo> dst)
        {
            var q = 0u;
            for(var i=0; i<src.Length;i++)
            {
                ref readonly var part = ref skip(src,i);
                ref readonly var hosts = ref part.Hosts;
                for(var j=0; j<hosts.Length; j++)
                {
                    ref readonly var host = ref hosts[j];
                    ref readonly var methods = ref host.Methods;
                    for(var k=0; i<methods.Count; k++, q++)
                        dst[q] = ClrDynamic.describe(methods[k]);
                }
            }
        }

        public ReadOnlySpan<ApiMemberInfo> ResolveParts(params PartId[] parts)
        {
            var count = parts.Length;
            var buffer = list<ResolvedPart>();
            for(var i=0; i<count; i++)
                buffer.Add(ResolvePart(skip(parts,i)));

            var kMethods = 0u;
            iter(buffer, p => kMethods += (uint)p.MethodCount);
            var methods = alloc<ApiMemberInfo>(kMethods);
            Describe(buffer.ViewDeposited(), methods);
            return methods;
        }

        void Describe(ReadOnlySpan<ResolvedPart> src, Span<ApiMemberInfo> dst)
        {
            var count = src.Length;
            var offset = 0u;
            for(var i=0; i<count; i++)
                offset += Describe(skip(src,i), slice(dst,offset));
            TableEmit(@readonly(dst), FS.FilePath.Empty);
        }

        public uint Describe(in ResolvedPart src, Span<ApiMemberInfo> dst)
        {
            var hosts = src.Hosts.View;
            var count = hosts.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var host = ref skip(hosts,i);
                var methods = host.Methods.View;
                var mCount = methods.Length;
                for(var j=0; j<mCount; j++)
                    seek(dst,counter++) = ClrDynamic.describe(skip(methods,j));
            }
            return counter;
        }

        public uint ResolveCatalog(IApiCatalog src, List<ResolvedPart> dst)
        {
            var counter = 0u;
            foreach(var part in src.Parts)
                counter += ResolvePart(part, dst);
            return counter;
        }

        public ResolvedPart ResolvePart(PartId id)
        {
            if(Wf.ApiCatalog.FindPart(id, out var part))
                return ResolvePart(part.Owner, out _);
            else
                return ResolvedPart.Empty;
        }

        public uint ResolvePart(IPart src, List<ResolvedPart> dst)
        {
            dst.Add(ResolvePart(src.Owner, out var counter));
            return counter;
        }

        public ResolvedHost ResolveHost(IApiHost src)
        {
            var dst = list<ResolvedMethod>();
            ResolveHost(src, dst);
            if(dst.Count != 0)
            {
                dst.Sort();
                var methods = dst.ToArray();
                return new ResolvedHost(src.HostUri, first(methods).EntryPoint, methods);
            }
            else
                return ResolvedHost.Empty;
        }

        public ResolvedPart ResolvePart(IPart src)
            => ResolvePart(src.Owner, out var counter);

        public ReadOnlySpan<ResolvedPart> ResolveCatalog(IApiCatalog src)
        {
            var dst = list<ResolvedPart>();
            var parts = @readonly(src.Parts);
            var count = parts.Length;
            for(var i=0; i<count; i++)
                dst.Add(ResolvePart(skip(parts,i)));
            return dst.ViewDeposited();
        }

        public ReadOnlySpan<ResolvedPart> ResolveParts(ReadOnlySpan<PartId> src)
        {
            var flow = Wf.Running(string.Format("Resolving parts [{0}]", src.Delimit(Chars.Comma).Format()));
            var count = src.Length;
            var buffer = alloc<ResolvedPart>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst, i) = ResolvePart(skip(src, i));
            Wf.Ran(flow);
            return buffer;
        }

        public ResolvedPart ResolvePart(Assembly src, out uint counter)
        {
            counter = 0u;
            var location = FS.path(src.Location);
            var id = src.Id();
            var catalog = ApiRuntime.catalog(src);
            var flow = Wf.Running(string.Format("Resolving part {0}", id));
            var hosts = list<ResolvedHost>();
            foreach(var host in catalog.ApiTypes)
            {
                var methods = list<ResolvedMethod>();
                var count = ResolveComplete(host, methods);
                if(count != 0)
                {
                    var resolved = methods.ToArray().Sort();
                    var @base = first(resolved).EntryPoint;
                    hosts.Add(new ResolvedHost(host, @base, resolved));
                    counter += (uint)resolved.Length;
                }
            }

            foreach(var host in catalog.ApiHosts)
            {
                var methods = list<ResolvedMethod>();
                var count = ResolveHost(host, methods);
                if(count != 0)
                {
                    var resolved = methods.ToArray().Sort();
                    var @base = first(resolved).EntryPoint;
                    hosts.Add(new ResolvedHost(host.HostUri, @base, resolved));
                    counter += (uint)resolved.Length;
                }
            }

            var result = new ResolvedPart(id, location, hosts.ToArray());
            Wf.Ran(flow, string.Format("Resolved {0} members from {1}", counter, id));
            return result;
        }

        public ResolvedPart ResolvePart(IPart src, out uint counter)
        {
            counter = 0u;

            var location = FS.path(src.Owner.Location);
            var catalog = ApiRuntime.catalog(src.Owner);
            var flow = Wf.Running(string.Format("Resolving part {0}", src.Id));
            var hosts = list<ResolvedHost>();

            foreach(var host in catalog.ApiTypes)
            {
                var methods = list<ResolvedMethod>();
                var count = ResolveComplete(host, methods);
                if(count != 0)
                {
                    var resolved = methods.ToArray().Sort();
                    var @base = first(resolved).EntryPoint;
                    hosts.Add(new ResolvedHost(host, @base, resolved));
                    counter += (uint)resolved.Length;
                }
            }

            foreach(var host in catalog.ApiHosts)
            {
                var methods = list<ResolvedMethod>();
                var count = ResolveHost(host, methods);
                if(count != 0)
                {
                    var resolved = methods.ToArray().Sort();
                    var @base = first(resolved).EntryPoint;
                    hosts.Add(new ResolvedHost(host.HostUri, @base, resolved));
                    counter += (uint)resolved.Length;
                }
            }

            var result = new ResolvedPart(src.Id, location, hosts.ToArray());
            Wf.Ran(flow, string.Format("Resolved {0} members from {1}", counter, src.Id));
            return result;
        }

        public uint ResolveHost(IApiHost src, List<ResolvedMethod> dst)
        {
            var counter = 0u;

            var flow = Wf.Running(string.Format("Resolving {0} members", src.HostUri));
            foreach(var method in ApiQuery.nongeneric(src))
            {
                dst.Add(new ResolvedMethod(method, MemberUri(src.HostUri, method), ClrJit.jit(method)));
                counter++;
            }

            foreach(var method in ApiQuery.generic(src))
            {
                foreach(var arg in ApiIdentityKinds.NumericClosureTypes(method))
                {
                    try
                    {
                        var constructed = method.MakeGenericMethod(arg);
                        dst.Add(new ResolvedMethod(constructed, MemberUri(src.HostUri, constructed), ClrJit.jit(constructed)));
                        counter++;
                    }
                    catch(Exception e)
                    {
                        Wf.Warn(e.Message);
                    }
                }
            }

            Wf.Ran(flow, string.Format("Resolved {0} {1} members", counter, src.HostUri));
            return counter;
        }

        public uint ResolveComplete(ApiCompleteType src, List<ResolvedMethod> dst)
        {
            var flow = Wf.Running(string.Format("Resolving type {0}", src.HostUri));
            var counter = 0u;
            foreach(var method in ApiQuery.methods(src, Exclusions))
            {
                dst.Add(new ResolvedMethod(method, MemberUri(src.HostUri, method), ClrJit.jit(method)));
                counter++;
            }

            Wf.Ran(flow, string.Format("Resolved {0} members from {1}", counter, src.HostUri));
            return counter;
        }

        OpUri MemberUri(ApiHostUri host, MethodInfo method)
            => ApiIdentity.define(ApiUriScheme.Located, host, method.Name, Identity.Identify(method));
    }
}