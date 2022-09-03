//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("grids/check")]
        unsafe Outcome TestGrids(CmdArgs args)
        {
            const uint M = 17;
            const uint N = 19;
            const uint Count = M*N;
            var result = Outcome.Success;
            var storage = alloc<uint>(Count);
            var k=0u;
            for(var i=0u; i<M; i++)
            for(var j=0u; j<N; j++, k++)
                seek(storage,k) = i*j;

            var table = new Grid<uint>((M,N), storage);

            k = 0;
            var msg = EmptyString;
            for(var i=0u; i<M; i++)
            {
                for(var j=0u; j<N; j++, k++)
                {
                    var expect = i*j;
                    ref readonly var actual = ref table[i,j];
                    var ok = actual == expect;
                    if(ok)
                        msg = string.Format("{0}x{1} = {2}",i,j,expect);
                    else
                        msg = string.Format("{0}x{1} = [{0},{1}] = {2} != {3}", i,j, actual, expect);

                    if(ok)
                        Write(msg, FlairKind.Status);
                    else
                        Write(msg, FlairKind.Error);
                }
            }

            return result;
        }
    }
}