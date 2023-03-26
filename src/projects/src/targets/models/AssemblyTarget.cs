//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ProjectModels;

    partial class ProjectTargets
    {
        public sealed class AssemblyTarget : ProjectTarget<AssemblyTarget, AssemblyIndexRule, AssemblyIndex>
        {
            public override AssemblyIndex Build(AssemblyIndexRule rule)
            {
                throw new NotImplementedException();
            }
        }

    }
}