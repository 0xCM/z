//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class VexExampleRunner: t_inx<VexExampleRunner>
    {
        uint Successes;

        uint Failures;

        public VexExampleRunner()
        {
            Successes = 0;
            Failures  = 0;
        }

        [Op]
        public void Run()
        {
            var examples = new VexExamples();
            Run(examples.vmerge_128);
            Run(examples.vmerge_256);
            Run(examples.vmerge_hi);
            Run(examples.vmerge_hilo);
            Run(examples.vmerge_lo);
        }

        [MethodImpl(Inline),Op]
        public void Run(Action f)
        {
            try
            {
                f();
                Successes++;
            }
            catch(Exception e)
            {
                Trace(e.Message);
            }
        }
    }
}