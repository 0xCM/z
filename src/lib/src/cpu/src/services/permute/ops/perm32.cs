//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;

    partial struct Perm
    {
        /*
        /// <summary>
        /// Permutes the vector corrding to the spec
        /// </summary>
        /// <param name="spec">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector4 perm(BitVector4 src, in Perm spec)
        {
            var dst = src.Replicate();
            var w = src.Width;
            for(var i=z8; i<w; i++)
                dst[i] = src[(byte)spec[i]];
            return dst;
        }

        /// <summary>
        /// Applies a permutation to a replicated vector
        /// </summary>
        /// <param name="p">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector8 perm(BitVector8 src, in Perm p)
        {
            var dst = src.Replicate();
            var width = src.Width;
            for(var i=z8; i<width; i++)
                dst[i] = src[(byte)p[i]];
            return dst;
        }

        /// <summary>
        /// Rearranges the vector in-place as specified by a permutation
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="spec">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector16 perm(BitVector16 src, in Perm spec)
        {
            var dst = src.Replicate();
            var w = src.Width;
            for(var i=z8; i<w; i++)
            {
                ref readonly var j = ref spec[i];
                if(j != i)
                    dst[i] = src[(byte)j];
            }
            return dst;
        }

        /// <summary>
        /// Rearranges the vector specified by a permutation
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector32 perm(BitVector32 src, in Perm spec)
        {
            var dst = src.Replicate();
            var w = src.Width;
            for(var i=z8; i<w; i++)
            {
                ref readonly var j = ref spec[i];
                if(j != i)
                    dst[i] = src[(byte)j];
            }
            return dst;
        }

        /// <summary>
        /// Creates a new vector by permuting a replica of the source vector as specified by a permuation
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The permutation</param>
        [MethodImpl(Inline)]
        public static BitVector64 perm(BitVector64 src, in Perm spec)
        {
            var dst = src.Replicate();
            var w = src.Width;
            for(var i=z8; i<w; i++)
            {
                ref readonly var j = ref spec[i];
                if(j != i)
                    dst[i] = src[(byte)j];
            }
            return dst;
        }        
        */

        /// <summary>
        /// Creates a fixed 32-bit permutation over a generic permutation over 32 elements
        /// </summary>
        /// <param name="src">The source permutation</param>
        [MethodImpl(Inline), Op]
        public static Perm32 perm32(W256 w, Perm<byte> src)
            => new Perm32(vgcpu.vload(w, src.Terms));

        [MethodImpl(Inline), Op]
        public static Perm32 perm32(Vector256<byte> data)
            => new Perm32(vcpu.vand(data, vcpu.vbroadcast(w256, Msb8x8x3)));
    }
}