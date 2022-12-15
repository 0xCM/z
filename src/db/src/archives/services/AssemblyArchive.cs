//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ClrAssemblyArchive
    {
        public ClrAssemblyArchive()
        {
            Members = sys.empty<Assembly>();
        }

        public ClrAssemblyArchive(Assembly[] members)
        {
            Members = members;
        }

        public Assembly[] Members {get;}
    }
}