//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Enums
    {
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