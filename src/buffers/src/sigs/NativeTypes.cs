//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static NativeKind;

[ApiHost]
public partial class NativeTypes
{
    public static Union union(Label name, TypeSeq members)
        => new (name, members);

    public readonly struct Union
    {
        readonly TypeSeq Data;

        public readonly Label Name;

        [MethodImpl(Inline)]
        public Union(Label name, TypeSeq src)
        {
            Name = name;
            Data = src;
        }

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }
    }

    public readonly struct TypeSeq : IEnumerable<NativeType>
    {
        readonly ByteBlock32 Storage;

        static N16 N => default;

        public byte MaxCount
        {
            [MethodImpl(Inline)]
            get => (byte)N.NatValue;
        }

        public byte Count
        {
            [MethodImpl(Inline)]
            get => NativeSigs.nonempty(this);
        }

        public Span<NativeType> Edit
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<NativeType>(sys.bytes(this));
        }

        public ReadOnlySpan<NativeType> View
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<NativeType>(sys.bytes(this));
        }

        public ref NativeType this[uint i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Edit,i);
        }

        public ref NativeType this[int i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Edit,i);
        }

        public IEnumerator<NativeType> GetEnumerator()
            => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotImplementedException();
    }

    [MethodImpl(Inline), Op]
    public static NativeType seg(NativeSegKind kind)
        => new (kind);

    public static DataSize measure(Type src)
    {
        var dst = DataSize.Empty;
        var width = bitsize(src);
        var tag = src.Tag<DataWidthAttribute>();
        if(src.IsEnum)
        {
            width = Sizes.bits(PrimalBits.width(Enums.@base(src)));
            if(tag)
                dst = new (tag.Value.PackedWidth, width);
            else
                dst = (width, width);
        }
        else
        {
            if(tag)
                dst = new (tag.Value.PackedWidth, width);
            else
                dst = (width,width);
        }
        return dst;
    }

    static uint bitsize(Type src)
    {
        if(src is null || src == typeof(void) || src == typeof(Null))
            return 0;
        try
        {
            var type = typeof(SizeCalc<>).MakeGenericType(src);
            var method = first(type.StaticMethods().Public());
            return ((uint)method.Invoke(null, sys.empty<object>()))*8;
        }
        catch(Exception)
        {
            return 0;
        }
    }

    readonly struct SizeCalc<T>
    {
        [MethodImpl(Inline)]
        public static uint calc()
            => (uint)Unsafe.SizeOf<T>();
    }

    [MethodImpl(Inline), Op]
    public static LiteralType literal(Label name, PrimalType @base, DataSize size)
        => new (name, @base, size);

    [MethodImpl(Inline), Op]
    public static LiteralType literal(Label name, PrimalType @base, byte size)
        => new (name, @base, (size,size));

    [MethodImpl(Inline)]
    public static LiteralValue<T> literal<T>(LiteralType type, T value)
        where T : unmanaged
            => new(type,value);

    [MethodImpl(Inline), Op]
    public static TypedLiteral typed(Label name, TypeKey @base, DataSize size)
        => new (name, @base, size);

    [MethodImpl(Inline), Op]
    public static TypedLiteral typed(Label name, LiteralType @base, DataSize size)
        => typed(name, @base, size);

    [MethodImpl(Inline), Op]
    public static NumericType numeric(Label name, DataSize size)
        => new (name, size);

    [MethodImpl(Inline), Op]
    public static NumericType numeric(Label name, byte width)
        => new (name, width);

    public static TypeKey NextKey(DataTypeKind kind)
    {
        lock(KeyLocker)
        {
            ref var key = ref _TypeKeys[kind];
            key++;
            return key;
        }
    }

    public static LiteralType literal(TypeKey key, Type type)
    {
        var @base = primal(type);
        var name = type.DisplayName();
        Require.invariant(name.Length <= 32);
        var tag = type.Tag<WidthAttribute>();
        var width = (byte)Sizes.bits(type);
        var packed = width;
        if(tag)
            packed = (byte)((NativeSize)tag.Require().TypeWidth).Width;
        return literal(name, @base, new DataSize(packed, @base.Size.NativeWidth));
    }

    public static PrimalType type(NativeKind kind)
        => kind switch  {
            U8 =>PrimalType.U8, 
            I8 =>PrimalType.I8, 
            I16 =>PrimalType.I16, 
            U16 =>PrimalType.U16, 
            I32 =>PrimalType.I32, 
            U32 =>PrimalType.U32, 
            I64 =>PrimalType.I64, 
            U64 =>PrimalType.U64, 
            F32 =>PrimalType.F32, 
            F64 =>PrimalType.F64, 
            Void => PrimalType.Void, 
            _ => PrimalType.Empty
        };

    public static LiteralType[] literals(params Type[] src)
    {
        var count = src.Length;
        var dst = sys.alloc<LiteralType>(count);
        for(var i=0; i<count; i++)
            seek(dst,i) = literal(NextKey(DataTypeKind.Literal), skip(src,i));
        return dst;
    }

    public static PrimalType primal(Type src)
    {
        if(src == typeof(bit))
            return PrimalType.U1;
        else if(src == typeof(void))
            return PrimalType.Void;
        else if(src.IsPrimalNumeric())
            return type(primitive(src.NumericKind()));
        else if(src.IsEnum)
            return type(primitive(src.EnumScalarKind()));
        else if(src == typeof(Null))
            return PrimalType.Empty;
        else
            Errors.Throw($"{src.Name} is not primitive");
        return PrimalType.Empty;
    }

    public static NativeKind primitive(ClrEnumKind scalar)
    {
        var @base = None;
        switch(scalar)
        {
            case ClrEnumKind.I8:
                @base = I8;
                break;
            case ClrEnumKind.U8:
                @base = U8;
            break;
            case ClrEnumKind.I16:
                @base = I16;
            break;
            case ClrEnumKind.U16:
                @base = U16;
            break;
            case ClrEnumKind.I32:
                @base = I32;
            break;
            case ClrEnumKind.U32:
                @base = U32;
            break;
            case ClrEnumKind.I64:
                @base = I64;
            break;
            case ClrEnumKind.U64:
                @base = U64;
            break;
        }
        return @base;
    }

    public static NativeKind primitive(NumericKind src)
        => src switch{
            NumericKind.U8 => U8,
            NumericKind.U16 => U16,
            NumericKind.U32 => U32,
            NumericKind.U64 => U64,
            NumericKind.I8 => I8,
            NumericKind.I16 => I16,
            NumericKind.I32 => I32,
            NumericKind.I64 => I64,
            NumericKind.F32 => F32,
            NumericKind.F64 => F64,
            _ => NativeKind.None
        };

    static object KeyLocker = new();

    static NativeTypes()
    {
        init(out _TypeKeys);
    }

    static Index<DataTypeKind,TypeKey> _TypeKeys;

    static void init(out Index<DataTypeKind,TypeKey> dst)
    {
        var kinds = Symbols.index<DataTypeKind>();
        dst = sys.alloc<TypeKey>(kinds.Count);
        for(var i=0; i<kinds.Count; i++)
            dst[kinds[i].Kind] = TypeKey.Empty;
    }
}
