//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class t_testbit : t_bits<t_testbit>
    {
        public void testbit_8u()
            => testbit_check(z8);

        public void testbit_8i()
            => testbit_check(z8i);

        public void testbit_16u()
            => testbit_check(z16);

        public void testbit_16i()
            => testbit_check(z16i);

        public void testbit_32u()
            => testbit_check(z32);

        public void testbit_32i()
            => testbit_check(z32i);

        public void testbit_64u()
            => testbit_check(z64);

        public void testbit_64i()
            => testbit_check(z64i);

        protected void testbit_check<T>(T t = default)
            where T : unmanaged
        {
            var src = ones<T>();
            for(var i=0; i<width<T>(); i++)
                Claim.require(gbits.test(src,i));
        }
    }
}