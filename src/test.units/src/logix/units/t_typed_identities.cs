//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using System.Runtime.Intrinsics;

    using TL = TypedLogicSpec;
    using static core;

    public class t_typed_identities : t_logix<t_typed_identities>
    {
        public void check_identity_stream()
        {
            Claim.nonzero(TypedIdentities.ScalarIdentities<byte>().Length);
            Claim.nonzero(TypedIdentities.ScalarIdentities<ushort>().Length);
            Claim.nonzero(TypedIdentities.ScalarIdentities<uint>().Length);
            Claim.nonzero(TypedIdentities.ScalarIdentities<ulong>().Length);

            Claim.nonzero(TypedIdentities.Vec128Identities<byte>().Length);
            Claim.nonzero(TypedIdentities.Vec128Identities<ushort>().Length);
            Claim.nonzero(TypedIdentities.Vec128Identities<uint>().Length);
            Claim.nonzero(TypedIdentities.Vec128Identities<ulong>().Length);

            Claim.nonzero(TypedIdentities.Vec256Identities<byte>().Length);
            Claim.nonzero(TypedIdentities.Vec256Identities<ushort>().Length);
            Claim.nonzero(TypedIdentities.Vec256Identities<uint>().Length);
            Claim.nonzero(TypedIdentities.Vec256Identities<ulong>().Length);
        }

        public void check_scalar_identities()
        {
            iter(TypedIdentities.ScalarIdentities<byte>(), check_identity);
            iter(TypedIdentities.ScalarIdentities<ushort>(), check_identity);
            iter(TypedIdentities.ScalarIdentities<uint>(), check_identity);
            iter(TypedIdentities.ScalarIdentities<ulong>(), check_identity);
        }

        public void check_vec128_identities()
        {
            iter(TypedIdentities.Vec128Identities<byte>(), id => check_identity(n128,id));
            iter(TypedIdentities.Vec128Identities<ushort>(), id => check_identity(n128,id));
            iter(TypedIdentities.Vec128Identities<uint>(), id => check_identity(n128,id));
            iter(TypedIdentities.Vec128Identities<ulong>(), id => check_identity(n128,id));
        }

        public void check_vec256_identities()
        {
            iter(TypedIdentities.Vec256Identities<byte>(), id => check_identity(n256,id));
            iter(TypedIdentities.Vec256Identities<ushort>(), id => check_identity(n256,id));
            iter(TypedIdentities.Vec256Identities<uint>(), id => check_identity(n256,id));
            iter(TypedIdentities.Vec256Identities<ulong>(), id => check_identity(n256,id));
        }

        void check_identity<T>(ComparisonExpr<T> identity)
            where T :unmanaged
        {
            var @true = NumericLogixOps.@true<T>();
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.Next<T>();
                var y = Random.Next<T>();
                identity.SetVars(x,y);
                Claim.eq(TL.@true<T>(), LogixEngine.eval(identity));
                Claim.require(LogixEngine.satisfied(identity, x, y));
            }
        }

        void check_identity<T>(W128 w, ComparisonExpr<Vector128<T>> identity)
            where T :unmanaged
        {
            var @true = gcpu.vtrue<T>(w);
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.CpuVector<T>(w);
                var y = Random.CpuVector<T>(w);
                identity.SetVars(x,y);

                Claim.veq(@true,LogixEngine.eval(identity).Value);
                Claim.require(LogixEngine.satisfied(identity, x,y));
            }
        }

        void check_identity<T>(W256 w, ComparisonExpr<Vector256<T>> equality)
            where T :unmanaged
        {
            var @true = gcpu.vtrue<T>(w);
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.CpuVector<T>(w);
                var y = Random.CpuVector<T>(w);

                equality.SetVars(x,y);

                Claim.veq(@true, LogixEngine.eval(equality).Value);
                Claim.require(LogixEngine.satisfied(equality, x,y));
            }
        }
    }
}