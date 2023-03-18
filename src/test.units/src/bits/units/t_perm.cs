//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class t_perm : t_bits<t_perm>
    {
        public void perm_create_8u()
             => perm_create((byte)5, (byte)100);

        public void perm_swap_8u()
        {
            var id = Permute.identity((byte)32);
            var p = id.Replicate();
            p.Swap(3,4).Swap(4,5).Swap(5,6);
            Claim.eq(p[6], id[3]);
        }

        void perm_create<T>(T m, T n)
            where T : unmanaged
        {
            var perm = Permute.identity(n);
            var lengths = gcalc.stream(m,n);
            core.iter(lengths, i => {
                var p = Permute.identity(i);
                var cycle = p.Cycle(default(T));
                Claim.eq(cycle.Length, 1);
            });

        }
    }
}
