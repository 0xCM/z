//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public abstract record class DataSource<S> : ProjectMember<S>
            where S : DataSource<S>,new()
        {
            public readonly SourceKind Kind;

            protected DataSource(SourceKind kind, string name)
                : base(name)
            {
                Kind = kind;
            }

        }
    }
}