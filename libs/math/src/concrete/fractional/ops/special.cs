//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class fmath
    {
        /// <summary>
        /// Computes the cube root of the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static float cbrt(float src)
            => MathF.Cbrt(src);

        /// <summary>
        /// Computes the cube root of the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static double cbrt(double src)
            => Math.Cbrt(src);

        /// <summary>
        /// Raises e to a specified exponent
        /// </summary>
        /// <param name="pow">The exponent</param>
        [MethodImpl(Inline), Op]
        public static float exp(float pow)
            => MathF.Exp(pow);

        /// <summary>
        /// Raises e to a specified exponent
        /// </summary>
        /// <param name="pow">The exponent</param>
        [MethodImpl(Inline), Op]
        public static double exp(double pow)
            => Math.Exp(pow);

        [MethodImpl(Inline), Op]
        public static float pow(float src, float exp)
            => MathF.Pow(src,exp);

        [MethodImpl(Inline), Op]
        public static double pow(double src, double exp)
            => Math.Pow(src,exp);

        /// <summary>
        /// Computes the relative error between a one floating-point calculation and another
        /// </summary>
        /// <param name="lhs">The result of the first calculation</param>
        /// <param name="rhs">The result of the second calculation</param>
        [MethodImpl(Inline), Op]
        public static float relerr(float lhs, float rhs)
        {
            var err = dist(lhs,rhs)/lhs;
            return err.IsNaN() ? 0 : err;
        }

        /// <summary>
        /// Computes the relative error between a one floating-point calculation and another
        /// </summary>
        /// <param name="lhs">The result of the first calculation</param>
        /// <param name="rhs">The result of the second calculation</param>
        [MethodImpl(Inline), Op]
        public static double relerr(double lhs, double rhs)
        {
            var err = dist(lhs,rhs)/lhs;
            return err.IsNaN() ? 0 : err;
        }

        /// <summary>
        /// Impelements compensated floating-point summation
        /// </summary>
        /// <param name="src">The value to add to the total</param>
        /// <param name="delta">The last compensation amount</param>
        /// <param name="total">The running total</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Kahan_summation_algorithm</remarks>
        [MethodImpl(Inline), Op]
        public static ref double fcsum(in double src, ref double delta, ref double total)
        {
            var y = src - delta;
            var t = total + y;
            delta = (t - total) - y;
            total = t;
            return ref total;
        }

        [MethodImpl(Inline), Op]
        public static float gcd(float a, float b)
        {
            var x = abs(a);
            var y = abs(b);
            while (y != 0)
            {
                var rem = mod(x,y);
                x = y;
                y = rem;
            }

            return x;
        }

        [MethodImpl(Inline), Op]
        public static double gcd(double a, double b)
        {
            var x = abs(a);
            var y = abs(b);
            while (y != 0)
            {
                var rem = mod(x,y);
                x = y;
                y = rem;
            }

            return x;
        }

        /// <summary>
        /// Computes the base-2 log of the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static float log2(float src)
            => MathF.Log2(src);

        /// <summary>
        /// Computes the base-2 log of the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static double log2(double src)
            => Math.Log2(src);

        /// <summary>
        /// Computes the base-e log of the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static float ln(float src)
            => MathF.Log(src);

        /// <summary>
        /// Computes the base-e log of the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static double ln(double src)
            => Math.Log(src);

        /// <summary>
        /// Computes the log of the source value relative to an optionally-specified base
        /// which otherwise defaults to base-10
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="b">The log base</param>
        [MethodImpl(Inline), Op]
        public static float log(float src, float? b = null)
            => MathF.Log(src, b ?? 10);

        /// <summary>
        /// Computes the log of the source value relative to an optionally-specified base
        /// which otherwise defaults to base-10
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="b">The log base</param>
        [MethodImpl(Inline), Op]
        public static double log(double src, double? b = null)
            => Math.Log(src, b ?? 10);

        [MethodImpl(Inline), Op]
        public static float sin(float x)
            => MathF.Sin(x);

        [MethodImpl(Inline), Op]
        public static double sin(double x)
            => Math.Sin(x);

        [MethodImpl(Inline), Op]
        public static float cos(float x)
            => MathF.Cos(x);

        [MethodImpl(Inline), Op]
        public static double cos(double x)
            => Math.Cos(x);

        [MethodImpl(Inline), Op]
        public static float tan(float x)
            => MathF.Tan(x);

        [MethodImpl(Inline), Op]
        public static double tan(double x)
            => Math.Tan(x);

        [MethodImpl(Inline), Op]
        public static float asin(float x)
            => MathF.Asin(x);

        [MethodImpl(Inline), Op]
        public static double asin(double x)
            => Math.Asin(x);

        [MethodImpl(Inline), Op]
        public static float acos(float x)
            => MathF.Acos(x);

        [MethodImpl(Inline), Op]
        public static double acos(double x)
            => Math.Acos(x);

        [MethodImpl(Inline), Op]
        public static float atan(float x)
            => MathF.Atan(x);

        [MethodImpl(Inline), Op]
        public static double atan(double x)
            => Math.Atan(x);

        [MethodImpl(Inline), Op]
        public static float sinh(float x)
            => MathF.Sinh(x);

        [MethodImpl(Inline), Op]
        public static double sinh(double x)
            => Math.Sinh(x);

        [MethodImpl(Inline), Op]
        public static float cosh(float x)
            => MathF.Cosh(x);

        [MethodImpl(Inline), Op]
        public static double cosh(double x)
            => Math.Cosh(x);

        [MethodImpl(Inline), Op]
        public static float tanh(float x)
            => MathF.Tanh(x);

        [MethodImpl(Inline), Op]
        public static double tanh(double x)
            => Math.Tanh(x);
        [MethodImpl(Inline), Op]
        public static float asinh(float x)
            => MathF.Asinh(x);

        [MethodImpl(Inline), Op]
        public static double asinh(double x)
            => Math.Asinh(x);

        [MethodImpl(Inline), Op]
        public static float acosh(float x)
            => MathF.Acosh(x);

        [MethodImpl(Inline), Op]
        public static double acosh(double x)
            => Math.Acosh(x);

        [MethodImpl(Inline), Op]
        public static float atanh(float x)
            => MathF.Atanh(x);

        [MethodImpl(Inline), Op]
        public static double atanh(double x)
            => Math.Atanh(x);
    }
}