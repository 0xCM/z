//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    [ApiHost]
    public readonly struct ClrJit
    {
        [Op]
        public static ApiMember member(MethodInfo src, ApiHostUri host)
        {
            var uri = ApiIdentity.define(ApiUriScheme.Located, host, src.Name, MultiDiviner.Service.Identify(src));
            var address = jit(src);
            return new ApiMember(uri, src, address, ClrDynamic.msil(address, uri, src));
        }

        [Op]
        public static ApiMember member(MethodInfo src, OpUri uri)
        {
            var address = jit(src);
            return new ApiMember(uri, src, address, ClrDynamic.msil(address, uri, src));
        }

        [Op]
        public static ApiMember member(in ResolvedMethod src)
            => new ApiMember(src.Uri, src.Method, src.EntryPoint, ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method));

        [Op]
        static Index<ApiMember> members(JittedMethod[] src)
        {
            var count = src.Length;
            var dst = sys.alloc<ApiMember>(count);
            var diviner = MultiDiviner.Service;
            for(var i=0; i<count; i++)
            {
                var member = src[i];
                var method = member.Method;
                var id = diviner.Identify(method);
                var uri = ApiIdentity.define(ApiUriScheme.Located, member.Host, method.Name, id);
                dst[i] = new ApiMember(uri, method, member.Location, ClrDynamic.msil(member.Location, uri, method));
            }

            return dst;
        }

        [Op]
        public static ApiMembers jit(IApiPartCatalog src, IWfChannel channel)
        {
            var dst = list<ApiMember>();
            iter(src.ApiTypes.Select(h => h.HostType), t => dst.AddRange(complete(t,channel)));
            iter(src.ApiHosts.Select(h => h.HostType), t => dst.AddRange(jit(t, channel)));
            return ApiQuery.members(dst.ToArray());
        }

        [Op, MethodImpl(Inline)]
        static MemoryAddress fptr(MethodInfo src)
            => src.MethodHandle.GetFunctionPointer();

        [Op]
        public static MemoryAddress jit(MethodInfo src)
        {
            RuntimeHelpers.PrepareMethod(src.MethodHandle);
            return fptr(src);
        }
        [Op]
        public static MemoryAddress jit(Delegate src)
        {
            sys.prepare(src);
            return fptr(src.Method);
        }

        [Op]
        public static DynamicPointer jit(DynamicDelegate src)
        {
            sys.prepare(src.Operation);
            return ClrDynamic.pointer(src);
        }

        public static DynamicPointer jit<D>(DynamicDelegate<D> src)
            where D : Delegate
                => jit(src.Untyped);

        [Op]
        public static Index<ApiMember> complete(Type src, IWfChannel log)
            => members(complete(src, CommonExclusions).Select(m => new JittedMethod(src.ApiHostUri(), m, jit(m))));

        [Op]
        public static MethodInfo[] complete(Type src, HashSet<string> exclusions)
            => src.DeclaredMethods().Unignored().NonGeneric().Exclude(exclusions);

        [Op]
        public static ApiMembers members(IApiHost src, IWfChannel emitter)
            => ApiQuery.members(direct(src.HostType).Concat(generic(src, emitter)).Array());

        [Op]
        public static void jit(IApiHost host, ConcurrentBag<ApiHostMembers> dst, IWfChannel channel)
        {
            var jitted = jit(host, channel);
            if(jitted.IsNonEmpty)
                dst.Add(jitted);
        }

        [Op]
        public static void jit(ApiCompleteType src, ConcurrentBag<ApiHostMembers> dst, IWfChannel channel)
        {
            var jitted = ApiQuery.members(ClrJit.jit(src));
            if(jitted.IsNonEmpty)
                dst.Add(new ApiHostMembers(src.HostUri, jitted));
        }

        [Op]
        public static ApiHostMembers jit(IApiHost src, IWfChannel channel)
        {
            var dst = ApiHostMembers.Empty;
            try
            {
                dst = new (src.HostUri, jit(src.HostType, channel));
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
            return dst;
        }

        [Op]
        public static ApiMembers jit(Type src, IWfChannel log)
        {
            var direct = ClrJit.direct(src);
            var generic = ClrJit.generic(src, log);
            return ApiQuery.members(direct.Concat(generic).Array());
        }

        [Op]
        public static Index<ApiMember> jit(ApiCompleteType src)
            => members(complete(src.HostType, CommonExclusions).Select(m => new JittedMethod(src.HostUri, m, ClrJit.jit(m))));

        [Op]
        static ApiMember[] direct(Type src)
        {
            var uri = src.ApiHostUri();
            var methods = ApiQuery.nongeneric(src).Select(m => new JittedMethod(uri,  m));
            var count = methods.Length;
            var buffer = alloc<ApiMember>(count);
            var diviner = MultiDiviner.Service;
            for(var i=0; i<count; i++)
                seek(buffer,i) = member(methods[i].Method, uri);
            return buffer;
        }

        static ApiMember[] generic(Type src, IWfChannel emitter)
        {
            var uri = src.ApiHostUri();
            var generic = ApiQuery.generic(src).Select(m => new JittedMethod(uri, m)).ToReadOnlySpan();
            var gCount = generic.Length;
            var buffer = list<ApiMember>();
            for(var i=0; i<gCount; i++)
                buffer.AddRange(ClrJit.generic(skip(generic, i), emitter));
            return buffer.ToArray();
        }

        static ApiMember[] generic(IApiHost src, IWfChannel emitter)
            => generic(src.HostType, emitter);


        [Op]
        static ApiMember[] generic(JittedMethod src, IWfChannel channel)
        {
            var diviner = MultiDiviner.Service;
            var method = src.Method;
            var types = @readonly(ApiIdentityKinds.NumericClosureTypes(method));
            var count = types.Length;
            var buffer = alloc<ApiMember>(count);
            var dst = span(buffer);
            try
            {
                for(var i=0u; i<count; i++)
                {
                    ref readonly var t = ref skip(types, i);
                    var constructed = src.Method.MakeGenericMethod(t);
                    var uri = ApiIdentity.define(ApiUriScheme.Located, src.Host, method.Name, diviner.Identify(constructed));
                    seek(dst,i) = member(constructed, uri);
                }
            }
            catch(ArgumentException e)
            {
                channel.Warn(string.Format("{0}: Closure creation failed for {1}/{2}", e.GetType().Name, method.DeclaringType.DisplayName(), method.DisplayName()));
                return sys.empty<ApiMember>();
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
            return buffer;
        }


        static HashSet<string> CommonExclusions
            = sys.hashset(sys.array("ToString","GetHashCode", "Equals", "ToString"));
    }
}