
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public class t_vlut : t_inx<t_vlut>
    {
        public void lut16_rep_check()
        {
            var w = w128;
            var lut = VLut.init(gcpu.vinc<byte>(w));
            var found = gcpu.vinc<byte>(w, 64);
            VClaim.veq(found, lut.Select(found));
        }

        public void lut32_rep_check()
        {
            var w = w256;
            var lut = VLut.init(gcpu.vinc<byte>(w));
            var found = gcpu.vinc<byte>(w, 64);
            VClaim.veq(found, lut.Select(found));
        }
    }
}