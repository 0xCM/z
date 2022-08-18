//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        /// <summary>
        /// Determines whether an enum defines a name-identified literal
        /// </summary>
        /// <param name="name">The test name</param>
        /// <typeparam name="E">The enum source type</typeparam>
        [MethodImpl(Inline)]
        public static bool defined<E>(string name)
            where E : unmanaged, Enum
                => Enum.IsDefined(typeof(E), name);

        /// <summary>
        /// Determines whether an enum value is valid
        /// </summary>
        /// <param name="v">The test value</param>
        /// <typeparam name="E">The enum source type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        [MethodImpl(Inline)]
        public static bool defined<E>(E e)
            where E : unmanaged, Enum
                => Enum.IsDefined(typeof(E), e);

        /// <summary>
        /// Determines whether an enum has a specified integral value
        /// </summary>
        /// <param name="v">The test value</param>
        /// <typeparam name="E">The enum source type</typeparam>
        /// <typeparam name="V">The value type</typeparam>
        [MethodImpl(Inline)]
        public static bool defined<E,V>(V v)
            where E : unmanaged, Enum
            where V : unmanaged
                => Enum.IsDefined(typeof(E), v);
    }
}