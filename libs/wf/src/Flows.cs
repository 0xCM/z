//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FlowContext
    {
        [MethodImpl(Inline), Op]
        public static FileFlowContext create(IProjectWorkspace src)
            => new FileFlowContext(src, FlowCatalogs.load(src));
    }

    public class BuildContext
    {
        public static FS.FilePath path(IProjectWorkspace src)
            => src.BuildOut() + FS.file($"{src.ProjectId}.build.flows",FileKind.Csv);
    }
}