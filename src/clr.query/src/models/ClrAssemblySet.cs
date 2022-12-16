//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ClrAssemblySet
    {
        public ClrAssemblySet()
        {
            Members = sys.empty<Assembly>();
        }

        public ClrAssemblySet(Assembly[] members)
        {
            Members = members;
        }

        public Assembly[] Members {get;}
    }
}