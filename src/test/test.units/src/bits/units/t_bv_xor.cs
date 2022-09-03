//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_bv_xor : t_bits<t_bv_xor>
    {
        public void bvxor_check()
        {
            bvxor_check(z8);
            bvxor_check(z16);
            bvxor_check(z32);
            bvxor_check(z64);
        }

        void bvxor_check<T>(T t = default)
            where T : unmanaged
        {
            var f = Calcs.bvxor<T>();

            void check()
            {
                for(var rep=0; rep<RepCount; rep++)
                {
                    var x = Random.ScalarBits<T>();
                    var y = Random.ScalarBits<T>();
                    var result = f.Invoke(x,y);
                    var expect = f.Invoke(x.State,y.State);
                    Claim.eq(expect,result.State);
                }

            }

            CheckAction(check, SFxIdentity.name(f));
        }
    }
}