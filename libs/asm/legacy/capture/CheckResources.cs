//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [WfHost]
    public sealed class CheckResources : WfHost<CheckResources>
    {
        public const string StepName = nameof(CheckResourcesStep);

        protected override void Execute(IWfRuntime wf)
        {
            var src = FS.path("J:/dev/projects/z0-logs/builds/respack/lib/netcoreapp3.1/z0.respack.dll");
            using var step = new CheckResourcesStep(wf,this,src);
            step.Run();
        }
    }

    public ref struct CheckResourcesStep
    {
        readonly IWfRuntime Wf;

        readonly WfHost Host;

        readonly FilePath Source;

        [MethodImpl(Inline)]
        public CheckResourcesStep(IWfRuntime wf, WfHost host, FilePath src)
        {
            Wf = wf;
            Host = host;
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