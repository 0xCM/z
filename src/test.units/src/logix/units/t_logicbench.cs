//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    public class t_logicbench : UnitTest<t_logicbench>
    {
        protected override int CycleCount => Pow2.T08;

        public void scalar_op_bench()
        {
            scalar_op_bench<uint>(true);
            scalar_op_bench<uint>(false);
        }

        void scalar_op_bench<T>(bool lookup, SystemCounter clock = default)
            where T : unmanaged
        {
            var opname = $"ops/scalar[{typeof(T).DisplayName()}]/lookup[{lookup}]";

            var lhsSamples = Random.Array<T>(RepCount);
            var rhsSamples = Random.Array<T>(RepCount);
            var result = default(T);
            var kinds = NumericLogixHost.BinaryLogicKinds.ToArray();
            var opcount = 0;

            clock.Start();

            if(lookup)
            {
                for(var i=0; i<CycleCount; i++)
                for(var sample=0; sample< RepCount; sample++)
                for(var k=0; k< kinds.Length; k++, opcount++)
                    result = NumericLogixHost.lookup<T>(kinds[k])(lhsSamples[sample], rhsSamples[sample]);
            }
            else
            {
                for(var i=0; i<CycleCount; i++)
                for(var sample=0; sample< RepCount; sample++)
                for(var k=0; k< kinds.Length; k++, opcount++)
                    result = NumericLogixHost.eval(kinds[k],lhsSamples[sample], rhsSamples[sample]);
            }

            clock.Stop();

            ReportBenchmark(opname, opcount, clock);
        }
    }
}