//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Test
{
    using static Root;

    public class t_matrix_writer : UnitTest<t_matrix_writer>
    {
        public override bool Enabled => true;

        public t_matrix_writer()
        {
            //UnitDataDir.Clear();
        }

        public void check_matrix_emission_n12xn14x64i()
            => check64i(Pow2.T03, n12, n14);

        public void check_matrix_emission_n19xn32x8u()
            => check8u(Pow2.T03, n19, n32);

        void check_matrix_emission_n5xn5x32u()
            => check32u(Pow2.T03, n5, n5);

        void check_matrix_emission_n31xn31x32u()
            => check32u(Pow2.T03, n31, n31);

        void check_matrix_emission_n5xn5x64f()
            => check64f(Pow2.T03, n5, n5);

        void check64i(uint count, N12 m, N14 n)
            => check_emission<N12,N14,long>(count);

        void check8u(uint count, N19 m, N32 n)
            => check_emission(count, m, n, z8);

        void check32u(uint count, N31 m, N31 n)
            => check_emission(count, m, n, z32);

        void check32u(uint count, N5 m, N5 n)
            => check_emission(count, m, n, z32);

        void check64f(uint count, N5 m, N5 n)
            => check_emission(count, m, n, z64);

        public FS.FileName filename<M,N,T>(uint i, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => MatrixIO.filename<M,N,T>((int)i);

        void check_emission<M,N,T>(uint count, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            for(var i=0u; i< count; i++)
            {
                var path = Paths.CasePath(filename<M,N,T>(i));
                var matrix = Random.MatrixBlock<M,N,T>();
                var A = MatrixIO.write(matrix, path, m, n, t);
                var B = MatrixIO.read(path, m, n, t);
                Claim.require(A == B);
            }
        }
    }
}