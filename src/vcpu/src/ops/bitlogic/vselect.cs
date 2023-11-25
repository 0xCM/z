//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


partial class vcpu 
{
    [MethodImpl(Inline), Select]
    public static Vector128<byte> vselect(Vector128<byte> x, Vector128<byte> y, Vector128<byte> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector128<sbyte> vselect(Vector128<sbyte> x, Vector128<sbyte> y, Vector128<sbyte> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector128<ushort> vselect(Vector128<ushort> x, Vector128<ushort> y, Vector128<ushort> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector128<uint> vselect(Vector128<uint> x, Vector128<uint> y, Vector128<uint> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector128<ulong> vselect(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector256<byte> vselect(Vector256<byte> x, Vector256<byte> y, Vector256<byte> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector256<ushort> vselect(Vector256<ushort> x, Vector256<ushort> y, Vector256<ushort> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector256<uint> vselect(Vector256<uint> x, Vector256<uint> y, Vector256<uint> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector256<ulong> vselect(Vector256<ulong> x, Vector256<ulong> y, Vector256<ulong> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<byte> vselect(Vector512<byte> x, Vector512<byte> y, Vector512<byte> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<sbyte> vselect(Vector512<sbyte> x, Vector512<sbyte> y, Vector512<sbyte> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<ushort> vselect(Vector512<ushort> x, Vector512<ushort> y, Vector512<ushort> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<short> vselect(Vector512<short> x, Vector512<short> y, Vector512<short> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<int> vselect(Vector512<int> x, Vector512<int> y, Vector512<int> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<uint> vselect(Vector512<uint> x, Vector512<uint> y, Vector512<uint> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<long> vselect(Vector512<long> x, Vector512<long> y, Vector512<long> z)
        => vor(vand(x,y), vnonimpl(x,z));

    [MethodImpl(Inline), Select]
    public static Vector512<ulong> vselect(Vector512<ulong> x, Vector512<ulong> y, Vector512<ulong> z)
        => vor(vand(x,y), vnonimpl(x,z));
}
