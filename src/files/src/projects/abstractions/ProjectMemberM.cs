//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public abstract record class ProjectMember<M>
            where M : ProjectMember<M>, new()
        {
            public readonly asci32 MemberName;

            protected ProjectMember()
            {
                MemberName = asci32.Null;
            }

            protected ProjectMember(string name)
            {
                MemberName = name;
            }
        
        }
    }
}