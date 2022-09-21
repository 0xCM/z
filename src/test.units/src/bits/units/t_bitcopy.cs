//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public class t_bitcopy : t_bits<t_bitcopy>
    {
        public void bitcopy_check()
        {
            bitcopy_check<byte>();
            bitcopy_check<ushort>();
            bitcopy_check<uint>();
            bitcopy_check<long>();
            bitcopy_check<ulong>();
        }

        void bitcopy_check<T>()
            where T : unmanaged
        {
            var zed = zero<T>();
            var lit = ones<T>();
            var min = byte.MinValue;
            var max = (byte)width<T>();

            void check()
            {
                for(var rep = 0; rep<RepCount; rep++)
                {
                    var range = Random.Interval(min, max);
                    var count = (byte)range.Width;
                    var expect = gbits.enable(zed, range.Left, count);
                    var actual = gbits.bitcopy(lit, range.Left, count, zed);
                    if(gmath.neq(expect,actual))
                    {
                        Trace("expect", BitSpans32.from(expect).Format());
                        Trace("actual", BitSpans32.from(actual).Format());
                        Claim.eq(expect, actual);
                    }
                }
            }

            CheckAction(check, CaseName(ApiIdentityBuilder.NumericOp<T>("bitcopy")));
        }
    }
}