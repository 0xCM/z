//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    [MethodImpl(Inline), Select]
    public static Vector128<byte> vselect(Vector128<byte> a, Vector128<byte> b, Vector128<byte> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<sbyte> vselect(Vector128<sbyte> a, Vector128<sbyte> b, Vector128<sbyte> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<short> vselect(Vector128<short> a, Vector128<short> b, Vector128<short> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<ushort> vselect(Vector128<ushort> a, Vector128<ushort> b, Vector128<ushort> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<int> vselect(Vector128<int> a, Vector128<int> b, Vector128<int> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<uint> vselect(Vector128<uint> a, Vector128<uint> b, Vector128<uint> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<long> vselect(Vector128<long> a, Vector128<long> b, Vector128<long> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector128<ulong> vselect(Vector128<ulong> a, Vector128<ulong> b, Vector128<ulong> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<sbyte> vselect(Vector256<sbyte> a, Vector256<sbyte> b, Vector256<sbyte> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<byte> vselect(Vector256<byte> a, Vector256<byte> b, Vector256<byte> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<short> vselect(Vector256<short> a, Vector256<short> b, Vector256<short> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<ushort> vselect(Vector256<ushort> a, Vector256<ushort> b, Vector256<ushort> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<int> vselect(Vector256<int> a, Vector256<int> b, Vector256<int> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<uint> vselect(Vector256<uint> a, Vector256<uint> b, Vector256<uint> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<long> vselect(Vector256<long> a, Vector256<long> b, Vector256<long> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector256<ulong> vselect(Vector256<ulong> a, Vector256<ulong> b, Vector256<ulong> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<byte> vselect(Vector512<byte> a, Vector512<byte> b, Vector512<byte> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<sbyte> vselect(Vector512<sbyte> a, Vector512<sbyte> b, Vector512<sbyte> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<ushort> vselect(Vector512<ushort> a, Vector512<ushort> b, Vector512<ushort> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<short> vselect(Vector512<short> a, Vector512<short> b, Vector512<short> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<int> vselect(Vector512<int> a, Vector512<int> b, Vector512<int> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<uint> vselect(Vector512<uint> a, Vector512<uint> b, Vector512<uint> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<long> vselect(Vector512<long> a, Vector512<long> b, Vector512<long> c)
        => vor(vand(a,b), vnonimpl(a,c));

    [MethodImpl(Inline), Select]
    public static Vector512<ulong> vselect(Vector512<ulong> a, Vector512<ulong> b, Vector512<ulong> c)
        => vor(vand(a,b), vnonimpl(a,c));
}
