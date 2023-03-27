//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    public class ProjectScripts : AppService<ProjectScripts>
    {        
        public static IEnumerable<FilePath> scripts(CmdArgs args)
            => AppDb.Service.ProjectLib(arg(args, 0).Value).Scoped(ApiAtomic.scripts).Files();
    }
}