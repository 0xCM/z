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
        public static PrimalType primitive(NativeKind kind, Label name, AlignedWidth width)
            => new (kind, name,width);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, Label name, PrimalType @base, DataSize size)
            => new (key, name, @base, size);

        [MethodImpl(Inline), Op]
        public static LiteralType literal(TypeKey key, Label name, PrimalType @base, byte size)
            => new (key, name, @base, (size,size));

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(TypeKey type, T value)
            where T : unmanaged
                => new LiteralValue<T>(type, value);

        [MethodImpl(Inline)]
        public static LiteralValue literal<T>(LiteralType type, T value)
            where T : unmanaged
                => literal(type.Key,value);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(Label name, TypeKey @base, DataSize size)
            => new (name, @base, size);

        [MethodImpl(Inline), Op]
        public static TypedLiteral typed(Label name, LiteralType @base, DataSize size)
            => typed(name, @base.Key, size);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, Label name, DataSize size)
            => new (key, name, size);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(TypeKey key, Label name, byte width)
            => new (key, name, width);

        [MethodImpl(Inline), Op]
        public static NumericType numeric(PrimalType key, Label name, NumWidth width)
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

        public static PrimalType type(NativeKind kind)
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
                return type(primitive(src.NumericKind()));
            else if(src.IsEnum)
                return type(primitive(src.EnumScalarKind()));
            else if(src == typeof(Null))
                return PrimalType.Intrinsic.Empty;
            else
                Errors.Throw($"{src.Name} is not primitive");
            return PrimalType.Intrinsic.Empty;
        }

        public static NativeKind primitive(ClrEnumKind scalar)
        {
            var @base = NativeKind.None;
            switch(scalar)
            {
                case ClrEnumKind.I8:
                case ClrEnumKind.U8:
                    @base = NativeKind.U8;
                break;
                case ClrEnumKind.I16:
                case ClrEnumKind.U16:
                    @base = NativeKind.U16;
                break;
                case ClrEnumKind.I32:
                case ClrEnumKind.U32:
                    @base = NativeKind.U32;
                break;
                case ClrEnumKind.I64:
                case ClrEnumKind.U64:
                    @base = NativeKind.U64;
                break;
            }
            return @base;
        }

        public static NativeKind primitive(NumericKind src)
            => src switch{
                NumericKind.U8 => NativeKind.U8,
                NumericKind.U16 => NativeKind.U16,
                NumericKind.U32 => NativeKind.U32,
                NumericKind.U64 => NativeKind.U64,
                NumericKind.I8 => NativeKind.U8,
                NumericKind.I16 => NativeKind.U16,
                NumericKind.I32 => NativeKind.U32,
                NumericKind.I64 => NativeKind.U64,
                _ => NativeKind.None
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