//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class fmath
    {
        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static float dec(float src)
            => --src;

        /// <summary>
        /// Decrements the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Dec]
        public static double dec(double src)
            => --src;

        /// <summary>
        /// Increments the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static float inc(float src)
            => ++src;

        /// <summary>
        /// Increments the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Inc]
        public static double inc(double src)
            => ++src;

        /// <summary>
        /// Negates the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Negate]
        public static float negate(float src)
            => -src;

        /// <summary>
        /// Negates the operand
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Negate]
        public static double negate(double src)
            => -src;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static float add(float a, float b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic sum of the source operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Add]
        public static double add(double a, double b)
            => a + b;

        /// <summary>
        /// Computes the arithmetic difference between the first operand and the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Sub]
        public static float sub(float a, float b)
            => a - b;

        /// <summary>
        /// Computes the arithmetic difference between the first operand and the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Sub]
        public static double sub(double a, double b)
            => a - b;

        /// <summary>
        /// Computes the arithmetic product of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Mul]
        public static float mul(float a, float b)
            => a * b;

        /// <summary>
        /// Computes the arithmetic product of the operands
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Mul]
        public static double mul(double a, double b)
            => a * b;

        /// <summary>
        /// Computes the arithmetic quotient of the first operand over the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Div]
        public static float div(float a, float b)
            => a / b;

        /// <summary>
        /// Computes the arithmetic quotient of the first operand over the second
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Div]
        public static double div(double a, double b)
            => a / b;

        [MethodImpl(Inline), Mod]
        public static float mod(float a, float b)
            => RefOps.mod(a,b);

        [MethodImpl(Inline), Mod]
        public static double mod(double a, double b)
            => RefOps.mod(a,b);

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static float modmul(float a, float b, float m)
            => (a*b) % m;

        /// <summary>
        /// Computes z := (a*b) mod m
        /// </summary>
        /// <param name="a">The first factor</param>
        /// <param name="b">The second factor</param>
        /// <param name="m">The modulus</param>
        [MethodImpl(Inline), ModMul]
        public static double modmul(double a, double b, double m)
            => (a*b) % m;

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<float> divmod(float a, float b)
            => (div(a,b), mod(a,b));

        /// <summary>
        /// Computes dst = (div(a,b), mod(a,b))
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), DivMod]
        public static ConstPair<double> divmod(double a, double b)
            => (div(a,b), mod(a,b));

        /// <summary>
        /// Computes the smallest integral value greater than or equal to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static float ceil(float src)
            => MathF.Ceiling(src);

        /// <summary>
        /// Computes the smallest integral value greater than or equal to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static double ceil(double src)
            => Math.Ceiling(src);

        /// <summary>
        /// Computes the largest integral value less than or equal to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static float floor(float src)
            => MathF.Floor(src);

        /// <summary>
        /// Computes the largest integral value less than or equal to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static double floor(double src)
            => Math.Floor(src);

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static float clamp(float src, float max)
            => src > max ? max : src;

        /// <summary>
        /// Clamps the source value to an inclusive maximum
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="max">The maximum value</param>
        [MethodImpl(Inline), Clamp]
        public static double clamp(double src, double max)
            => src > max ? max : src;

        /// <summary>
        /// Computes the nonnegative distance between two values
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static float dist(float a, float b)
            => a >= b ? a - b : b - a;

        /// <summary>
        /// Computes the nonnegative distance between two values
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        [MethodImpl(Inline), Dist]
        public static double dist(double a, double b)
            => a >= b ? a - b : b - a;

        [MethodImpl(Inline), Divides]
        public static bool divides(float a, float b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bool divides(double a, double b)
            => b % a == 0;

        [MethodImpl(Inline), Fma]
        public static float fma(float x, float y, float z)
            => MathF.FusedMultiplyAdd(x,y,z);

        [MethodImpl(Inline), Fma]
        public static double fma(double x, double y, double z)
            => Math.FusedMultiplyAdd(x, y, z);

        /// <summary>
        /// Computes the remainder of the quotient of the operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), Op]
        public static float fmod(float a, float b)
            => MathF.IEEERemainder(a,b);

        /// <summary>
        /// Computes the remainder of the quotient of the operands
        /// </summary>
        /// <param name="a">The dividend</param>
        /// <param name="b">The divisor</param>
        [MethodImpl(Inline), Op]
        public static double fmod(double a, double b)
            => Math.IEEERemainder(a,b);

        [MethodImpl(Inline), Op]
        public static float round(float src, int scale)
            => MathF.Round(src, scale);

        [MethodImpl(Inline), Op]
        public static double round(double src, int scale)
            => Math.Round(src, scale);

        [MethodImpl(Inline), Op]
        public static Sign sign(float src)
            => (SignKind)MathF.Sign(src);

        [MethodImpl(Inline), Op]
        public static Sign sign(double src)
            => (SignKind)Math.Sign(src);

        [MethodImpl(Inline), Square]
        public static float square(float src)
            => mul(src,src);

        [MethodImpl(Inline), Square]
        public static double square(double src)
            => mul(src,src);

        /// <summary>
        /// Computes the square root of the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Sqrt]
        public static float sqrt(float src)
            => MathF.Sqrt(src);

        /// <summary>
        /// Computes the square root of the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Sqrt]
        public static double sqrt(double src)
            => Math.Sqrt(src);

        /// <summary>
        /// Computes the absolute value of the source
        /// </summary>
        /// <param name="a">The source value</param>
        [MethodImpl(Inline), Abs]
        public static float abs(float a)
            => MathF.Abs(a);

        /// <summary>
        /// Computes the absolute value of the source
        /// </summary>
        /// <param name="a">The source value</param>
        [MethodImpl(Inline), Abs]
        public static double abs(double a)
            => Math.Abs(a);
    }
}