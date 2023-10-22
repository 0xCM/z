//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static NativeSigs;

public readonly record struct NativeType : INativeType<NativeType>, IEquatable<NativeType>
{
    [MethodImpl(Inline)]
    public static NativeType define(Scalar src)
        => new (src);

    readonly ushort Data;

    [MethodImpl(Inline)]
    public NativeType(Scalar src)
    {
        Data = sys.@as<Scalar,byte>(src);
    }

    [MethodImpl(Inline)]
    public NativeType(NativeSegType src)
    {
        Data = sys.@as<NativeSegType,ushort>(src);
    }

    public bool IsCellType
    {
        [MethodImpl(Inline)]
        get => (Data & 0xFF) == 0;
    }

    public bool IsSegmeted
    {
        [MethodImpl(Inline)]
        get => (Data & 0xFF) != 0;
    }

    public Scalar CellType
    {
        [MethodImpl(Inline)]
        get => sys.@as<NativeType,Scalar>(this);
    }

    public NativeClass Class
    {
        [MethodImpl(Inline)]
        get => CellType.Class;
    }

    public bool IsVoid
    {
        [MethodImpl(Inline)]
        get => CellType.IsVoid;
    }

    public NativeSize Size
    {
        [MethodImpl(Inline)]
        get => IsCellType ? AsCellType().Size : AsSegType().Size;
    }

    [MethodImpl(Inline)]
    public NativeSegType AsSegType()
        => sys.@as<NativeType,NativeSegType>(this);

    [MethodImpl(Inline)]
    public Scalar AsCellType()
        => sys.@as<NativeType,Scalar>(this);

    [MethodImpl(Inline)]
    public bool Equals(NativeType src)
        => Data == src.Data;

    public Hash32 Hash
    {
        get => Data;
    }
    
    [MethodImpl(Inline)]
    public override int GetHashCode()
        => Hash;

    public string Format()
        => format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    public static implicit operator NativeType(Scalar src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator NativeType(NativeSegType src)
        => new (src);

    [MethodImpl(Inline)]
    public static implicit operator NativeType(NativeSegKind src)
        => new (src);

    public static NativeType Void
    {
        [MethodImpl(Inline)]
        get => new NativeType(Scalar.Void);
    }
}
