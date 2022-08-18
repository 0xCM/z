//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct V512x4
    {
        Vector512<ushort> X0;

        Vector512<ushort> X1;

        Vector512<ushort> X2;

        Vector512<ushort> X3;

        [MethodImpl(Inline), Op]
        public V512x4(Vector512<ushort> x0, Vector512<ushort> x1, Vector512<ushort> x2, Vector512<ushort> x3)
        {
            X0 = x0;
            X1 = x1;
            X2 = x2;
            X3 = x3;
        }

        [MethodImpl(Inline), Op]
        public V512x4(
            Vector256<ushort> x0, Vector256<ushort> x1, Vector256<ushort> x2, Vector256<ushort> x3,
            Vector256<ushort> x4, Vector256<ushort> x5, Vector256<ushort> x6, Vector256<ushort> x7
        )
        {
            X0 = (x0,x1);
            X1 = (x2,x3);
            X2 = (x4,x5);
            X3 = (x6,x7);
        }
    }
}