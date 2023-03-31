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

        public class NativeImageResolver
        {
            readonly IDbArchive Root;


            public NativeImageResolver(IDbArchive root)
            {
                Root = root;
            }

            public NativeImage Resolve(FileName name)
            {
                return default;
            }
        }
    }

}