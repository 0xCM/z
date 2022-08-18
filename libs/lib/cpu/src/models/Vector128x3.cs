//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector128x3<T>
        where T : unmanaged
    {
        public Vector128<T> A;

        public Vector128<T> B;

        public Vector128<T> C;

        [MethodImpl(Inline)]
        public static implicit operator Vector128x3(Vector128x3<T> src)
        {
            var dst = default(Vector128x3);
            dst.Kind = NumericKinds.kind<T>();
            dst.A = cpu.v64u(src.A);
            dst.B = cpu.v64u(src.B);
            dst.C = cpu.v64u(src.C);
            return dst;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector128x3
    {
        public NumericKind Kind;

        public Vector128<ulong> A;

        public Vector128<ulong> B;

        public Vector128<ulong> C;
    }
}