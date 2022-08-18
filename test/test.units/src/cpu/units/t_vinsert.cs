//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vinsert : t_inx<t_vinsert>
    {
        public void vinsert_128x8i()
            => vinsert_check<sbyte>(w128);

        public void vinsert_128x8u()
            => vinsert_check<byte>(w128);

        public void vinsert_128x16i()
            => vinsert_check<short>(w128);

        public void vinsert_128x16u()
            => vinsert_check<ushort>(w128);

        public void vinsert_128x32i()
            => vinsert_check<int>(w128);

        public void vinsert_128x32u()
            => vinsert_check<uint>(w128);

        public void vinsert_128x64i()
            => vinsert_check<long>(w128);

        public void vinsert_128x64u()
            => vinsert_check<ulong>(w128);

        public void vinsert_128x32f()
            => vinsert_check<float>(w128);

        public void vinsert_128x64f()
            => vinsert_check<double>(w128);

        protected void vinsert_check<T>(W128 w, T t = default)
            where T : unmanaged
        {
            for(var i=0; i < RepCount; i++)
            {
                var v128Src = Random.CpuVector<T>(w);
                var srcSpan = v128Src.ToSpan();

                var dst = gcpu.vzero(n256,t);
                var vLo = gcpu.vinsert(v128Src, dst, (byte)0);
                var vLoSpan = vLo.ToSpan().Slice(0, vLo.Length()/2);

                var vHi = gcpu.vinsert(v128Src, dst, (byte)1);
                var vHiSpan = vHi.ToSpan().Slice(vLo.Length()/2);

                ClaimNumeric.eq(srcSpan, vLoSpan);
                ClaimNumeric.eq(srcSpan, vHiSpan);
            }
        }
    }
}