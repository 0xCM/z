//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct emath
    {
        /// <summary>
        /// Determines whether an integral scalar value is equal to one of two enum values
        /// </summary>
        /// <param name="s">The scalar value</param>
        /// <param name="e0">The first enum value</param>
        /// <param name="e1">The second enum value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static bit oneof<E,T>(T s, E e0, E e1)
            where E : unmanaged
            where T : unmanaged
                => same(e0, s) || same(e1, s);

        [MethodImpl(Inline)]
        public static bit oneof<E,T>(T s, ReadOnlySpan<E> src)
            where E : unmanaged
            where T : unmanaged
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(same(skip(src,i), s))
                    return true;
            return false;
        }

        [MethodImpl(Inline)]
        public static bit oneof<E,T>(T s, params E[] src)
            where E : unmanaged
            where T : unmanaged
                => oneof(s, @readonly(src));
    }
}