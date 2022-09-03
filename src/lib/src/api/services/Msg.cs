//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;

    [ApiComplete]
    readonly partial struct Msg
    {
        public static MsgPattern<Count,Count,string> FieldCountMismatch => "{0} fields were found while {1} were expected: {2}";

        public static MsgPattern<ApiHostUri,uint,uint> IndexedHost => "{0,-30} | {1}/{2}";

        public static MsgPattern<uint> IndexingHosts => "Indexing {0} hosts";

        public static MsgPattern<ApiHostUri> CreatingHostCatalog => "Creating {0} catalog";

        public static MsgPattern<ApiHostUri,Count> CreatedHostCatalog => "Created {0} catalog with {1} members";


        public static string Unparsed<T>(T src) => unparsed<T>().Format(src);

        static RenderPattern<T> unparsed<T>() => "Unable to parse {0}";

        public static MsgPattern<Count> JittingParts => "Jitting {0} parts";

        public static MsgPattern<PartId> JittingPart => "Jitting {0} members";

        public static MsgPattern<Count,PartId> JittedPart => "Jitted {0} {1} members";

        public static MsgPattern<dynamic,dynamic> JittedParts => "Jitted {0} members from {1} parts";

        public static MsgPattern<FileUri> LoadingApiCatalog => "Loading api catalog from {0}";

        public static MsgPattern<Count,FileUri> LoadedApiCatalog => "Loaded {0} catalog entries from {1}";

        public static MsgPattern<Assembly,uint> EmittingResources => "Emitting {1} {0} resources";
    }
}