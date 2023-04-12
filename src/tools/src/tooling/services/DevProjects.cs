//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class DevProjects : Stateless<DevProjects>
    {
        public static IEnumerable<FilePath> scripts(IDbArchive src)
            => src.Scoped("cmd").Files(FileKind.Cmd);

    }
}