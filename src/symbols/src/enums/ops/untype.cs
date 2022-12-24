//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using NK = NumericKind;

    partial struct Enums
    {
        const NumericKind Closure = Integers;

        public static ulong untyped<E>(E src)
            where E : unmanaged, Enum
                => typeof(E).GetEnumUnderlyingType().NumericKind() switch {
                    NK.U8 => (ulong)e8u(src),
                    NK.I8 => (ulong)e8i(src),
                    NK.U16 => (ulong)e16u(src),
                    NK.I16 => (ulong)e16i(src),
                    NK.U32 => (ulong)e32u(src),
                    NK.I32 => (ulong)e32i(src),
                    NK.I64 => (ulong)e64i(src),
                    NK.U64 => e64u(src),
                    _ => 0ul,
                };

        /// <summary>
        /// Reads a T-value from the value of an E-enum of primal T-kind
        /// </summary>
        /// <param name="eVal">The enum value</param>
        /// <param name="tVal">The primal output value</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ref T scalar<E,T>(in E eVal, T tRep = default)
            where E : unmanaged
            where T : unmanaged
                => ref @as<E,T>(eVal);

        /// <summary>
        /// Envisions an E-enum value of primal i8-kind as a like-kinded scalar value
        /// </summary>
        /// <param name="eVal">The enum source value</param>
        /// <typeparam name="E">The enum type of primal i8-kind</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte e8i<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,sbyte>(eVal);

        /// <summary>
        /// Envisions an E-enum value of primal u8-kind as a like-kinded scalar value
        /// </summary>
        /// <param name="eVal">The enum source value</param>
        /// <typeparam name="E">The enum type of primal u8-kind</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte e8u<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,byte>(eVal);

        /// <summary>
        /// Envisions an E-enum value of primal i16-kind as a like-kinded scalar value
        /// </summary>
        /// <param name="eVal">The enum source value</param>
        /// <typeparam name="E">The enum type of primal i16-kind</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short e16i<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,short>(eVal);

        /// <summary>
        /// Envisions an E-enum value of primal u16-kind as a like-kinded scalar value
        /// </summary>
        /// <param name="eVal">The enum source value</param>
        /// <typeparam name="E">The enum type of primal u16-kind</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort e16u<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,ushort>(eVal);

        /// <summary>
        /// Envisions an E-enum value of primal u16-kind as a c16 value
        /// </summary>
        /// <param name="eVal">The enum source value</param>
        /// <typeparam name="E">The enum type of primal u16-kind</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref char e16c<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,char>(eVal);

        /// <summary>
        /// Interprets an enum value as a signed 32-bit integer
        /// </summary>
        /// <param name="e">The enum value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int e32i<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,int>(eVal);

        /// <summary>
        /// Interprets an enum value as an unsigned 32-bit integer
        /// </summary>
        /// <param name="e">The enum value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint e32u<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,uint>(eVal);

        /// <summary>
        /// Interprets an enum value as a signed 64-bit integer
        /// </summary>
        /// <param name="e">The enum value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long e64i<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,long>(eVal);

        /// <summary>
        /// Interprets an enum value as an unsigned 64-bit integer
        /// </summary>
        /// <param name="e">The enum value</param>
        /// <typeparam name="E">The enum type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong e64u<E>(in E eVal)
            where E : unmanaged
                => ref scalar<E,ulong>(eVal);
    }
}