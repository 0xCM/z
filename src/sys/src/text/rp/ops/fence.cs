//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class RP
    {
        [MethodImpl(Inline), Op, Closures(NumericKind.U16 | NumericKind.U8)]
        public static Fence<T> fence<T>(T left, T right)
            => new Fence<T>(left,right);
    }
}
