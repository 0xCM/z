//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public ref struct CheckResourcesStep
    {
        readonly IWfChannel Channel;

        readonly FilePath Source;

        [MethodImpl(Inline)]
        public CheckResourcesStep(IWfChannel wf, FilePath src)
        {
            Channel = wf;
            Source = src;
        }

        public void Run()
        {
            var flow = Channel.Running(nameof(CheckResourcesStep));
            TryRun();
            Channel.Ran(flow);
        }

        void Execute()
        {
            using var map = MemoryFiles.map(Source);
            var @base = map.BaseAddress;
            var sig = map.View(0, 2).AsUInt16();
            Channel.Status(map.Description);
        }

        void TryRun()
        {
            try
            {
                Execute();
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }

        public void Dispose()
        {
        }
    }
}