//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Numeric;

    public class t_ternary_logic : t_logix<t_ternary_logic>
    {
        protected override int RepCount => Pow2.T08;

        ReadOnlySpan<TernaryBitLogicKind> TernaryKinds
            => NumericLogixHost.TernaryLogicKinds;

        public void op_identities()
        {
            foreach(var kind in TernaryKinds)
            {
                check_op_identity<byte>(kind);
                check_op_identity<ushort>(kind);
                check_op_identity<uint>(kind);
                check_op_identity<ulong>(kind);
            }
        }

        public void op_equivalence()
        {
            foreach(var kind in TernaryKinds)
            {
                check_op_equivalence<byte>(kind);
                check_op_equivalence<ushort>(kind);
                check_op_equivalence<uint>(kind);
                check_op_equivalence<ulong>(kind);
            }
        }

        public void op_select()
        {
            check_select<byte>();
            check_select<ushort>();
            check_select<uint>();
            check_select<ulong>();
            check_select<byte>(n128);
            check_select<ushort>(n128);
            check_select<uint>(n128);
            check_select<ulong>(n128);
            check_select<byte>(n256);
            check_select<ushort>(n256);
            check_select<uint>(n256);
            check_select<ulong>(n256);
        }

        void check_select<T>()
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var width = width<T>();
                var a = Random.ScalarBits<T>();
                var b = Random.ScalarBits<T>();
                var c = Random.ScalarBits<T>();
                ScalarBits<T> x = NumericLogixOps.select(a.State, b.State, c.State);
                for(var j=0; j<x.Width; j++)
                    Claim.eq(x[j], BitLogix.select(a[j],b[j],c[j]));
            }
        }

        void check_select<T>(N128 n = default)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.CpuVector<T>(n);
                var b = Random.CpuVector<T>(n);
                var c = Random.CpuVector<T>(n);
                var x = gcpu.vselect(a,b,c);

                var sa = a.ToSpan();
                var sb = b.ToSpan();
                var sc = c.ToSpan();
                var sx = x.ToSpan();

                for(var j=0; j<sx.Length; j++)
                    Claim.eq(sx[j], NumericLogixOps.select(sa[j], sb[j], sc[j]));
            }
        }


        void check_select<T>(N256 n = default)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.CpuVector<T>(n);
                var b = Random.CpuVector<T>(n);
                var c = Random.CpuVector<T>(n);
                var x = gcpu.vselect(a,b,c);

                var sa = a.ToSpan();
                var sb = b.ToSpan();
                var sc = c.ToSpan();
                var sx = x.ToSpan();

                for(var j=0; j<sx.Length; j++)
                    Claim.eq(sx[j], NumericLogixOps.select(sa[j], sb[j], sc[j]));
            }
        }

        void check_op_identity<T>(TernaryBitLogicKind id)
            where T: unmanaged
        {
            var a = force<T>(0b1111_0000);
            var b = force<T>(0b1100_1100);
            var c = force<T>(0b1010_1010);
            var d = force<T>(0b1111_1111);
            var f = NumericLogixHost.lookup<T>(id);
            var actual = force<T,byte>(gmath.and(f(a,b,c), d));
            var expect = (byte)id;
            Claim.eq(expect.FormatHex(), actual.FormatHex());
        }

        void check_op_equivalence<T>(TernaryBitLogicKind kind)
            where T: unmanaged
        {
            var width = width<T>();
            for(var i=0; i<RepCount; i++)
            {
                var a = Random.ScalarBits<T>();
                var b = Random.ScalarBits<T>();
                var c = Random.ScalarBits<T>();
                var u = ScalarBits.alloc<T>();

                for(var j=0; j<width; j++)
                    u[j] = bitlogix.Evaluate(kind, a[j], b[j], c[j]);


                ScalarBits<T> v = NumericLogixHost.eval(kind, a.State, b.State, c.State);

                if(u != v)
                    Notify($"Equivalence failed for ternary op {kind}:{TypeIdentity.numeric<T>()}");

                Claim.eq(u,v);
            }
        }
    }
}