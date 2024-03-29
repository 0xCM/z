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
        /// Presents a kinded value as a scalar value
        /// </summary>
        /// <param name="kind">The kind value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline)]
        public static unsafe T scalar<E,T>(E kind)
            where E : unmanaged, Enum, IEquatable<E>
            where T : unmanaged, IEquatable<T>
                => Unsafe.Read<T>((T*)(&kind));

        /// <summary>
        /// Reads a T-value from an E-enum value of primal T-kind.
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static T scalar<E,T>(in E eVal, out T tVal)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            tVal = @as<E,T>(eVal);
            return tVal;
        }

        /// <summary>
        /// Reads a u8-value from an enum of primal u8-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static byte scalar<E>(in E eVal, out byte tVal)
            where E : unmanaged, Enum
                => store(eVal, out tVal);

        /// <summary>
        /// Reads an i16-value from an enum of primal i16-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static short scalar<E>(in E eVal, out short tVal)
            where E : unmanaged, Enum
                => store(eVal, out tVal);

        /// <summary>
        /// Reads a u16-value from an enum of primal u16-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static ushort scalar<E>(in E eVal, out ushort tVal)
            where E : unmanaged, Enum
                => store(eVal, out tVal);

        /// <summary>
        /// Reads an i32-value from an enum of primal i32-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static int scalar<E>(in E eVal, out int tVal)
            where E : unmanaged, Enum
                => store(eVal, out tVal);

        /// <summary>
        /// Reads a u32-value from an enum of primal u32-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static uint scalar<E>(in E eVal, out uint tVal)
            where E : unmanaged, Enum
                => store(eVal, out tVal);

        /// <summary>
        /// Reads an i8-value from an enum of primal u8-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static sbyte scalar<E>(in E eVal, out sbyte tVal)
            where E : unmanaged, Enum
                => store(eVal, out tVal);

        /// <summary>
        /// Reads an i64-value from an enum of primal i64-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static long scalar<E>(in E eVal, out long tVal)
            where E : unmanaged, Enum
                => deposit(eVal, out tVal);

        /// <summary>
        /// Reads a u64-value from an enum of primal u64-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static ulong scalar<E>(in E eVal, out ulong tVal)
            where E : unmanaged, Enum
                => deposit(eVal, out tVal);

        /// <summary>
        /// Reads a c16-value from an enum of primal u16-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="cVal">The character output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline)]
        public static char scalar<E>(in E eVal, out char cVal)
            where E : unmanaged, Enum
        {
            cVal = (char)scalar(eVal, out ushort _);
            return cVal;
        }
    }
}