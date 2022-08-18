//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Gated
    {
        public readonly struct AndGate : IBinaryGate
        {
            [MethodImpl(Inline)]
            public bit Invoke(bit x, bit y)
                => (x & y);
        }

        public readonly struct AndGate<T> : IBinaryGate<T>, IBinaryGate128<T>, IBinaryGate256<T>, IBinaryGate512<T>
            where T : unmanaged
        {
            /// <summary>
            /// Defines the canonical boolean or function, or:{0,1} x {0,1} -> {0,1}
            /// </summary>
            /// <param name="x">The first input value</param>
            /// <param name="y">The second input value</param>
            [MethodImpl(Inline)]
            public bit Invoke(bit x, bit y)
                => x & y;

            /// <summary>
            /// Simultaneously evaluates N boolean or functions wher N denotes the bit-width of the parametric type
            /// </summary>
            /// <param name="x">The left operands</param>
            /// <param name="y">The right operands</param>
            [MethodImpl(Inline)]
            public T Invoke(T x, T y)
                => gmath.and(x,y);

            /// <summary>
            /// Computes 128 boolean OR functions simultaneously
            /// </summary>
            /// <param name="x">The left operands</param>
            /// <param name="y">The right operands</param>
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, Vector128<T> y)
                => gcpu.vand(x,y);

            /// <summary>
            /// Computes 256 boolean OR functions simultaneously
            /// </summary>
            /// <param name="x">The left operands</param>
            /// <param name="y">The right operands</param>
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> a, Vector256<T> b)
                => gcpu.vand<T>(a,b);

            /// <summary>
            /// Computes 512 boolean OR functions simultaneously
            /// </summary>
            /// <param name="x">The left operands</param>
            /// <param name="y">The right operands</param>
            [MethodImpl(Inline)]
            public Vector512<T> Invoke(in Vector512<T> a, in Vector512<T> b)
                => gcpu.vand<T>(a,b);
        }
    }
}