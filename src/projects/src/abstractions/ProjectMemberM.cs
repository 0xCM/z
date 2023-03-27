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
            public readonly @string MemberName;

            protected ProjectMember()
            {
                MemberName = EmptyString;
            }

            protected ProjectMember(string name)
            {
                MemberName = name;
            }
        
        }
    }
}