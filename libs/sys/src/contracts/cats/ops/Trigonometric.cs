//-----------------------------------------------------------------------------
// CopyrighS   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes trigonometric operations over a type
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface ITrigonmetric<T>
        {
            T Sin(T x);

            T Sinh(T x);

            T Asin(T x);

            T Asinh(T x);

            T Cos(T x);

            T Cosh(T x);

            T Acos(T x);

            T Acosh(T x);

            T Tan(T x);

            T Tanh(T x);

            T Atan(T x);

            T Atanh(T x);
        }
    }
}