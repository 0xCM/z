//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public ref struct CheckResourcesStep
    {
        readonly IWfRuntime Wf;

        readonly FilePath Source;

        [MethodImpl(Inline)]
        public CheckResourcesStep(IWfRuntime wf, FilePath src)
        {
            Wf = wf;
            Source = src;
        }

        public void Run()
        {
            var flow = Wf.Running(nameof(CheckResourcesStep));
            TryRun();
            Wf.Ran(flow);
        }

        void Execute()
        {
            using var map = MemoryFiles.map(Source);
            var @base = map.BaseAddress;
            var sig = map.View(0, 2).AsUInt16();
            Wf.Status(map.Description);
        }

        void TryRun()
        {
            try
            {
                Execute();
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }

        public void Dispose()
        {
        }
    }
}