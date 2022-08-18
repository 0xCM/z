//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Threading.Tasks;

    using static Fsm1Spec.StateKinds;

    public ref struct RunFsm
    {
        readonly IWfRuntime Wf;

        [MethodImpl(Inline)]
        public RunFsm(IWfRuntime wf)
        {
            Wf = wf;
        }

        public void Run()
        {
            var spec = new Fsm1Spec();
            var tasks = new Task[Pow2.T08];
            var indices = gcalc.stream(0xFFFFul, 0xFFFFFFFFul).Where(x => x % 2 != 0).Take(Pow2.T08).ToArray();
            for(var i=0u; i< tasks.Length; i++)
            {
                var random = Rng.pcg64(0,indices[i]);
                var context = Fsm.context(random);
                var machine = Fsm.machine($"Fsm1-{i}",context, S0,S5, spec.TransFunc);
                tasks[i] = Fsm.run(machine);
            }
            Task.WaitAll(tasks);
        }

        public void Dispose()
        {

        }

        public static void Run(IWfRuntime wf)
        {
            using var step = new RunFsm(wf);
            step.Run();
        }
    }
}