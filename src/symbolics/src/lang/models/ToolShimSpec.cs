//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Entity(EntityKind)]
    public record struct ToolShimSpec : IEntity<ToolShimSpec,@string>
    {       
        const string EntityKind = "tools.shims.spec";

        public @string ShimName;

        public FilePath ShimPath;

        public FilePath TargetPath;

        @string IKeyed<@string>.Key 
            => ShimName;
    }   
}