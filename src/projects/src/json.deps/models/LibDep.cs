//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        [Record(TableName)]
        public record struct LibDep
        {
            const string TableName = "jsondeps.library";

            public string Name;

            public string Version;
        }
    }
}