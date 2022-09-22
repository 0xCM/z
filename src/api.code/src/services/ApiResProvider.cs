//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class ApiResProvider : AppService<ApiResProvider>
    {
       [Op]
        static SpanResKind ResKind(Type match)
        {
            ref readonly var src = ref first(span(ResAccessorTypes));
            var kind = SpanResKind.None;
            if(skip(src,0).Equals(match))
                kind = SpanResKind.ByteSpan;
            else if(skip(src,1).Equals(match))
                kind = SpanResKind.CharSpan;
            return kind;
        }

        /// <summary>
        /// Queries the source type for ByteSpan property getters
        /// </summary>
        /// <param name="src">The type to query</param>
        [Op]
        public static Index<SpanResAccessor> accessors(Type src)
            => src.StaticProperties()
                 .Ignore()
                  .WithPropertyType(ResAccessorTypes)
                  .Select(p => p.GetGetMethod(true))
                  .Where(m  => m != null)
                  .Concrete()
                  .Select(x => new SpanResAccessor(ApiCode.entries(x), ResKind(x.ReturnType)));

        /// <summary>
        /// Queries the source types for ByteSpan property getters
        /// </summary>
        /// <param name="src">The types to query</param>
        [Op]
        public static Index<SpanResAccessor> accessors(Index<Type> src)
            => src.Where(t => !t.IsInterface).SelectMany(accessors).Array();

        /// <summary>
        /// Queries the source assemblies for ByteSpan property getters
        /// </summary>
        /// <param name="src">The assemblies to query</param>
        [Op]
        public static Index<SpanResAccessor> accessors(Assembly[] src)
            => accessors(src.SelectMany(x => x.GetTypes()));

        /// <summary>
        /// Queries the source assembly for ByteSpan property getters
        /// </summary>
        /// <param name="src">The assembly to query</param>
        [MethodImpl(Inline), Op]
        public static Index<SpanResAccessor> accessors(Assembly src)
            => accessors(src.GetTypes());

        /// <summary>
        /// Queries the source types for ByteSpan property getters
        /// </summary>
        /// <param name="src">The types to query</param>
        [Op]
        public static Index<SpanResAccessor> accessors(Type[] src)
            => src.Where(t => !t.IsInterface).SelectMany(x => accessors(x));

        static Type[] ResAccessorTypes
            => new Type[]{ByteSpanAcessorType, CharSpanAcessorType};

        static Type ByteSpanAcessorType
            => typeof(ReadOnlySpan<byte>);

        static Type CharSpanAcessorType
            => typeof(ReadOnlySpan<char>);

        public FilePath ResPackPath()
            => FilePath.Empty;

        public MemoryFile MapResPack()
            => MemoryFiles.map(ResPackPath());

        public ReadOnlySpan<SpanResAccessor> SpanAccessors(FilePath src)
        {
            var flow = Running(LoadingSpanAccessors.Format(src));
            if(!src.Exists)
                Throw.sourced(FS.missing(src));
            var assembly = Assembly.LoadFrom(src.Name);
            var loaded = accessors(assembly);
            Ran(flow, LoadedSpanAccessors.Format(loaded.Count, src));
            return loaded;
        }

        public ReadOnlySpan<SpanResAccessor> ResPackAccessors()
            => SpanAccessors(ResPackPath());

        public ReadOnlySpan<SpanResAccessor> ResPackAccessors(FilePath src)
            => SpanAccessors(src);

        static MsgPattern<_FileUri> LoadingSpanAccessors => "Loading respack accessors from {0}";

        static MsgPattern<Count,_FileUri> LoadedSpanAccessors => "Loaded {0} respack accessors from {1}";
    }
}