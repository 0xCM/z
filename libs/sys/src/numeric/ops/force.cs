//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    using static sys;

    public partial struct Numeric
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Presents a parametric reference as a <see cref='char'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref char c16<T>(in T src)
            => ref @as<T,char>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        static float float32<T>(T src)
            => As<T,float>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static sbyte int8<T>(T src)
            => As<T,sbyte>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static sbyte? int8<T>(T? src)
            where T : unmanaged
                => As<T?,sbyte?>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static double float64<T>(T src)
            => As<T,double>(ref src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref decimal float128<T>(in T src)
            => ref As<T,decimal>(ref sys.edit(src));

        /// <summary>
        /// Unconditionally converts the source values to values of parametric numeric type
        /// </summary>
        /// <param name="src">The source values</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline)]
        public static T[] force<S,T>(S[] src, T[] dst)
            where T : unmanaged
            where S : unmanaged
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst,(uint)i) = force<S,T>(skip(src,(uint)i));
            return dst;
        }

        /// <summary>
        /// Unconditionally converts the source values to values of parametric numeric type
        /// </summary>
        /// <param name="src">The source values</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline)]
        public static T[] force<S,T>(S[] src)
            where T : unmanaged
            where S : unmanaged
        {
            var dst = alloc<T>(src.Length);
            for(var i=0; i<src.Length; i++)
                seek(dst,(uint)i) = force<S,T>(skip(src,(uint)i));
            return dst;
        }

        /// <summary>
        /// Unconditionally converts the source value to a value of parametric numeric type
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(sbyte src)
            => convert8i_u<T>(src);

        /// <summary>
        /// Unconditionally converts the source value to a value of parametric numeric type
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(byte src)
            => convert8u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion ushort -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(ushort src)
            => convert16u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion short -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(short src)
            => convert16i_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion int -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(int src)
            => convert32i_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion uint -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(uint src)
            => convert32u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion long -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(long src)
            => convert64i_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion ulong -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(ulong src)
            => convert64u_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion float -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(float src)
            => convert32f_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion double -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(double src)
            => convert64f_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion char -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T force<T>(char src)
            => convert16c_u<T>(src);

        /// <summary>
        /// If possible, applies the conversion S -> T
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T force<S,T>(S src)
            => force_u<S,T>(src);

        [MethodImpl(Inline)]
        static T force_u<S,T>(S src)
        {
            if(typeof(S) == typeof(byte))
                return force<T>(sys.uint8(src));
            else if(typeof(S) == typeof(ushort))
                return force<T>(sys.uint16(src));
            else if(typeof(S) == typeof(uint))
                return force<T>(sys.uint32(src));
            else if(typeof(S) == typeof(ulong))
                return force<T>(sys.uint64(src));
            else
                return force_i<S,T>(src);
        }

        [MethodImpl(Inline)]
        static T force_i<S,T>(S src)
        {
            if(typeof(S) == typeof(sbyte))
                return force<T>(int8(src));
            else if(typeof(S) == typeof(short))
                return force<T>(sys.int16(src));
            else if(typeof(S) == typeof(int))
                return force<T>(sys.int32(src));
            else if(typeof(S) == typeof(long))
                return force<T>(sys.int64(src));
            else
                return force_x<S,T>(src);
        }

        [MethodImpl(Inline)]
        static T force_x<S,T>(S src)
        {
            if(typeof(S) == typeof(float))
                return force<T>(float32(src));
            else if(typeof(S) == typeof(double))
                return force<T>(float64(src));
            else if(typeof(S) == typeof(char))
                return force<T>(c16(src));
            else
                return no<S,T>();
        }
    }
}