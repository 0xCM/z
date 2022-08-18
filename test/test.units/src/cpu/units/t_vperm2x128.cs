//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class t_vperm2x128 : t_inx<t_vperm2x128>
    {
        static string describe<T>(Vector512<T> src, Perm2x4 p0, Perm2x4 p1)
            where T : unmanaged
        {
            var sep = Chars.Comma;
            var pad = 2;

            var dst = gcpu.vperm2x128(src, p0, p1);
            var sym0 = PermSymbolic.symbols(p0).ToString();
            var sym1 = PermSymbolic.symbols(p1).ToString();
            var description = $"{src.Format()} |> {sym0}{sym1} = {dst.Format()}";
            return description;
        }

        public void vperm2x128_outline()
        {
            void case1()
            {
                // [0, 1, 2, 3, 4, 5, 6, 7] |> DABC = [6, 7, 0, 1, 2, 3, 4, 5] - rotate right
                var p0 = Perm2x4.DA;
                var p1 = Perm2x4.BC;
                var src = gcpu.vinc<ulong>(w512);
                var expect = cpu.vparts(w512,6, 7, 0, 1, 2, 3, 4, 5);
                var actual = gcpu.vperm2x128(src, p0, p1);
                Claim.eq(actual,expect);
                Notify(describe(src,p0,p1));
            }

            case1();
        }
    }
}