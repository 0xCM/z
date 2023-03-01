//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public readonly struct PathHandle
    {
        public readonly ProcessId Process;

        public readonly Address16 Offset;

        public readonly PathHandleKind Kind;

        public readonly @string Name;

        public PathHandle(ProcessId process, Address16 offset, PathHandleKind kind, string name)
        {
            Process = process;
            Offset = offset;
            Kind = kind;
            Name = name;
        }        
    }
}