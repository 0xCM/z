//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class t_vclear :  t_inx<t_vconvert>
    {
        public void vclear_128x8()
            => vclear_check(w128,z8);

        public void vclear_128x32()
            => vclear_check(w128,z32);

        public void vclear_256x8()
            => vclear_check(w256,z8);

        public void vclear_256x16()
            => vclear_check(w256,z16);

        public void vclear_256x32()
            => vclear_check(w256,z32);

        public void vclear_256x64()
            => vclear_check(w256,z16);

        public void vclear_check<T>(W256 w, T t = default)
            where T : unmanaged
        {
            for(var i=0; i< RepCount; i++)
            {
                byte start = Random.Next<byte>(0, (byte)width<T>());
                byte length = (byte)(width<T>() - start);
                var cellcount = w/width<T>();
                var x = Random.CpuVector<T>(w);
                var x1 = vmask.vdisable(x, start, length);
                var x2 = gcpu.vsrl(x1,start);
                Claim.nea(gcpu.vnonz(x2));
            }
        }

        protected void vclear_check<T>(W128 w, T t = default)
            where T : unmanaged
        {
            for(var i=0; i< RepCount; i++)
            {
                byte start = Random.Next<byte>(0, (byte)width<T>());
                byte length = (byte)(width<T>() - start);
                var cellcount = w/width<T>();
                var x = Random.CpuVector<T>(w);
                var x1 = vmask.vdisable(x, start, length);
                var x2 = gcpu.vsrl(x1,start);
                Claim.nea(gcpu.vnonz(x2));
            }
        }        
    }
}