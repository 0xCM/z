//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IApiRuntime
    {

    }

    public interface IApiRuntime<R> : IApiRuntime
        where R: IApiRuntime<R>
    {

    }

    public abstract class ApiRuntime<R> : IApiRuntime<R>
        where R: ApiRuntime<R>
    {
        [Op]
        public static Index<IApiHost> hosts(Assembly src)
        {
            var id = src.PartName();
            return ApiHostTypes(src).Select(h => host(id, h));
        }

        public static ApiPartCatalog catalog(Assembly src)
            => new ApiPartCatalog(src.PartName(), src, complete(src), hosts(src), SvcHostTypes(src));

        protected static FolderFiles libs(FolderPath src)
        {            
            var candidates = src.Files(FileKind.Dll);
            var dst = list<FilePath>();
            foreach(var file in candidates)
            {
                if(file.FileName.Contains("System.Private.CoreLib"))
                    continue;

                if(FS.managed(file))
                    dst.Add(file);
            }

            return new FolderFiles(src, dst.Array());
        }

        protected static Type[] SvcHostTypes(Assembly src)
            => src.GetTypes().Where(t => t.Tagged<FunctionalServiceAttribute>());

        [Op]
        protected static Index<ApiCompleteType> complete(Assembly src)
        {
            var part = src.Id();
            var types = span(src.GetTypes().Where(t => t.Tagged<ApiCompleteAttribute>()));
            var count = types.Length;
            var buffer = sys.alloc<ApiCompleteType>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var attrib = type.Tag<ApiCompleteAttribute>();
                var name = text.ifempty(attrib.MapValueOrDefault(a => a.Name, type.Name),type.Name).ToLower();
                var uri = new ApiHostUri(part, name);
                var declared = type.DeclaredMethods();
                seek(buffer, i) = new ApiCompleteType(type, name, part, uri, declared, index(declared));
            }
            return buffer;
        }

        /// <summary>
        /// Searches an assembly for types tagged with the <see cref="ApiHostAttribute"/>
        /// </summary>
        /// <param name="src">The assembly to search</param>
        [Op]
        protected static Index<Type> ApiHostTypes(Assembly src)
            => src.GetTypes().Where(IsApiHost);

        [Op]
        protected static bool IsApiHost(Type src)
            => src.Tagged<ApiHostAttribute>();

        /// <summary>
        /// Describes an api host
        /// </summary>
        /// <param name="part">The defining part</param>
        /// <param name="t">The reifying type</param>
        [Op]
        protected static IApiHost host(PartName part, Type type)
        {
            var uri = ApiIdentity.host(type);
            var declared = type.DeclaredMethods();
            return new ApiHost(type, uri.HostName, part, uri, declared, index(declared));
        }

        [Op]
        protected static Dictionary<string,MethodInfo> index(Index<MethodInfo> src)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(src, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }

        protected const string InitializingRuntime = "Initializing runtime";
        
        protected static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

        protected static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        protected static RenderPattern<IWfEmissionLog> ConfiguredEmissionLogs => "Configured emisson logs:{0}";
    }
}