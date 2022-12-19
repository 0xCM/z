//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrTypes
    {
        /// <summary>
        /// Returns a canonical non-null empty value
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline)]
        public static T empty<T>()
        {
            if(typeof(T) == typeof(string))
                return sys.generic<T>(EmptyString);
            else if(typeof(T) == typeof(Type))
                return sys.generic<T>(typeof(void));
            else
                return default;
        }

        public readonly struct Integers : IRuntimeTypeProvider
        {
            public Type[] Types => IntegerTypes;
        }

        public readonly struct Unsigned : IRuntimeTypeProvider
        {
            public Type[] Types => UnsignedTypes;
        }


        public readonly struct Signed : IRuntimeTypeProvider
        {
            public Type[] Types => SignedTypes;
        }

        static Index<Type> IntegerTypes = NumericKinds.IntegerTypes();

        static Index<Type> UnsignedTypes = NumericKinds.UnsignedTypes();

        static Index<Type> SignedTypes = NumericKinds.SignedTypes();
    }
}