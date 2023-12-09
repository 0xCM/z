//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
partial class ApiOps
{
    [CmdOp("bitmasks/check")]
    void CheckBitmasks()
    {
        var src = Bitfields.masks(typeof(BitMaskLiterals));
        var formatter = CsvTables.formatter<BitMaskLiterals>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var mask = ref src[i];
            Channel.Write(formatter.Format(mask));
            Channel.Write(mask.Text);
        }
    }

    [CmdOp("vshuffle/check")]
    void PermCheck()
    {
        var w = w512;
        var src = vgcpu.vinc<ushort>(w);
        Span<ushort> spec = stackalloc ushort[32];
        
        var j = 31;
        for(var i=0; i<32; i++)
        {
            spec[i] = (ushort)j--;
        }        

        var vspec = vgcpu.vload(w512, spec);
        var a = vcpu.vpermw(src,vspec);
        Channel.Row(a.ToString());        
    }

    [CmdOp("vshifts/check")]
    void CheckShifts()
    {
        var w = w512;
        var src = vgcpu.vinc<byte>(w);
        var dst = vcpu.vsll(src,4);
        Span<byte> buffer = stackalloc byte[128];
        vcpu.vstore(src,buffer);
        vcpu.vstore(dst,sys.slice(buffer,64));
        for(var i=0; i<64; i++)
        {
            ref readonly var a = ref skip(buffer,i);
            ref readonly var b = ref skip(buffer, i+64);
            var c = math.sll(a,4);
            Require.equal(b,c);
            Channel.Row($"{a.ToBitString()} -> {b.ToBitString()}");
        }


    }
}
