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
            public FilePath Path;

            public @string ProjectName;

            public Guid ProjectGuid;

            public Seq<Guid> Dependencies;

            public Seq<SlnProjectConfig> Configurations;

            public SlnProject()
            {
                Path = FilePath.Empty;
                ProjectName = @string.Empty;
                Dependencies = Seq<Guid>.Empty;
                Configurations = Seq<SlnProjectConfig>.Empty;
                ProjectGuid = Guid.Empty;
            }

            public static SlnProject Empty => new();
        }
    }
}