//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        public record class Solution
        {
            public SlnFile Path;

            public Seq<SlnProject> Projects;
        }
    }
}