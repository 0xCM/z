//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class ApiOps
{
    [CmdOp("calcs/run")]
    void RunChecks()
    {
        Run(sys.empty<string>());
    }

    [CmdOp("asm/check/luts")]
    void RunAsmChecks()
    {
        vlut(w128);
        vlut(w256);
    }

    void vlut(W128 w)
    {
        // lut := <0,1,2,...,15> ; defines 16 indicies in a table with up to 255 entries
        var lut = VLut.init(vcpu.vparts(w128,
            0x00, 
            0x01, 
            0x02, 
            0x03, 
            0x04, 
            0x05, 
            0x06, 
            0x07, 
            0x08,
            0x09, 
            0x0a, 
            0x0b, 
            0x0c, 
            0x0d, 
            0x0e, 
            0x0f
            ));
        // items := <64,65,...,79>
        var items = vcpu.vparts(w128,
            0x22, 
            0x34, 
            0x45, 
            0x26, 
            0x27, 
            0x28, 
            0x09, 
            0x2a, 
            0x2b,
            0x2c, 
            0x2d, 
            0x10, 
            0x11, 
            0x12, 
            0x13, 
            0x14
        );
        var selected = lut.Select(items);
        VClaim.veq(items, selected);
        Channel.Row($"{items.Format()} == {selected.Format()}");
    }

    void vlut(W256 w)
    {
        // lut := <0,1,2,...,31>  ; defines 32 indicies in a table with up to 255 entries
        var lut = VLut.init(vgcpu.vinc<byte>(w));
        // items := <64,65,...,95>
        var items = vgcpu.vinc<byte>(w, 64);
        var selected = lut.Select(items);
        var expect = items;
        VClaim.veq(expect, selected);
        Channel.Row($"{expect.Format()} == {selected.Format()}");
    }

}