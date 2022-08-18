//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Enums
    {
        /// <summary>
        /// Determines an enumeration's underlying kind
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static ClrEnumCode ecode<E>()
            where E : unmanaged, Enum
                => (ClrEnumCode)default(E).GetTypeCode();

        /// <summary>
        /// Determines an enumeration's underlying kind
        /// </summary>
        [MethodImpl(Inline), Op]
        public static ClrEnumCode ecode(Type src)
            => (ClrEnumCode)sys.typecode(src);
    }
}