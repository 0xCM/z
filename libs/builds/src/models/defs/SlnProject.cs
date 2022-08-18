//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public record class SlnProject
        {
            public FS.FileUri Path;

            public string ProjectName;

            public Guid ProjectGuid;

            public Seq<Guid> Dependencies;

            public Seq<SlnProjectConfig> Configurations;
        }
    }
}