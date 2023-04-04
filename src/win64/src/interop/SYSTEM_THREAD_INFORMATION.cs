//-----------------------------------------------------------------------------
// Copyright   :  None
// License     :  Any, except GPL or variants thereof
//-----------------------------------------------------------------------------
namespace Windows
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SYSTEM_THREAD_INFORMATION
    {
        private fixed long Reserved1[3];
        private readonly uint Reserved2;

        public MemoryAddress StartAddress;
        
        public CLIENT_ID ClientId;
        
        public int Priority;
        
        public int BasePriority;
        
        private readonly uint Reserved3;
        
        public uint ThreadState;
        
        public uint WaitReason;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CLIENT_ID
    {
        public MemoryAddress UniqueProcess;

        public MemoryAddress UniqueThread;
    }
}