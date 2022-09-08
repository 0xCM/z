//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class DataTypes
    {
        [MethodImpl(Inline), Op]
        public static PrimalType primitive(_PrimalKind kind, asci64 name, AlignedWidth width)
            => new PrimalType(kind, name,width);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, asci64 name, PrimalType @base, DataSize size)
            => new LiteralType(key, name, @base, size);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, asci64 name, PrimalType @base, byte size)
            => new LiteralType(key, name, @base, (size,size));

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(TypeKey type, T value)
            where T : unmanaged
                => new LiteralValue<T>(type, value);

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(LiteralType type, T value)
            where T : unmanaged
                => literal(type.Key,value);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci64 name, TypeKey @base, DataSize size)
            => new TypedLiteral(name, @base, size);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(asci64 name, LiteralType @base, DataSize size)
            => typed(name, @base.Key, size);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, asci64 name, DataSize size)
            => new NumericType(key, name, size);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, asci64 name, byte width)
            => new NumericType(key, name, width);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(PrimalType key, asci64 name, NumWidth width)
            => numeric(key, name, width);

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
            return literal(key, name, @base, new DataSize(packed, @base.Size.NativeWidth));
        }

        public static PrimalType type(_PrimalKind kind)
            => PrimalType.type(kind);

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
                return PrimalType.Intrinsic.U1;
            else if(src == typeof(void))
                return PrimalType.Intrinsic.Void;
            else if(src.IsPrimalNumeric())
                return type(DataTypes.primitive(src.NumericKind()));
            else if(src.IsEnum)
                return type(DataTypes.primitive(src.EnumScalarKind()));
            else if(src == typeof(Null))
                return PrimalType.Intrinsic.Empty;
            else
                Errors.Throw($"{src.Name} is not primitive");
            return PrimalType.Intrinsic.Empty;
        }

        public static _PrimalKind primitive(ClrEnumKind scalar)
        {
            var @base = _PrimalKind.None;
            switch(scalar)
            {
                case ClrEnumKind.I8:
                case ClrEnumKind.U8:
                    @base = _PrimalKind.U8;
                break;
                case ClrEnumKind.I16:
                case ClrEnumKind.U16:
                    @base = _PrimalKind.U16;
                break;
                case ClrEnumKind.I32:
                case ClrEnumKind.U32:
                    @base = _PrimalKind.U32;
                break;
                case ClrEnumKind.I64:
                case ClrEnumKind.U64:
                    @base = _PrimalKind.U64;
                break;
            }
            return @base;
        }

        public static _PrimalKind primitive(NumericKind src)
            => src switch{
                NumericKind.U8 => _PrimalKind.U8,
                NumericKind.U16 => _PrimalKind.U16,
                NumericKind.U32 => _PrimalKind.U32,
                NumericKind.U64 => _PrimalKind.U64,
                NumericKind.I8 => _PrimalKind.U8,
                NumericKind.I16 => _PrimalKind.U16,
                NumericKind.I32 => _PrimalKind.U32,
                NumericKind.I64 => _PrimalKind.U64,
                _ => _PrimalKind.None
            };

        static object KeyLocker = new();

        static DataTypes()
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
}