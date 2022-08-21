//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;
    using TC = System.TypeCode;

    partial class NumericKinds
    {
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static TypeCode typecode<T>()
            => tc_u<T>();

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static (NK, Type) find<T>()
            => where_u<T>();

        [MethodImpl(Inline)]
        static TC tc_u<T>()
        {
            if(typeof(T) == typeof(byte))
                return TC.Byte;
            else if(typeof(T) == typeof(ushort))
                return TC.UInt16;
            else if(typeof(T) == typeof(uint))
                return TC.UInt32;
            else if(typeof(T) == typeof(ulong))
                return TC.UInt64;
            else
                return tc_i<T>();
        }

        [MethodImpl(Inline)]
        static TC tc_i<T>()
        {
            if(typeof(T) == typeof(sbyte))
                return TC.SByte;
            else if(typeof(T) == typeof(short))
                return TC.Int16;
            else if(typeof(T) == typeof(int))
                return TC.Int32;
            else if(typeof(T) == typeof(long))
                return TC.Int64;
            else
                return tc_x<T>();
        }

        [MethodImpl(Inline)]
        static TC tc_x<T>()
        {
            if(typeof(T) == typeof(float))
                return TC.Single;
            else if(typeof(T) == typeof(double))
                return TC.Double;
            else if(typeof(T) == typeof(decimal))
                return TC.Decimal;
            else if(typeof(T) == typeof(char))
                return TC.Char;
            else if(typeof(T) == typeof(bool))
                return TC.Boolean;
            else
                return TC.Object;
        }

        [MethodImpl(Inline)]
        static unsafe (NK,Type) where_u<T>()
        {
            if(typeof(T) == typeof(byte))
                return (NK.U8,typeof(byte));
            else if(typeof(T) == typeof(ushort))
                return (NK.U16,typeof(ushort));
            else if(typeof(T) == typeof(uint))
                return (NK.U32,typeof(uint));
            else if(typeof(T) == typeof(ulong))
                return (NK.U64,typeof(ulong));
            else
                return where_i<T>();
        }

        [MethodImpl(Inline)]
        static unsafe (NK,Type) where_i<T>()
        {
            if(typeof(T) == typeof(sbyte))
                return (NK.I8,typeof(sbyte));
            else if(typeof(T) == typeof(short))
                return (NK.I16,typeof(short));
            else if(typeof(T) == typeof(int))
                return (NK.I32,typeof(int));
            else if(typeof(T) == typeof(long))
                return (NK.I64,typeof(long));
            else
                return (NK.None,typeof(byte));
        }
    }
}