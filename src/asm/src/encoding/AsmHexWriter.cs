//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

[ApiComplete]
public class AsmHexWriter
{
    [MethodImpl(Inline)]
    public static AsmHexWriter create()
        => new ();

    [MethodImpl(Inline), Op, Closures(Int8x64k)]
    static ref T cell<T>(Span<byte> src, uint offset)
        where T : unmanaged
            => ref first<T>(slice(src, offset));

    AsmHexCode Dst;

    uint Offset;

    [MethodImpl(Inline)]
    public AsmHexWriter()
    {
        Dst = AsmHexCode.Empty;
        Offset = 0;
    }

    [MethodImpl(Inline)]
    public AsmHexWriter Clear()
    {
        Dst = AsmHexCode.Empty;
        Offset = 0;
        return this;
    }

    public ref readonly AsmHexCode Target
    {
        [MethodImpl(Inline)]
        get => ref Dst;
    }

    [MethodImpl(Inline)]
    public ref readonly AsmHexCode Write<T>(in T src)
        where T : unmanaged
    {
        var size = (byte)size<T>();
        Dst.Size = (byte)(Dst.Size + size);
        cell<T>(Dst.Bytes, Offset) = src;
        Offset += size;
        return ref Target;
    }

    [MethodImpl(Inline)]
    public ref readonly AsmHexCode Write<A,B>(in A a, in B b)
        where A : unmanaged
        where B : unmanaged
    {
        Write(a);
        Write(b);
        return ref Target;
    }

    [MethodImpl(Inline)]
    public ref readonly AsmHexCode Write<A,B,C>(in A a, in B b, in C c)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
    {
        Write(a);
        Write(b);
        Write(c);
        return ref Target;
    }

    [MethodImpl(Inline)]
    public ref readonly AsmHexCode Write<A,B,C,D>(in A a, in B b, in C c, in D d)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
    {
        Write(a);
        Write(b);
        Write(c);
        Write(d);
        return ref Target;
    }

    [MethodImpl(Inline), Op]
    public static void encode(Hex8 a0, Imm8 a1, AsmHexWriter dst)
        => dst.Write(a0,a1);

    [MethodImpl(Inline), Op]
    public static void encode(RexPrefix a0, Hex8 a1, Imm64 a2, AsmHexWriter dst)
        => dst.Write(a0,a1,a2);
}
