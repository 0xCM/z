//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Enums
    {
        /// <summary>
        /// Defines a useful representation of an enumeration literal
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The scalar type refined by the enum</typeparam>
        /// <typeparam name="A">The asci identifier type</typeparam>
        [MethodImpl(Inline)]
        public static EnumLiteralInfo<E,T> describe<E,T>(CliToken token, uint index, NameOld name, E literal, T scalar)
            where E : unmanaged, Enum
            where T : unmanaged
                => new EnumLiteralInfo<E,T>(token, index, name, literal, scalar);

        public static EnumLiteralInfo<E,T>[] describe<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var dataset = EnumDatasets.create<E,T>();
            return describe<E,T>(dataset, new EnumLiteralInfo<E,T>[dataset.EntryCount]);
        }

        public static EnumLiteralInfo<E,T>[] describe<E,T>(EnumDataset<E,T> dataset, EnumLiteralInfo<E,T>[] buffer)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var dst = span(buffer);
            var count = dst.Length;
            for(var i=0u; i<count; i++)
            {
                var entry = dataset[(int)i];
                seek(dst,i) = describe(entry.Token, entry.Index, entry.Name, entry.EnumValue, entry.ScalarValue);
            }
            return buffer;
        }
    }
}