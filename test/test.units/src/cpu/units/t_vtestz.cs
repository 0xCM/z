//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_vtestz : t_inx<t_vtestz>
    {
        public void vtestz_128x8i()
            => vtestz_check<sbyte>(n128);

        public void vtestz_128x8u()
            => vtestz_check<byte>(n128);

        public void vtestz_128x16i()
            => vtestz_check<short>(n128);

        public void vtestz_128x16u()
            => vtestz_check<ushort>(n128);

        public void vtestz_128x32i()
            => vtestz_check<int>(n128);

        public void vtestz_128x32u()
            => vtestz_check<uint>(n128);

        public void vtestz_128x64i()
            => vtestz_check<long>(n128);

        public void vtestz_128x64u()
            => vtestz_check<ulong>(n128);

        public void vtestz_256x8i()
            => vtestz_check<sbyte>(n256);

        public void vtestz_256x8u()
            => vtestz_check<byte>(n256);

        public void vtestz_256x16i()
            => vtestz_check<short>(n256);

        public void vtestz_256x16u()
            => vtestz_check<ushort>(n256);

        public void vtestz_256x32i()
            => vtestz_check<int>(n256);

        public void vtestz_256x32u()
            => vtestz_check<uint>(n256);

        public void vtestz_256x64i()
            => vtestz_check<long>(n256);

        public void vtestz_256x64u()
            => vtestz_check<ulong>(n256);

        protected void vtestz_check<T>(N128 w = default, T t = default)
            where T : unmanaged
        {

            for(var i=0; i< RepCount; i++)
            {
                var x = Random.CpuVector(w,t);

                // Creates a mask corresponding to each off bit in the source vector
                // thereby establishing the the context where testz will return true
                // since all mask-identified source bits are disabled
                var mask = gcpu.vcnonimpl(gcpu.vones(w,t), x);

                Claim.require(gcpu.vtestz(x,mask));
            }
        }

        protected void vtestz_check<T>(N256 w = default, T t = default)
            where T : unmanaged
        {

            for(var i=0; i< RepCount; i++)
            {
                var x = Random.CpuVector(w,t);

                // Creates a mask corresponding to each off bit in the source vector
                // thereby establishing the the context where testz will return true
                // since all mask-identified source bits are disabled
                var mask = gcpu.vcnonimpl(gcpu.vones(w,t), x);

                Claim.require(gcpu.vtestz(x,mask));
            }
        }
    }
}