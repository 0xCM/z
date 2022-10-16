//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EcmaServices : WfSvc<EcmaServices>
    {
        static Outcome exec(IWfContext channel, CatalogAssemblies cmd)
        {
            var result = Outcome.Success;
            var src = from file in cmd.Source.DbArchive().Enumerate("*.dll")
                        where ClrModules.valid(file)
                        select file;            

            var dst = cmd.Target.DbArchive();
            
            
            return result;
        }
        
        public Task<ExecResult> Start(CatalogAssemblies cmd)
            => sys.start(() => WfSvc.exec(Context, cmd, exec));
    }
}
