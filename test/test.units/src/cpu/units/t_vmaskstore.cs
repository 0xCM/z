//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static cpu;
    using static HexConst;

    public class t_vmaskstore : t_inx<t_vmaskstore>
    {
        public void vmstore_128x8()
        {
            const byte Y = Pow2.T07;
            const byte N = 0;

            var w = w128;
            var dst = SpanBlocks.single<byte>(w);
            var m0 = cpu.vparts(w128,Y,Y,Y,Y,N,N,N,N,N,N,N,N,N,N,N,N);
            var m1 = cpu.vsllx(m0,32);
            var m2 = cpu.vsllx(m1,32);
            var m3 = cpu.vsllx(m2,32);

            for(var i = 0; i<RepCount; i++)
            {
                var v0 = Random.CpuVector<byte>(w);
                var v1 = Random.CpuVector<byte>(w);
                var v2 = Random.CpuVector<byte>(w);
                var v3 = Random.CpuVector<byte>(w);

                cpu.vmaskstore(v0, m0, dst);
                cpu.vmaskstore(v1, m1, dst);
                cpu.vmaskstore(v2, m2, dst);
                cpu.vmaskstore(v3, m3, dst);

                var v4 = gcpu.vload(dst);
                var v5 = cpu.vparts(n128,
                    vcell(v0,0), vcell(v0,1), vcell(v0,2), vcell(v0,3),
                    vcell(v1,4), vcell(v1,5), vcell(v1,6), vcell(v1,7),
                    vcell(v2,8), vcell(v2,9), vcell(v2,A), vcell(v2,B),
                    vcell(v3,C), vcell(v3,D), vcell(v3,E), vcell(v3,F)
                    );

                Claim.veq(v4,v5);
            }
        }

        public void vmaskstore_256x8()
        {
            var count = 32;
            var x = Random.CpuVector(w256, z8);
            var storage = SpanBlocks.single<byte>(w256);
            var stored = gcpu.vzero(w256,z8);
            var mask = gcpu.vzero(w256,z8);

            // Store every component
            storage.Clear();
            mask = vmask.vmsb<byte>(w256, n8, n1);
            gcpu.vmaskstore8(x,mask,storage);
            stored = storage.LoadVector();
            Claim.veq(x,stored);

            // Store odd components
            storage.Clear();
            mask = vmask.vmsb(w256, n16, n1, z8);
            gcpu.vmaskstore8(x,mask,storage);
            stored = storage.LoadVector();


            for(byte i=0; i< count; i++)
                if(gmath.odd(i))
                    Claim.eq(vcell(x,i), storage[i]);
                else
                    Claim.eq(z8, storage[i]);

            // Store even components
            storage.Clear();
            mask = gcpu.vbsrl(vmask.vmsb(w256, n16, n1, z8),1);
            gcpu.vmaskstore8(x, mask, storage);
            stored = storage.LoadVector();


            for(byte i=0; i< count; i++)
                if(gmath.even(i))
                    Claim.eq(vcell(x,i), storage[i]);
                else
                    Claim.eq(z8, storage[i]);


            void report()
            {
                Trace("input", x.Format());
                Trace("mask", mask.FormatBits());
                Trace("stored", stored.Format());
            }
        }
    }
}