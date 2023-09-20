//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static NativeSigs;

[StructLayout(LayoutKind.Sequential,Pack=1)]
public readonly record struct NativeSegType : INativeType<NativeSegType>
{
    public readonly Scalar CellType;

    public readonly byte CellCount;

    [MethodImpl(Inline)]
    public NativeSegType(Scalar ct, byte count)
    {
        CellType = ct;
        CellCount = count;
    }

    public BitWidth Width
    {
        [MethodImpl(Inline)]
        get => CellType.Width*CellCount;
    }

    public NativeSegKind SegKind
    {
        [MethodImpl(Inline)]
        get => sys.@as<NativeSegType,NativeSegKind>(this);
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => Sized.native(Width);
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => sys.hash(CellType.GetHashCode(), CellCount);
    }

    public bool IsVoid
    {
        [MethodImpl(Inline)]
        get => CellType.IsVoid;
    }

    [MethodImpl(Inline)]
    public bool Equals(NativeSegType src)
        => CellType.Equals(src.CellType) && CellCount == src.CellCount;

    public override int GetHashCode()
        => Hash;

    public string Format()
        => NativeSigs.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator NativeSegType((Scalar ct, byte count) src)
        => new (src.ct, src.count);

    [MethodImpl(Inline)]
    public static implicit operator NativeSegType(NativeSegKind kind)
        => sys.@as<NativeSegKind,NativeSegType>(kind);

    [MethodImpl(Inline)]
    public static implicit operator NativeSegKind(NativeSegType src)
        => src.SegKind;

    public static NativeSegType Void
    {
        [MethodImpl(Inline)]
        get => new (Scalar.Void,0);
    }
}
