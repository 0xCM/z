//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrTypes
    {
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