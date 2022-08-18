//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using api = Enums;

    partial class XTend
    {
        [MethodImpl(Inline)]
        public static bool IsDefined<E>(this E e)
            where E : unmanaged, Enum
                => Enum.IsDefined(typeof(E), e);

        [MethodImpl(Inline)]
        public static bool IsSome<E>(this E src)
            where E : unmanaged, Enum
                => !default(E).Equals(src);

        /// <summary>
        /// Filters zero-valued elements from the source stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="E">The enumeration type</typeparam>
        public static IEnumerable<E> WhereSome<E>(this IEnumerable<E> src)
            where E : unmanaged, Enum
                => src.Where(x => x.IsSome());

        /// <summary>
        /// Filters zero-valued elements from the source array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="E">The enumeration type</typeparam>
        public static E[] WhereSome<E>(this E[] src)
            where E : unmanaged, Enum
                => src.Where(x => x.IsSome()).ToArray();

        [MethodImpl(Inline)]
        public static bool IsNone<E>(this E src)
            where E : unmanaged, Enum
                => default(E).Equals(src);

        [MethodImpl(Inline)]
        public static T MapSomeOrElse<E,T>(this E kind, Func<E,T> ifSome, Func<T> ifNone)
            where E : unmanaged, Enum
                => kind.IsSome() ? ifSome(kind) : ifNone();

        [MethodImpl(Inline)]
        public static T NumericValue<E,T>(this E src, T dst = default)
            where E : unmanaged, Enum
            where T : unmanaged
                => api.scalar<E,T>(src);

        [MethodImpl(Inline)]
        public static sbyte ToInt8<E>(this E src)
            where E : unmanaged, Enum
                => api.e8i(src);

        [MethodImpl(Inline)]
        public static byte ToUInt8<E>(this E src)
            where E : unmanaged, Enum
                => api.e8u(src);

        [MethodImpl(Inline)]
        public static short ToInt16<E>(this E src)
            where E : unmanaged, Enum
                => api.e16i(src);

        [MethodImpl(Inline)]
        public static ushort ToUInt16<E>(this E src)
            where E : unmanaged, Enum
                => api.e16u(src);

        [MethodImpl(Inline)]
        public static int ToInt32<E>(this E src)
            where E : unmanaged, Enum
                => api.e32i(src);

        [MethodImpl(Inline)]
        public static uint ToUInt32<E>(this E src)
            where E : unmanaged, Enum
                => api.e32u(src);

        [MethodImpl(Inline)]
        public static long ToInt64<E>(this E src)
            where E : unmanaged, Enum
                => api.e64i(src);

        [MethodImpl(Inline)]
        public static ulong ToUInt64<E>(this E src)
            where E : unmanaged, Enum
                => api.e64u(src);

        [MethodImpl(Inline)]
        public static ClrEnumKind EnumScalarKind(this Type src)
            => api.@base(src);
    }
}