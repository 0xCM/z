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
        /// Reads an E-value from an enum of primal T-kind
        /// </summary>
        /// <param name="scalar">The integral value</param>
        /// <param name="eRep">A representative enum value, used only for type inference</param>
        /// <typeparam name="E">The enum type</typeparam>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E,T>(in T scalar, E eRep = default)
            where E : unmanaged
            where T : unmanaged
                => ref @as<T,E>(scalar);

        /// <summary>
        /// Envisions a i8 value as a value of an enum of like i8 kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal u16-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in sbyte src)
            where E : unmanaged, Enum
                => ref literal<E,sbyte>(src);

        /// <summary>
        /// Envisions a u8 value as a value of an enum of like u8 kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal u16-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in byte src)
            where E : unmanaged, Enum
                => ref literal<E,byte>(src);

        /// <summary>
        /// Envisions a u16 value as a value of an enum of like u16 kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal u16-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in ushort src)
            where E : unmanaged, Enum
                => ref literal<E,ushort>(src);

        /// <summary>
        /// Envisions a c16 value as a value of an enum of like u16 kind
        /// </summary>
        /// <param name="tVal">The source value</param>
        /// <typeparam name="E">The enum target type of primal u16-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in char src)
            where E : unmanaged, Enum
                 => ref literal<E,char>(src);

        /// <summary>
        /// Envisions an i32 value as a value of an enum of like primal kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal i32-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in int src)
            where E : unmanaged, Enum
                => ref literal<E,int>(src);

        /// <summary>
        /// Envisions a u32 value as a value of an enum of like primal kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal u32-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in uint src)
            where E : unmanaged, Enum
                => ref literal<E,uint>(src);

        /// <summary>
        /// Envisions an i64 value as a value of an enum of like primal kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal i64-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in long src)
            where E : unmanaged, Enum
                => ref literal<E,long>(src);

        /// <summary>
        /// Envisions a u64 value as a value of an enum of like primal kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="E">The enum target type of primal u64-kind</typeparam>
        [MethodImpl(Inline)]
        public static ref E literal<E>(in ulong src)
            where E : unmanaged, Enum
                => ref literal<E,ulong>(src);
    }
}