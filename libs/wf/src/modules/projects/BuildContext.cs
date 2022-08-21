//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class BuildContext
    {
        public static FS.FilePath path(IProjectWorkspace src)
            => src.BuildOut() + FS.file($"{src.ProjectId}.build.flows",FileKind.Csv);
    }
}