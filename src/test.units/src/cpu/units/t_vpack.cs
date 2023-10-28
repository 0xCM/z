//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static LimitValues;
using static vcpu;

public class t_vpack : t_inx<t_vpack>
{
    public void vpackus_128x16x2_128x8_outline()
    {
        void case1()
        {
            var a = vparts(w128,0,1,2,4,4,5,6,7);
            var b = vparts(w128,8,9,10,11,12,13,14,15);
            var c = vpack.vpackus(a,b);
            var d = vparts(w128,0,1,2,4,4,5,6,7,8,9,10,11,12,13,14,15);
            Claim.veq(d,c);
        }

        void case2()
        {
            var x = vparts(w128,127,0,127,0,127,0,127,0);
            var y = vpack.vpackus(x,x);
            Notify(y.Format());
        }
        case1();
        case2();
    }

    public void vpack_128x16x2_128x8()
    {
        var w = w128;
        var cellmax = Max8u;

        var vsmax = vbroadcast(w, (ushort)cellmax);
        var vtmax = vbroadcast(w,cellmax);
        var expect = vsub(vtmax, gcpu.vinc(w,z8));

        var x = vsub(vsmax, gcpu.vinc(w, z16));
        var y = vsub(vsmax, gcpu.vinc(w, (ushort)8));
        var actual = vpack.vpack128x8u(x, y);

        Claim.veq(expect,actual);
    }

    public void vpack_256x16x2_256x8()
    {
        var w = w256;
        var cellmax = Max8u;

        var vsmax = vbroadcast(w, (ushort)cellmax);
        var vtmax = vbroadcast(w,cellmax);
        var expect = cpu.vsub(vtmax, gcpu.vinc(w,z8));

        var x = cpu.vsub(vsmax, gcpu.vinc(w, z16));
        var y = cpu.vsub(vsmax, gcpu.vinc(w, (ushort)16));
        var actual = vpack.vpack256x8u(x, y);

        Claim.veq(expect,actual);
    }

    public void vpack_2x128x32u_128x16u()
    {
        var w = w128;
        var cellmax = Max16u;

        var vsmax = vbroadcast(w, (uint)cellmax);
        var vtmax = vbroadcast(w,cellmax);
        var expect = cpu.vsub(vtmax, gcpu.vinc(w,z16));

        var x = cpu.vsub(vsmax, gcpu.vinc(w, 0u));
        var y = cpu.vsub(vsmax, gcpu.vinc(w, 4u));
        var actual = vpack.vpack128x16u(x,y);

        Claim.veq(expect,actual);
    }

    public void vpack_2x256x32u_256x16u()
    {
        var w = w256;
        var cellmax = Max16u;

        var vsmax = gcpu.vbroadcast<uint>(w, (uint)cellmax);
        var vtmax = vbroadcast(w,cellmax);

        var x = vsub(vsmax, gcpu.vinc(w, 0u));
        var y = vsub(vsmax, gcpu.vinc(w, 8u));
        var v = vpack.vpack256x16u(x,y);
        var expect = vsub(vtmax, gcpu.vinc(w, z16));
        Claim.veq(expect,v);
    }

    // public void vpack_2x128x64u_128x32u()
    // {
    //     var w = w128;
    //     var x0 = cpu.vparts(w, 25, 50);
    //     var x1 = cpu.vparts(w, 75, 10);
    //     var dst = vpack.vpack128x32u(x0, x1);
    //     var expect = cpu.vparts(w, 25, 50, 75, 10);
    //     Claim.veq(expect,dst);
    // }
}
