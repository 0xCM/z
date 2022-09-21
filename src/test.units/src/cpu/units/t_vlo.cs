//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vlo : t_inx<t_vlo>
    {
        public void vlo_128x8u()
            => vlo_check<byte>(w128, z8);

        public void vlo_128x8i()
            => vlo_check<sbyte>(w128, z8i);

        public void vlo_128x16i()
            => vlo_check<short>(w128, z16i);

        public void vlo_128x16u()
            => vlo_check<ushort>(w128, z16);

        public void vlo_128x32i()
            => vlo_check<int>(w128);

        public void vlo_128x32u()
            => vlo_check<uint>(w128);

        public void vlo_128x64i()
            => vlo_check<long>(w128);

        public void vlo_128x64u()
            => vlo_check<ulong>(w128);

        public void vlo_128x32f()
            => vlo_check<float>(w128);

        public void vlo_128x64f()
            => vlo_check<double>(w128);

        public void vlo_256x8u()
            => vlo_check<byte>(n256);

        public void vlo_256x8i()
            => vlo_check<sbyte>(n256);

        public void vlo_256x16i()
            => vlo_check<short>(n256);

        public void vlo_256x16u()
            => vlo_check<ushort>(n256);

        public void vlo_256x32i()
            => vlo_check<int>(n256);

        public void vlo_256x32u()
            => vlo_check<uint>(n256);

        public void vlo_256x64i()
            => vlo_check<long>(n256);

        public void vlo_256x64u()
            => vlo_check<ulong>(n256);

        public void vlo_256x32f()
            => vlo_check<float>(n256);

        public void vlo_256x64f()
            => vlo_check<double>(n256);

        protected void vlo_check<T>(N128 w, T t = default)
            where T : unmanaged
        {
            var count = cpu.vcount(w,t);
            var f = Calcs.vlo(w,t);
            var r = PolyVector.vemitter<T>(w,Random);
            for(var rep=0; rep < RepCount; rep++)
            {
                var x = r.Invoke();
                var h = f.Invoke(x);

                for(int i=0; i < count/2; i++)
                    Claim.eq(x.Cell(i), h.Cell(i));
            }
        }

        protected void vlo_check<T>(N256 w, T t = default)
            where T : unmanaged
        {
            var f = Calcs.vlo(w,t);
            var r = PolyVector.vemitter<T>(w,Random);
            for(var rep=0; rep < RepCount; rep++)
            {
                var x = r.Invoke();
                var y = f.Invoke(x);
                var z = gcpu.vinsert(y,x,(byte)0);
                Claim.veq(x,z);
            }
        }
    }
}