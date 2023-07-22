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

    }
}