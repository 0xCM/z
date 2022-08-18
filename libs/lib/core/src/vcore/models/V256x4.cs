//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct V256x4
    {
        Vector256<ushort> X0;

        Vector256<ushort> X1;

        Vector256<ushort> X2;

        Vector256<ushort> X3;

        [MethodImpl(Inline), Op]
        public V256x4(Vector256<ushort> x0, Vector256<ushort> x1, Vector256<ushort> x2, Vector256<ushort> x3)
        {
            X0 = x0;
            X1 = x1;
            X2 = x2;
            X3 = x3;
        }
    }
}