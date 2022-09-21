//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Shows the "extended" De Morgan's laws hold as specified in Chapter 2 of Hacker's Delight
    /// </summary>
    public class t_bvlaws : t_bits<t_bvlaws>
    {
        /// <summary>
        /// Verifies the identity  ~(x & y) = ~ x | ~ y holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan1_32u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var y = Random.BitVector(n32);
                Claim.eq(~(x & y), ~x | ~ y);
            }
        }

        /// <summary>
        /// Verifies the identity  ~(x & y) = ~ x | ~ y holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan1_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                var y = Random.BitVector(n64);
                Claim.eq(~(x & y), ~x | ~ y);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x | y) = ~ x & ~ y holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan2_32u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var y = Random.BitVector(n32);
                Claim.eq(~(x | y), ~x & ~ y);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x | y) = ~ x & ~ y holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan2_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                var y = Random.BitVector(n64);
                Claim.eq(~(x | y), ~x & ~ y);
            }
        }


        /// <summary>
        /// Verifies the identity ~(x + 1) = ~ x - 1 holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan3_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                Claim.eq(~(x + 1), ~x - 1);
            }
        }

        /// <summary>
        /// Verifies the identity  ~(x - 1) = ~ x + 1 holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan4_32u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                Claim.eq(~(x - 1), ~x + 1);
            }
        }

        /// <summary>
        /// Verifies the identity  ~(x - 1) = ~ x + 1 holds for 8-bit bitvectors
        /// </summary>
        public void bv_demorgan4_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                Claim.eq(~(x - 1), ~x + 1);
            }
        }

        /// <summary>
        /// Verifies the identity  ~(-x) = x - 1 holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan5_8u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n8);
                Claim.eq(~(-x), x - 1);
            }

        }

        /// <summary>
        /// Verifies the identity  ~(-x) = x - 1 holds for 16-bit bitvectors
        /// </summary>
        public void bv_demorgan5_16u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n16);
                Claim.eq(~(-x), x - 1);
            }

        }

        /// <summary>
        /// Verifies the identity  ~(-x) = x - 1 holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan5_32u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                Claim.eq(~(-x), x - 1);
            }

        }

        /// <summary>
        /// Verifies the identity ~(-x) = x - 1 holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan5_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                Claim.eq(~(-x), x - 1);
            }

        }

        /// <summary>
        /// Verifies the identity ~(x ^ y) = ~x ^ y holds for 8-bit bitvectors
        /// </summary>
        public void bv_demorgan6_8u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n8);
                var y = Random.BitVector(n8);
                Claim.eq(~(x ^ y), ~x ^ y);
                Claim.eq(~(x ^ y), x ^ ~y);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x ^ y) = ~x ^ y holds for 16-bit bitvectors
        /// </summary>
        public void bv_demorgan6_16u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n16);
                var y = Random.BitVector(n16);
                Claim.eq(~(x ^ y), ~x ^ y);
                Claim.eq(~(x ^ y), x ^ ~y);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x ^ y) = ~x ^ y holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan6_32u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var y = Random.BitVector(n32);
                Claim.eq(~(x ^ y), ~x ^ y);
                Claim.eq(~(x ^ y), x ^ ~y);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x ^ y) = ~x ^ y holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan6_64u()
        {
            var x = Random.BitVector(n64);
            var y = Random.BitVector(n64);
            Claim.eq(~(x ^ y), ~x ^ y);
            Claim.eq(~(x ^ y), x ^ ~y);
        }

        /// <summary>
        /// Verifies the identity ~(x + y) = ~x - y holds for 8-bit bitvectors
        /// </summary>
        public void bv_demorgan7_8u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n8);
                var y = Random.BitVector(n8);
                Claim.eq(~(x + y), ~x - y);
                Claim.eq(~(x + y), ~y - x);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x + y) = ~x - y holds for 16-bit bitvectors
        /// </summary>
        public void bv_demorgan7_16u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n16);
                var y = Random.BitVector(n16);
                Claim.eq(~(x + y), ~x - y);
                Claim.eq(~(x + y), ~y - x);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x + y) = ~x - y holds for 32-bit bitvectors
        /// </summary>
        public void bv_demorgan7_32u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n32);
                var y = Random.BitVector(n32);
                Claim.eq(~(x + y), ~x - y);
                Claim.eq(~(x + y), ~y - x);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x + y) = ~x - y holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan7_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                var y = Random.BitVector(n64);
                Claim.eq(~(x + y), ~x - y);
                Claim.eq(~(x + y), ~y - x);
            }
        }

        /// <summary>
        /// Verifies the identity ~(x - y) = ~x + y holds for 64-bit bitvectors
        /// </summary>
        public void bv_demorgan8_64u()
        {
            for(var i=0; i<RepCount; i++)
            {
                var x = Random.BitVector(n64);
                var y = Random.BitVector(n64);
                Claim.eq(~(x - y), ~x + y);
                Claim.eq(~(y - x), ~y + x);
            }
        }
    }
}