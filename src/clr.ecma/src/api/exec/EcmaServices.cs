//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    public class EcmaServices : WfSvc<EcmaServices>
    {
        public static Outcome exec(IWfContext channel, CatalogAssemblies cmd)
        {
            var result = Outcome.Success;
            var src = from file in cmd.Source.DbArchive().Enumerate("*.dll")
                        where EcmaFiles.valid(file)
                        select file;            

            var dst = cmd.Target.DbArchive();
            
            
            return result;
        }        
    }
}
