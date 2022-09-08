//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class TypeNats
    {
        /// <summary>
        /// Specifies the dimension of a 2-D grid
        /// </summary>
        public readonly struct Dim<X0,X1,X2,T>
            where X0 : unmanaged, ITypeNat
            where X1 : unmanaged, ITypeNat
            where X2 : unmanaged, ITypeNat
            where T : unmanaged
        {
            public static X0 X => default;

            public static X1 Y => default;

            public static X2 Z => default;

            public T A
            {
                [MethodImpl(Inline)]
                get => @as<ulong,T>(X.NatValue);
            }

            public T B
            {
                [MethodImpl(Inline)]
                get => @as<ulong,T>(Y.NatValue);
            }

            public T C
            {
                [MethodImpl(Inline)]
                get => @as<ulong,T>(Z.NatValue);
            }

            public static Dim<X0,X1,X2,T> Value => default;
        }
    }
}