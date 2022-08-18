//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class Gf
    {
        /// <summary>
        /// Defines a binary polynomial from a monotonically decreasing exponent sequence
        /// </summary>
        /// <param name="exponents">The exponent sequence</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static T Poly<T>(params byte[] exponents)
            where T : unmanaged
        {
            var components = default(T);
            for(var i=0; i< exponents.Length; i++)
                components = gmath.or(components, gmath.pow2<T>(exponents[i]));
            return components;
        }

        /// <summary>
        /// Defines a binary polynomial of degree at most 15 from a monotonically decreasing exponent sequence
        /// </summary>
        /// <param name="exponents">The exponent sequence</param>
        /// <typeparam name="T">The primal type</typeparam>
        public static GfPoly16 Poly16(params byte[] exponents)
            => new GfPoly16(exponents);

        /// <summary>
        /// Defines a binary polynomial of natural degree N
        /// </summary>
        /// <param name="exponents">The exponent values for nonzero coefficients</param>
        /// <typeparam name="N">The degree of the polynomial</typeparam>
        /// <typeparam name="T">The polynomial scalar type</typeparam>
        public static GfPoly<N,T> Poly<N,T>(params byte[] exponents)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => new GfPoly<N,T>(exponents);

        /// <summary>
        /// Defines a binary polynomial of natural degree N = 3
        /// </summary>
        /// <param name="degree">The degree of the polynomial</param>
        /// <param name="exponents">The exponent values for nonzero coefficients</param>
        public static GfPoly<N3,byte> Poly(N3 degree, params byte[] exponents)
            => Poly<N3,byte>(exponents);

        /// <summary>
        /// Defines a binary polynomial of natural degree N = 8
        /// </summary>
        /// <param name="degree">The degree of the polynomial</param>
        /// <param name="exponents">The exponent values for nonzero coefficients</param>
        public static GfPoly<N8,ushort> Poly(N8 degree, params byte[] exponents)
            => Poly<N8,ushort>(exponents);

        /// <summary>
        /// Defines a binary polynomial of natural degree N = 10
        /// </summary>
        /// <param name="degree">The degree of the polynomial</param>
        /// <param name="exponents">The exponent values for nonzero coefficients</param>
        public static GfPoly<N16,uint> Poly(N16 degree, params byte[] exponents)
            => Poly<N16,uint>(exponents);

        /// <summary>
        /// Defines a binary polynomial of natural degree N = 32
        /// </summary>
        /// <param name="degree">The degree of the polynomial</param>
        /// <param name="exponents">The exponent values for nonzero coefficients</param>
        public static GfPoly<N32,ulong> Poly(N32 degree, params byte[] exponents)
            => Poly<N32,ulong>(exponents);
    }
}