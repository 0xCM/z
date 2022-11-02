//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct MergeFile
    {
        public FolderPath Sources;

        public FolderPath Targets;
    }
}