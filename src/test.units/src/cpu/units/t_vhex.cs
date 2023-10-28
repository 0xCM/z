//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class t_vhex : t_inx<t_vhex>
{
    public void vhex_128_check()
    {
        var w = w128;
        for(var i=0; i<RepCount; i++)
        {
            var v = Random.CpuVector<byte>(w);
            Check(v,v.FormatHex());
        }
    }

    void Check(Vector128<byte> src, ReadOnlySpan<char> hex)
    {
        Span<byte> buffer = stackalloc byte[16];
        var dst = recover<byte>(buffer);
        gcpu.vstore(src, dst);
        var hexsize = size<byte>()*2;
        var j=0;
        for(var i=0; i<dst.Length; i++, j+=3)
        {
            ref readonly var cell = ref skip(dst,i);
            var actual = slice(hex,j,2);
            var expect = cell.FormatHex(true,false);
            Claim.eq(actual,expect);                        
        }
    }

}
