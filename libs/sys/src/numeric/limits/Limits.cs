//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines literals that specify numeric type limits
    /// </summary>
    [ApiHost]
    public readonly struct Limits
    {
        /// <summary>
        /// Returns the maximim value supported by a parametrically-identified primal type
        /// </summary>
        /// <typeparam name="T">The primal source type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T maxval<T>(T t = default)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return maxval_i<T>();
            else if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return maxval_u<T>();
            else
                return maxval_f<T>();
        }

        [MethodImpl(Inline)]
        static T maxval_i<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return Numeric.force<T>(sbyte.MaxValue);
            else if(typeof(T) == typeof(short))
                return Numeric.force<T>(short.MaxValue);
            else if(typeof(T) == typeof(int))
                return Numeric.force<T>(int.MaxValue);
            else
                return Numeric.force<T>(long.MaxValue);
        }

        [MethodImpl(Inline)]
        static T maxval_u<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return Numeric.force<T>(byte.MaxValue);
            else if(typeof(T) == typeof(ushort))
                return Numeric.force<T>(ushort.MaxValue);
            else if(typeof(T) == typeof(uint))
                return Numeric.force<T>(uint.MaxValue);
            else
                return Numeric.force<T>(ulong.MaxValue);
        }

        [MethodImpl(Inline)]
        static T maxval_f<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return Numeric.force<T>(float.MaxValue);
            else if(typeof(T) == typeof(double))
                return Numeric.force<T>(double.MaxValue);
            else
                throw no<T>();
        }

        /// <summary>
        /// Returns the minimum value supported by a parametrically-identified primal type
        /// </summary>
        /// <typeparam name="T">The primal source type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T minval<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte)
            || typeof(T) == typeof(short)
            || typeof(T) == typeof(int)
            || typeof(T) == typeof(long))
                return minval_i<T>();
            else if(typeof(T) == typeof(byte)
            || typeof(T) == typeof(ushort)
            || typeof(T) == typeof(uint)
            || typeof(T) == typeof(ulong))
                return minval_u<T>();
            else
                return minval_f<T>();
        }

        [MethodImpl(Inline)]
        static T minval_i<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return Numeric.force<T>(sbyte.MinValue);
            else if(typeof(T) == typeof(short))
                return Numeric.force<T>(short.MinValue);
            else if(typeof(T) == typeof(int))
                return Numeric.force<T>(int.MinValue);
            else
                return Numeric.force<T>(long.MinValue);
        }

        [MethodImpl(Inline)]
        static T minval_u<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return Numeric.force<T>(byte.MinValue);
            else if(typeof(T) == typeof(ushort))
                return Numeric.force<T>(ushort.MinValue);
            else if(typeof(T) == typeof(uint))
                return Numeric.force<T>(uint.MinValue);
            else
                return Numeric.force<T>(ulong.MinValue);
        }

        [MethodImpl(Inline)]
        static T minval_f<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return Numeric.force<T>(float.MinValue);
            else if(typeof(T) == typeof(double))
                return Numeric.force<T>(double.MinValue);
            else
                throw no<T>();
        }

        /// <summary>
        /// The minimum representable <see cref='BitSeq1'/> value
        /// </summary>
        public const Limits1u Min1u = Limits1u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq1'/> value
        /// </summary>
        public const Limits1u Max1u = Limits1u.Max;

        /// <summary>
        /// The minimum representable <see cref='BitSeq2'/> value
        /// </summary>
        public const Limits2u Min2u = Limits2u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq2'/> value
        /// </summary>
        public const Limits2u Max2u = Limits2u.Max;

        /// <summary>
        /// The minimum representable <see cref='BitSeq3'/> value
        /// </summary>
        public const Limits3u Min3u = Limits3u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq3'/> value
        /// </summary>
        public const Limits3u Max3u = Limits3u.Max;

        /// <summary>
        /// The minimum representable <see cref='BitSeq4'/> value
        /// </summary>
        public const Limits4u Min4u = Limits4u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq4'/> value
        /// </summary>
        public const Limits4u Max4u = Limits4u.Max;

        /// <summary>
        /// The minimum representable <see cref='BitSeq5'/> value
        /// </summary>
        public const Limits5u Min5u = Limits5u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq5'/> value
        /// </summary>
        public const Limits5u Max5u = Limits5u.Max;

        /// <summary>
        /// The minimum representable <see cref='BitSeq6'/> value
        /// </summary>
        public const Limits6u Min6u = Limits6u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq6'/> value
        /// </summary>
        public const Limits6u Max6u = Limits6u.Max;

        /// <summary>
        /// The minimum representable <see cref='BitSeq7'/> value
        /// </summary>
        public const Limits7u Min7u = Limits7u.Min;

        /// <summary>
        /// The maximum representable <see cref='BitSeq7'/> value
        /// </summary>
        public const Limits7u Max7u = Limits7u.Max;

        /// <summary>
        /// The minimum representable <see cref='sbyte'/> value
        /// </summary>
        public const Limits8i Min8i = Limits8i.Min;

        /// <summary>
        /// The maximum representable <see cref='sbyte'/> value
        /// </summary>
        public const Limits8i Max8i = Limits8i.Max;

        /// <summary>
        /// The minimum representable <see cref='byte'/> value
        /// </summary>
        public const Limits8u Min8u = Limits8u.Min;

        /// <summary>
        /// The maximum representable <see cref='byte'/> value
        /// </summary>
        public const Limits8u Max8u = Limits8u.Max;

        /// <summary>
        /// The maximum representable uint9 value
        /// </summary>
        public const Limits9u Max9u = Limits9u.Max;

        /// <summary>
        /// The maximum representable uint10 value
        /// </summary>
        public const Limits10u Max10u = Limits10u.Max;

        /// <summary>
        /// The maximum representable uint11 value
        /// </summary>
        public const Limits11u Max11u = Limits11u.Max;

        /// <summary>
        /// The maximum representable uint12 value
        /// </summary>
        public const Limits12u Max12u = Limits12u.Max;

        /// <summary>
        /// The maximum representable uint13 value
        /// </summary>
        public const Limits13u Max13u = Limits13u.Max;

        /// <summary>
        /// The maximum representable uint14 value
        /// </summary>
        public const Limits14u Max14u = Limits14u.Max;

        /// <summary>
        /// The maximum representable uint15 value
        /// </summary>
        public const Limits15u Max15u = Limits15u.Max;

        /// <summary>
        /// The minimum representable <see cref='short'/> value
        /// </summary>
        public const Limits16i Min16i = Limits16i.Min;

        /// <summary>
        /// The maximum representable <see cref='short'/> value
        /// </summary>
        public const Limits16i Max16i = Limits16i.Max;

        /// <summary>
        /// The minimum representable <see cref='ushort'/> value
        /// </summary>
        public const Limits16u Min16u = Limits16u.Min;

        /// <summary>
        /// The maximum representable <see cref='ushort'/> value
        /// </summary>
        public const Limits16u Max16u = Limits16u.Max;

        /// <summary>
        /// The maximum representable uint17 value
        /// </summary>
        public const Limits17u Max17u = Limits17u.Max;

        /// <summary>
        /// The maximum representable uint18 value
        /// </summary>
        public const Limits18u Max18u = Limits18u.Max;

        /// <summary>
        /// The maximum representable uint19 value
        /// </summary>
        public const Limits19u Max19u = Limits19u.Max;

        /// <summary>
        /// The maximum representable uint22 value
        /// </summary>
        public const Limits20u Max20u = Limits20u.Max;

        /// <summary>
        /// The maximum representable uint21 value
        /// </summary>
        public const Limits21u Max21u = Limits21u.Max;

        /// <summary>
        /// The maximum representable uint22 value
        /// </summary>
        public const Limits22u Max22u = Limits22u.Max;

        /// <summary>
        /// The maximum representable uint23 value
        /// </summary>
        public const Limits23u Max23u = Limits23u.Max;

        /// <summary>
        /// The minimum representable uint24 value
        /// </summary>
        public const Limits24u Min24u = Limits24u.Min;

        /// <summary>
        /// The maximum representable <see cref='ushort'/> value
        /// </summary>
        public const Limits24u Max24u = Limits24u.Max;

        /// <summary>
        /// The minimum representable uint25 value
        /// </summary>
        public const Limits25u Max25u = Limits25u.Max;

        /// <summary>
        /// The minimum representable uint26 value
        /// </summary>
        public const Limits26u Max26u = Limits26u.Max;

        /// <summary>
        /// The minimum representable <see cref='int'/> value
        /// </summary>
        public const Limits32i Min32i = Limits32i.Min;

        /// <summary>
        /// The maximum representable <see cref='int'/> value
        /// </summary>
        public const Limits32i Max32i = Limits32i.Max;

        /// <summary>
        /// The minimum representable <see cref='uint'/> value
        /// </summary>
        public const Limits32u Min32u = Limits32u.Min;

        /// <summary>
        /// The maximum representable <see cref='uint'/> value
        /// </summary>
        public const Limits32u Max32u = Limits32u.Max;

        /// <summary>
        /// The minimum representable <see cref='long'/> value
        /// </summary>
        public const Limits64i Min64i = Limits64i.Min;

        /// <summary>
        /// The maximum representable <see cref='long'/> value
        /// </summary>
        public const Limits64i Max64i = Limits64i.Max;

        /// <summary>
        /// The minimum representable <see cref='ulong'/> value
        /// </summary>
        public const Limits64u Min64u = Limits64u.Min;

        /// <summary>
        /// The maximum representable <see cref='ulong'/> value
        /// </summary>
        public const Limits64u Max64u = Limits64u.Max;

        /// <summary>
        /// The minimum representable <see cref='float'/> value
        /// </summary>
        public const float Min32f = float.MinValue;

        /// <summary>
        /// The maximum representable <see cref='float'/> value
        /// </summary>
        public const float Max32f = float.MaxValue;

        /// <summary>
        /// The minimum representable <see cref='double'/> value
        /// </summary>
        public const double Min64f = double.MinValue;

        /// <summary>
        /// The maximum representable <see cref='double'/> value
        /// </summary>
        public const double Max64f = double.MaxValue;

        /// <summary>
        /// The minimum representable <see cref='decimal'/> value
        /// </summary>
        public const decimal Min128f = decimal.MinValue;

        /// <summary>
        /// The maximum representable <see cref='decimal'/> value
        /// </summary>
        public const decimal Max128f = decimal.MaxValue;

        /// <summary>
        /// The minimum representable <see cref='char'/> value
        /// </summary>
        public const char Min16c = char.MinValue;

        /// <summary>
        /// The maximum representable <see cref='char'/> value
        /// </summary>
        public const char Max16c = char.MaxValue;
    }
}