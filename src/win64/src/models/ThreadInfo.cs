//-----------------------------------------------------------------------------
// Copyright   :  None
// License     :  Any, except GPL or variants thereof
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics;

    [StructLayout(LayoutKind.Sequential)]
    public record struct ThreadInfo
    {
        public ThreadId ThreadId;
        
        public ProcessId ProcessId;
        
        public int BasePriority;
        
        public int CurrentPriority;
        
        public MemoryAddress StartAdress;
        
        public ThreadState State;
        
        public ThreadWaitReason WaitReason;
    }
}