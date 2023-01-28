//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class MsBuildLoader : WfSvc<MsBuildLoader>
    {
        MsBuild MsBuild => Wf.BuildSvc();

        public Task<ExecToken> Start(IDbArchive src, Action<Build.ProjectSpec> dst)
        {
            ExecToken Worker()
            {
                using var running = Channel.Running("projects/load");
                iter(src.Enumerate(true, FileKind.CsProj), uri => {
                    try
                    {
                        var project = MsBuild.LoadProject(uri);
                        dst(project);
                    }
                    catch(Exception e)
                    {
                        Channel.Error(e);
                    }
                });
                return Channel.Ran(running);
            }
            return sys.start(Worker);
        }
    }
}