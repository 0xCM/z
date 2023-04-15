//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class DevProject<P> : DevProject
        where P : DevProject<P>, new()
    {         
        protected DevProject(ProjectKind kind, FolderPath root)
            : base(kind,root)
        {
        }

        protected DevProject(ProjectKind kind)
            : base(kind)
        {

        }

        public static P Empty => new();
    }
    
}