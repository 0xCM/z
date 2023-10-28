//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    [MethodImpl(Inline), Dot]
    public static long vdot(Vector256<int> x, Vector256<int> y)
    {
        var product = Multiply(x,y);
        var sum = vadd(vlo(product), vhi(product));
        return sum.Cell(0) + sum.Cell(1);
    }

    [MethodImpl(Inline), Dot]
    public static ulong vdot(Vector256<uint> x, Vector256<uint> y)
    {
        var product = Multiply(x,y);
        var sum = vadd(vlo(product), vhi(product));
        return sum.Cell(0) + sum.Cell(1);
    }
}
