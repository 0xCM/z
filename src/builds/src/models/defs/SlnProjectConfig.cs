//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        [Record(TableName)]
        public record struct SlnProjectConfig
        {
            const string TableName = "sln.project-config";

            public string SimpleName;

            public string Platform;

            public string FullName;

            public bool Build;
        }
    }
}