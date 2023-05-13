//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class DevProject<P> : DevProject
        where P : DevProject<P>, new()
    {         
        protected DevProject(FolderPath root)
            : base(root)
        {
        }


        public static P Empty => new();
    }
    
}