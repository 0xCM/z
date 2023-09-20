//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(StructLayout,Pack=1)]
public readonly record struct PrimalType : IDataType<PrimalType>
{
    const byte W0 = 0;

    const byte W1 = 8;

    const byte W8 = 8;

    const byte W16 = 16;

    const byte W32 = 32;

    const byte W64 = 64;

    public static PrimalType Empty => new(NativeKind.None, EmptyString, (W0,W0));

    public static PrimalType U1 => new(NativeKind.U1, "bit", (W1,W8));

    public static PrimalType U8 => new(NativeKind.U8, "byte", (W8,W8));

    public static PrimalType I8 => new(NativeKind.I8, "sbyte", (W8,W8));

    public static PrimalType I16 => new(NativeKind.I16, "short", (W16,W16));

    public static PrimalType U16 => new(NativeKind.U16, "ushort", (W16,W16));

    public static PrimalType I32 => new(NativeKind.I32, "int", (W32,W32));

    public static PrimalType U32 => new(NativeKind.U32, "uint", (W32,W32));

    public static PrimalType I64 => new(NativeKind.I64, "long", (W64,W64));

    public static PrimalType U64 => new(NativeKind.U64, "ulong", (W64,W64));

    public static PrimalType F32 => new(NativeKind.F32, "float", (W32,W32));

    public static PrimalType F64 => new(NativeKind.F64, "double", (W64,W64));

    public static PrimalType Void => new(NativeKind.Void, "void", (W0,W0));

    public readonly NativeKind PrimalKind;

    public readonly Label TypeName;

    public readonly DataSize Size;

    [MethodImpl(Inline)]
    public PrimalType(NativeKind kind, Label name, DataSize size)
    {
        PrimalKind = kind;
        TypeName = name;
        Size = size;
    }

    public TypeKey Key
    {
        [MethodImpl(Inline)]
        get => (byte)PrimalKind;
    }

    public string Format()
        => TypeName.Format();

    public override string ToString()
        => Format();

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => PrimalKind == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => PrimalKind != 0;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Key.Hash;
    }

    public int CompareTo(PrimalType src)
        => TypeName.CompareTo(src.TypeName);

    public const NativeKind LastKind = NativeKind.Void;
}
