//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public sealed record class AssemblyIndexRule : ProjectRule<AssemblyIndexRule>
        {
            public readonly FileQuery Query;

            public AssemblyIndexRule()
            {
                Query = FileQuery.Empty;
            }
            
            public AssemblyIndexRule(FileQuery q)
            {
                Query = q;
            }
        }
    }
}