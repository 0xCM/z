//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    public class t_fixed_rng : t_inx<t_fixed_rng>
    {
        T next<T>()
            where T : unmanaged
                => Random.Next<T>();

        public void fixed_emitter_8u()
        {
            const ulong tolerance = 5;
            var total = 0ul;
            var emit = CellDelegates.producer(next<byte>);
            for(var i=0; i<RepCount; i++ )
                total += (Cell8)(emit());

            var expect = (ulong)(Limits.maxval<byte>()/2);
            var actual = total/(ulong)RepCount;
            var succeeded = math.within(expect,actual,tolerance);

            if(!succeeded)
            {
                Trace($"expect := {expect}");
                Trace($"actual := {actual}");
            }

            Claim.require(succeeded);
        }

        public void fixed_convert()
        {
            BinaryOp<uint> f = gmath.add<uint>;
            CellDelegates.BinaryOp32 g = CellDelegates.binop(gmath.add<uint>);
            var lhs = Random.Cells<Cell32>().Take(RepCount).ToArray();
            var rhs = Random.Cells<Cell32>().Take(RepCount).ToArray();

            void check()
            {
                var count = lhs.Length;
                for(var i=0; i<lhs.Length; i++)
                {
                    var a = lhs[i];
                    var b = rhs[i];
                    var x = Cells.cell32(f(a, b));
                    var y = g(a,b);
                    Claim.eq(x,y);
                }
            }

            CheckAction(check,nameof(fixed_convert));
        }
    }
}