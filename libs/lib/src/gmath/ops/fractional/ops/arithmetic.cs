//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct gfp
    {
        [MethodImpl(Inline), Add, Closures(Closure)]
        public static T add<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.add(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.add(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Sub, Closures(Closure)]
        public static T sub<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.sub(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.sub(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T mul<T>(T lhs, T rhs)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.mul(float32(lhs), float32(rhs)));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.mul(float64(lhs), float64(rhs)));
            else
                throw no<T>();
        }
        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Dec, Closures(Closure)]
        public static T dec<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return(generic<T>(math.dec(float32(src))));
            else if(typeof(T) == typeof(double))
                return(generic<T>(math.dec(float64(src))));
            else
                throw no<T>();
        }

        /// <summary>
        /// Increments the source value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Inc, Closures(Floats)]
        public static T inc<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.inc(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.inc(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T negate<T>(T lhs)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.negate(float32(lhs)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.negate(float64(lhs)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Floor, Closures(Floats)]
        public static T floor<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.floor(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.floor(float64(src)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes the absolute value of a primal FP scalar
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The FP type</typeparam>
        [MethodImpl(Inline), Abs, Closures(Closure)]
        public static T abs<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.abs(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.abs(float64(src)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b)) for floating-point numeric types
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod, Closures(Floats)]
        public static ConstPair<T> divmod<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return Tuples.generic<T>(fmath.RefOps.divmod(float32(a), float32(b)));
            else if(typeof(T) == typeof(float))
                return Tuples.generic<T>(fmath.RefOps.divmod(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T modmul<T>(T a, T b, T m)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.modmul(float32(a), float32(b), float32(m)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.modmul(float64(a), float64(b), float64(m)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes the modulus of floating-point operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal floating-point type</typeparam>
        [MethodImpl(Inline), Mod, Closures(Closure)]
        public static T mod<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return generic<T>(fmath.mod(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                 return generic<T>(fmath.mod(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Ceil, Closures(Closure)]
        public static T ceil<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.ceil(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.ceil(float64(src)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes the quotient of floating-point operands
        /// </summary>
        /// <param name="a">The left operand</param>
        /// <param name="b">The right operand</param>
        /// <typeparam name="T">The primal floating-point type</typeparam>
        [MethodImpl(Inline), Div, Closures(Closure)]
        public static T div<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return generic<T>(fmath.div(float32(a), float32(b)));
            else if(typeof(T) == typeof(double))
                 return generic<T>(fmath.div(float64(a), float64(b)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Divides, Closures(Closure)]
        public static bool divides<T>(T a, T b)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                 return fmath.divides(float32(a), float32(b));
            else if(typeof(T) == typeof(double))
                 return fmath.divides(float64(a), float64(b));
            else
                throw no<T>();
        }

        /// <summary>
        /// Computes and returns the result r = x*y + z
        /// </summary>
        /// <param name="x">The first operand</param>
        /// <param name="y">The second operand</param>
        /// <param name="z">The third operand</param>
        /// <typeparam name="T">The floating point operand type</typeparam>
        [MethodImpl(Inline), Fma, Closures(Closure)]
        public static T fma<T>(T x, T y, T z)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmath.fma(float32(x), float32(y), float32(z)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmath.fma(float64(x), float64(y), float64(z)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Square, Closures(Closure)]
        public static T square<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.square(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.square(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static T round<T>(T src, int scale)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(math.round(float32(src), scale));
            else if(typeof(T) == typeof(double))
                return generic<T>(math.round(float64(src), scale));
            else
                return src;
        }
   }
}