//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using F = EnumDatasetField;

    public readonly struct EnumDatasets
    {
        /// <summary>
        /// Creates an enumeration dataset predicated on supplied type parameters
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        public static EnumDataset<E,T> create<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = Enums.details<E,T>();
            var count = src.Length;
            var token = Clr.token<E>();
            var datatype = Enums.@base<E>();
            var description = string.Empty;
            var indices = alloc<uint>(count);
            var names = alloc<string>(count);
            var literals = alloc<E>(count);
            var numeric = alloc<T>(count);
            var descriptions = alloc<string>(count);
            var tokens = alloc<CliToken>(count);
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

        public static string header<F>(char delimiter = FieldDelimiter)
            where F : unmanaged, Enum
        {
            var dst = text.buffer();
            var labels = Enums.literals<F>();
            for(var i=0; i<labels.Length; i++)
                dst.Delimit(labels[i], labels[i].ToString(), delimiter);
            return dst.ToString();
        }

        public static string header(Type src, char delimiter = FieldDelimiter)
        {
            var dst = text.buffer();
            var labels = Enums.literals<F>();
            for(var i=0; i<labels.Length; i++)
                dst.Delimit(labels[i], labels[i].ToString(), delimiter);
            return dst.ToString();
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
    }
}