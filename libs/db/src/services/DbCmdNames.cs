//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider(cmd)]
    public struct DbCmdNames
    {
        const string db ="db/";

        public const string purge = db + nameof(purge);

        public const string archive = db + nameof(archive);

        public const string scripts = db + nameof(scripts);

        public const string jobs = db + nameof(jobs);
    }
}