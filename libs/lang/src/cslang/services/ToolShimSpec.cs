//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Entity(EntityKind)]
    public record struct ToolShimSpec : IEntity<ToolShimSpec,Name>
    {       
        const string EntityKind = "tools.shims.spec";

        public Name ShimName;

        public FilePath ShimPath;

        public FilePath TargetPath;

        Name IKeyed<Name>.Key 
            => ShimName;
    }   
}