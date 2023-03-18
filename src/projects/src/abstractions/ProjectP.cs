//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public abstract record class Project<P> : Project
            where P : Project<P>, new()
        {         
            protected Project(ProjectKind kind, FolderPath root)
                : base(kind,root)
            {
            }

            protected Project(ProjectKind kind)
                : base(kind)
            {

            }

            public static P Empty => new();
        }
    }
}