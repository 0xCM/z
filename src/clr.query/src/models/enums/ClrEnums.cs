//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;
    using EK = ClrEnumKind;
    using F = EnumDatasetField;

    using static sys;

    public class ClrEnums
    {
        public static EnumLiteralInfo<E,T>[] literals<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var dataset = dataset<E,T>();
            return ClrEnums.literals<E,T>(dataset, new EnumLiteralInfo<E,T>[dataset.EntryCount]);
        }

        /// <summary>
        /// Creates an enumeration dataset predicated on supplied type parameters
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        public static EnumDataset<E,T> dataset<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = ClrEnums.details<E,T>();
            var count = src.Length;
            var token = EcmaTokens.token<E>();
            var datatype = ClrEnums.@base<E>();
            var description = string.Empty;
            var indices = alloc<uint>(count);
            var names = alloc<string>(count);
            var literals = alloc<E>(count);
            var numeric = alloc<T>(count);
            var descriptions = alloc<string>(count);
            var tokens = alloc<EcmaToken>(count);
            var dst = new EnumDataset<E,T>(token, description, datatype, tokens, indices,  names, literals, numeric, descriptions);
            for(var i=0; i<count; i++)
            {
                indices[i] = src[i].Position;
                names[i] = src[i].Name;
                literals[i] = src[i].LiteralValue;
                numeric[i] = src[i].PrimalValue;
                descriptions[i] = string.Empty;
                tokens[i] = src[i].Token;
            }

            return dst;
        }


        [MethodImpl(Inline)]
        public static string format<E,T>(in EnumDatasetEntry<E,T> src, char delimiter = FieldDelimiter)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var dst = text.buffer();
            dst.Delimit(F.Token, src.Token);
            dst.Delimit(F.Index, src.Index);
            dst.Delimit(F.Name, src.Name);
            dst.Delimit(F.Scalar, src.ScalarValue);
            return dst.ToString();
        }

        [MethodImpl(Inline)]
        public static string format<E,T>(in EnumLiteralInfo<E,T> src, char delimiter = FieldDelimiter)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var dst = text.buffer();
            dst.Delimit(F.Token, src.Token);
            dst.Delimit(F.Index, src.Position);
            dst.Delimit(F.Name, src.Name);
            dst.Delimit(F.Scalar, src.Scalar);
            return dst.ToString();
        }        
        
        /// <summary>
        /// Defines a useful representation of an enumeration literal
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The scalar type refined by the enum</typeparam>
        /// <typeparam name="A">The asci identifier type</typeparam>
        [MethodImpl(Inline)]
        public static EnumLiteralInfo<E,T> literal<E,T>(EcmaToken token, uint index, string name, E literal, T scalar)
            where E : unmanaged, Enum
            where T : unmanaged
                => new EnumLiteralInfo<E,T>(token, index, name, literal, scalar);

        public static EnumLiteralInfo<E,T>[] literals<E,T>(EnumDataset<E,T> dataset, EnumLiteralInfo<E,T>[] buffer)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var dst = span(buffer);
            var count = dst.Length;
            for(var i=0u; i<count; i++)
            {
                var entry = dataset[(int)i];
                seek(dst,i) = ClrEnums.literal(entry.Token, entry.Index, entry.Name, entry.EnumValue, entry.ScalarValue);
            }
            return buffer;
        }

        /// <summary>
        /// Constructs a arbitrarily deduplicated value-to-member index
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="V">The numeric value type</typeparam>
        public static IDictionary<V,E> dictionary<E,V>()
            where E : unmanaged, Enum
            where V : unmanaged
        {
            var pairs = details<E,V>();
            var index = new Dictionary<V,E>();
            foreach(var pair in pairs)
                index.TryAdd(pair.PrimalValue, pair.LiteralValue);
            return index;
        }        

        /// <summary>
        /// Determines the integral type refined by a parametrically-identified enum type
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        public static ClrEnumKind @base<E>()
            where E : unmanaged, Enum
                => @base(typeof(E).GetEnumUnderlyingType().NumericKind());

        /// <summary>
        /// Determines the integral type refined by a value-identified enum type
        /// </summary>
        /// <param name="value">The enum value</typeparam>
        [Op]
        public static ClrEnumKind @base(Enum value)
            => @base(value.GetType().GetEnumUnderlyingType().NumericKind());

        /// <summary>
        /// Determines the integral type refined by a specified enum type
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        [Op]
        public static ClrEnumKind @base(Type et)
            => @base(et.GetEnumUnderlyingType().NumericKind());

        [Op]
        public static ClrEnumKind @base(NumericKind src)
             => src switch{
                NK.U8 => EK.U8,
                NK.I8 => EK.I8,
                NK.U16 => EK.U16,
                NK.I16 => EK.I16,
                NK.U32 => EK.U32,
                NK.I32 => EK.I32,
                NK.I64 => EK.I64,
                NK.U64 => EK.U64,
                _ => ClrEnumKind.None,
            };

        public static EnumLiteralDetails<E> details<E>()
            where E : unmanaged, Enum
        {
            var type = @base<E>();
            var fields = @readonly(typeof(E).LiteralFields());
            var count = fields.Length;
            var buffer = sys.alloc<EnumLiteralDetail<E>>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(fields, i);
                seek(dst,i) = new EnumLiteralDetail<E>(field, type, i, field.Name, (E)field.GetRawConstantValue());
            }
            return buffer;
        }

        /// <summary>
        /// Reads a T-value from the value of an E-enum of primal T-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ref T scalar<E,T>(in E eVal, T tRep = default)
            where E : unmanaged
            where T : unmanaged
                => ref @as<E,T>(eVal);

        /// <summary>
        /// Gets the literals defined by an enumeration together with their integral values
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The value type</typeparam>
        public static EnumLiteralDetails<E,T> details<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = details<E>();
            var count = src.Length;
            var buffer = new EnumLiteralDetail<E,T>[count];
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref src[i];
                seek(dst,i) = strong(literal, scalar<E,T>(literal.LiteralValue));
            }
            return buffer;
        }

        /// <summary>
        /// Defines an E-V parametric enum value given an E-parametric literal an a value:V
        /// </summary>
        /// <param name="literal">The source literal</param>
        /// <param name="value">The source value</param>
        /// <typeparam name="E">The enum source type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        [MethodImpl(Inline)]
        static EnumLiteralDetail<E,V> strong<E,V>(EnumLiteralDetail<E> literal, V value)
            where E : unmanaged, Enum
            where V : unmanaged
                => new EnumLiteralDetail<E,V>(literal,value);
    }
}