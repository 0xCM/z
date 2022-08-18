//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiClasses;

    partial struct CalcHosts
    {
        public readonly struct VMoveMask128<T> : IVUnaryScalarFunc128<T,ushort>
            where T : unmanaged
        {

            [MethodImpl(Inline)]
            public ushort Invoke(Vector128<T> x)
                => cpu.vmovemask(cpu.v8u(x));
        }

        public readonly struct VMoveMask256<T> : ISVUnaryScalarFunc256<T,uint>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public uint Invoke(Vector256<T> x)
                => cpu.vmovemask(cpu.v8u(x));
        }
    }
}