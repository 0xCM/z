//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using E = Microsoft.Build.Evaluation;

    partial class Build
    {
        public record class ProjectSpec
        {
            internal readonly E.Project Source;

            public readonly ReadOnlySeq<Property> Props;

            public readonly ReadOnlySeq<ProjectItem> Items;

            [MethodImpl(Inline)]
            internal ProjectSpec(E.Project src)
            {
                Source = src;
                Props = Source.AllEvaluatedProperties.Array().Select(MsBuild.property);
                Items = Source.AllEvaluatedItems.Array().Select(MsBuild.item);
            }

            public string Format()
                => Build.format(this);

            public override string ToString()
                => Format();
        }
    }
}