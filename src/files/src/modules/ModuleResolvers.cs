//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ModuleResolvers
    {
        public class Context
        {


        }

        public class AssemblyResolver
        {        

            readonly IDbArchive Root;

            public AssemblyResolver(IDbArchive root)
            {
                Root = root;
            }

            public AssemblyFile Resolve(ClrAssemblyName name)
            {
                return default;
            }
        }


    }

}