//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
         [Closures(Integers), Sllx]
         public readonly struct VSllx128<T> : IShiftOp128<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte count)
                => vgcpu.vsllx(x,count);
        }

        [Closures(Integers), Sllx]
        public readonly struct VSllx256<T> : IShiftOp256<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, byte count)
                => vgcpu.vsllx(x,count);
        }
    }
}