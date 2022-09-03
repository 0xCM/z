//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        [Record(TableId)]
        public record struct SlnProjectConfig
        {
            public const string TableId = "sln.project-config";

            public string SimpleName;

            public string Platform;

            public string FullName;

            public bool Build;
        }
    }
}