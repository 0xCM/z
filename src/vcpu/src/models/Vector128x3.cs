//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

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
        dst.A = v64u(src.A);
        dst.B = v64u(src.B);
        dst.C = v64u(src.C);
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
