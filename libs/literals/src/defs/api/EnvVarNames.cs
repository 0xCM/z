//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(env)]
    public readonly partial struct EnvVarNames
    {
        public const string DevRoot = "DevRoot";

        public const string ZDev = "ZDev";

        public const string Db = "ZDb";

        public const string Control = "ZControl";

        public const string Archives = "ZArchive";

        public const string Tools = "ZTools";

        public const string Packages = "ZPack";

        public const string Logs = "ZLogs";

        public const string ZBin = "ZBin";

        public const string ZTmp = "ZTmp";

        public const string CacheRoot = "ZCache";

        public const string SymCacheRoot = "SymCacheRoot";

        public const string DefaultSymbolCache = "DefaultSymbolCache";

        public const string CdbLogPath = "_NT_DEBUG_LOG_FILE_APPEND";

        public const string Libs = "ZLibs";

        public const string ZData = "ZData";

        public const string VendorDocs = "VendorDocRoot";

        public const string CapturePacks = "CapturePacks";

        public const string CpuCount = "NUMBER_OF_PROCESSORS";

        public const string DevWs = "DevWs";

        public const string LlvmRoot = "LlvmRoot";

        public const string Toolbase = "Toolbase";

        public const string ZEnvDb = nameof(ZEnvDb);
    }
}