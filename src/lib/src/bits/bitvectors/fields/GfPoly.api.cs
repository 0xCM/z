//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Primitive polynomials for GF reduction
    /// </summary>
    /// <remarks>The tables at https://www.partow.net/programming/polynomials/index.html were used for the source data</remarks>
    public static class GfPoly
    {
        /// <summary>
        /// x^2 + x^1 + x^0
        /// </summary>
        public static readonly GfPoly<N2,byte> Gfp_2_1_0 = Gf.Poly<N2,byte>(2,1,0);

        /// <summary>
        /// x^3 + x^1 + x^0
        /// </summary>
        public static readonly GfPoly<N3,byte> Gfp_3_1_0 = Gf.Poly<N3,byte>(3,1,0);

        /// <summary>
        /// x^4 + x^1 + x^0
        /// </summary>
        public static readonly GfPoly<N4,byte> Gfp_4_1_0 = Gf.Poly<N4,byte>(4,1,0);

        /// <summary>
        /// x^5 + x^2 + x^0
        /// </summary>
        public static readonly GfPoly<N5,byte> Gfp_5_2_0 = Gf.Poly<N5,byte>(5,2,0);

        /// <summary>
        /// x^6 + x^1 + x^0
        /// </summary>
        public static readonly GfPoly<N6,byte> Gfp_6_1_0 = Gf.Poly<N6,byte>(6,1,0);

        /// <summary>
        /// x^7 + x^1 + x^0
        /// </summary>
        public static readonly GfPoly<N7,byte> Gfp_7_1_0 = Gf.Poly<N7,byte>(7,1,0);

        /// <summary>
        /// x^8 + x^4 + x^3 + x^2 + x^0
        /// 0b1_0001_1101
        /// </summary>
        public static readonly GfPoly<N8,ushort> Gfp_8_4_3_2_0 = Gf.Poly<N8,ushort>(8,4,3,2,0);

        /// <summary>
        /// x^9 + x^4 + x^0
        /// </summary>
        public static readonly GfPoly<N9,ushort> Gfp_9_4_0 = Gf.Poly<N9, ushort>(9,4,0);

        /// <summary>
        /// x^10 + x^3 + x^0
        /// </summary>
        public static readonly GfPoly<N10,ushort> Gfp_10_3_0 = Gf.Poly<N10, ushort>(10,3,0);

        /// <summary>
        /// x^11 + x^2 + x^0
        /// </summary>
        public static readonly GfPoly<N11,ushort> Gfp_11_2_1 = Gf.Poly<N11, ushort>(11,2,0);

        /// <summary>
        /// x^16 + x^9 + x^8 + x^7 + x^6 + x^4 + x^3 + x^2 + x^0
        /// </summary>
        public static readonly GfPoly<N16,uint> Gfp_16_9_8_7_6_4_3_2_0 = Gf.Poly<N16,uint>(16,9,8,7,6,4,3,2,0);

        /// <summary>
        /// x^32 + x^22 + x^2 + x^1 + x^0
        /// </summary>
        public static readonly GfPoly<N32,ulong> Gfp_32_22_2_1_0 = Gf.Poly<N32,ulong>(32,22,2,1,0);

        /// <summary>
        /// Searches for a primal polynomial of degree N used for reduction in GF(2^N)
        /// <typeparam name="N">The degree of the polynomial</typeparam>
        /// <typeparam name="T">The scalar type of size at least N + 1 bits</typeparam>
        /// <returns>A matching polynomial, if found; otherwise, the Zero polynomial</returns>
        /// <remarks>Note that exp values should not include the order itself</remarks>
        public static GfPoly<N,T> Lookup<N,T>(N degree = default, T rep = default)
            where T : unmanaged
            where N : unmanaged, ITypeNat
        {
            var n = Typed.nat32i<N>();
            switch(n)
            {
                case 2:
                    return Gfp_2_1_0.As<N,T>();
                case 3:
                    return Gfp_3_1_0.As<N,T>();
                case 4:
                    return Gfp_4_1_0.As<N,T>();
                case 5:
                    return Gfp_5_2_0.As<N,T>();
                case 6:
                    return Gfp_6_1_0.As<N,T>();
                case 7:
                    return Gfp_7_1_0.As<N,T>();
                case 8:
                    return Gfp_8_4_3_2_0.As<N,T>();
                case 9:
                    return Gfp_9_4_0.As<N,T>();
                case 10:
                    return Gfp_10_3_0.As<N,T>();
                case 11:
                    return Gfp_11_2_1.As<N,T>();
                case 16:
                    return Gfp_16_9_8_7_6_4_3_2_0.As<N,T>();
                case 32:
                    return Gfp_32_22_2_1_0.As<N,T>();
                default:
                    return GfPoly<N,T>.Zero;
            }
        }
   }
}