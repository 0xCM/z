//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    public class t_vmovemask : t_inx<t_vmovemask>
    {
        public void vmovemask_check()
        {
            vmovemask_check(n128);
            vmovemask_check(n256);
        }

        void vmovemask_check(N128 w)
        {
            vmovemask_check(w,z8);
            vmovemask_check(w,z8i);
            vmovemask_check(w,z16);
            vmovemask_check(w,z16i);
            vmovemask_check(w,z32);
            vmovemask_check(w,z32i);
            vmovemask_check(w,z64);
            vmovemask_check(w,z64i);
            vmovemask_check(w,z32f);
            vmovemask_check(w,z64f);
        }

        void vmovemask_check(N256 w)
        {
            vmovemask_check(w,z8);
            vmovemask_check(w,z8i);
            vmovemask_check(w,z16);
            vmovemask_check(w,z16i);
            vmovemask_check(w,z32);
            vmovemask_check(w,z32i);
            vmovemask_check(w,z64);
            vmovemask_check(w,z64i);
            vmovemask_check(w,z32f);
            vmovemask_check(w,z64f);
        }

        void vmovemask_check<T>(N128 w, T t = default)
            where T : unmanaged
        {
            const int count = 16;
            var service = Calcs.vmovemask(w,t);
            var emitter = PolyVector.vemitter<T>(w,Random);

            void check()
            {
                for(var rep=0; rep<RepCount; rep++)
                {
                    var x = emitter.Invoke();
                    var a = service.Invoke(x);
                    var y = v8u(x);
                    for(byte j=0; j<count; j++)
                        Claim.eq(gbits.test(vcell(y,j), 7), gbits.test(a,(byte)j));
                }
            }

            CheckAction(check, CaseName(service));
        }

        void vmovemask_check<T>(N256 w, T t = default)
            where T : unmanaged
        {
            const int count = 32;
            var service = Calcs.vmovemask(w,t);
            var emitter = PolyVector.vemitter<T>(w,Random);

            void check()
            {
                for(var rep=0; rep<RepCount; rep++)
                {
                    var x = emitter.Invoke();
                    var a = service.Invoke(x);
                    var y = v8u(x);
                    for(byte j=0; j<count; j++)
                        Claim.eq(gbits.test(vcell(y,j), 7), gbits.test(a,(byte)j));
                }
            }

            CheckAction(check, CaseName(service));
        }
    }
}