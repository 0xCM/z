//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class ProcessPaths
    {
        public readonly ProcessId ProcessId;

        public readonly @string ProcessOwner;

        public readonly FileName ProcessName;

        public readonly ReadOnlySeq<PathHandle> Handles;

        public ProcessPaths(ProcessId id, string owner, FileName name, ReadOnlySeq<PathHandle>  handles)
        {
            ProcessId = id;
            ProcessOwner = owner;
            ProcessName = name;
            Handles = handles;
        }
    }
}