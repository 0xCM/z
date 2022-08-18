//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static SFx;

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(Closure)]
        public readonly struct Pop<T> : IFunc<T,uint>
            where T : unmanaged
        {
            public static Pop<T> Op => default;

            public const string Name = "popcount";

            public OpIdentity Id
                => SFxIdentity.identity<T>(Name);

            [MethodImpl(Inline)]
            public uint Invoke(T a)
                => gbits.pop(a);
        }

        [Closures(Closure), Pop]
        public readonly struct VPop128<T> : ISVTernaryScalar128D<T,uint>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public uint Invoke(Vector128<T> x,Vector128<T> y,Vector128<T> z)
                => gcpu.vpop(x,y,z);

            [MethodImpl(Inline)]
            public uint Invoke(T a, T b, T c)
                => gbits.pop(a,b,c);
        }

        [Closures(Closure), Pop]
        public readonly struct VPop256<T> : ISVTernaryScalarFunc256D<T,uint>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public uint Invoke(Vector256<T> x, Vector256<T> y, Vector256<T> z)
                => gcpu.vpop(x,y,z);

            [MethodImpl(Inline)]
            public uint Invoke(T a, T b, T c)
                => gbits.pop(a, b, c);
        }
    }
}