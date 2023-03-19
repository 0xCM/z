//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public abstract record class ProjectGroup<T> : IProjectGroup<T>
            where T : IProjectElement
        {
            public readonly GroupKind GroupKind;

            public readonly DataList<T> Members;

            protected ProjectGroup(GroupKind kind)
            {
                Members = new();
                GroupKind = kind;
            }

            protected ProjectGroup(GroupKind kind, T[] members)
            {
                GroupKind = kind;
                Members = members;
            }

            DataList<T> IProjectGroup<T>.Members 
                => Members;

            GroupKind IProjectGroup.GroupKind 
                => GroupKind;

            public string Format()
            {
                var dst = text.buffer();
                Render(2u,dst);
                return dst.Emit();
            }

            public void Render(uint margin, ITextBuffer dst)
            {
                dst.IndentLine(margin, string.Format("<{0}>", GroupKind));
                margin+=2;
                sys.iter(Members, member => dst.IndentLine(margin,member.ToString()));
                margin-=2;
                dst.IndentLine(margin, string.Format("</{0}>",GroupKind));
            }
        }
    }
}