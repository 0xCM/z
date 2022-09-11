//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public sealed class ProcessHandle : Handle<ProcessHandle>
    {
        public ProcessHandle()
            : base(0)
        {

        }

        public ProcessHandle(MemoryAddress src)
            : base(src)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator ProcessHandle(IntPtr src)
            => new ProcessHandle(src);
    }
}