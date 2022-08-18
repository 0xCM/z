//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Enums
    {
        public static Index<E> literals<E>()
            where E : unmanaged, Enum
        {
            var src = typeof(E);
            var fields = span(src.LiteralFields());
            var count = fields.Length;
            var buffer = alloc<E>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = (E)skip(fields,i).GetRawConstantValue();
            return buffer;
        }

        /// <summary>
        /// Returns an index of T-valued scalars labeled by the E-valued literals
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The refined primitive type</typeparam>
        public static Index<T> literals<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var src = typeof(E);
            var fields = span(src.LiteralFields());
            var count = fields.Length;
            var buffer = alloc<T>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = (T)skip(fields,i).GetRawConstantValue();
            return buffer;
        }
    }
}