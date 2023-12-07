//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

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
}
