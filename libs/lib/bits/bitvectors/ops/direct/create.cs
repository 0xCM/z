//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitVectors
    {
        /// <summary>
        /// Creates a 4-bit bitvector from the least 4 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, byte src)
            => src;

        /// <summary>
        /// Creates a 4-bit bitvector from the least 4 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, ushort src)
            => (byte)src;

        /// <summary>
        /// Creates a 4-bit bitvector from the least 4 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, uint src)
            => (byte)src;

        /// <summary>
        /// Creates a 4-bit bitvector from the least 4 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, ulong src)
            => (byte)src;

        /// <summary>
        /// Creates a 4-bit bitvector from 2 explicit bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, bit b0, bit b1)
        {
            var data = 0u;
            if(b0)
                data |= (1 << 0);
            if(b1)
                data |= (1 << 1);

            return (byte)data;
        }

        /// <summary>
        /// Creates a 4-bit bitvector from 3 explicit bitss
        /// </summary>
        /// <param name="n">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, bit b0, bit b1, bit b2)
        {
            var data = create(n4,b0,b1);
            if(b2)
                data |= (1 << 2);
            return (byte)data;
        }

        /// <summary>
        /// Creates a 4-bit bitvector from 4 explicit bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, bit b0, bit b1, bit b2, bit b3)
        {
            var data = create(n,b0,b1,b2);
            if(b3)
                data |= (1 << 3);
            return data;
        }

        /// <summary>
        /// Creates a 4-bit bitvector from a bitstring
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector4 create(N4 n, BitString src)
            => new BitVector4(src.IsEmpty ? (byte)0 : src.Pack()[0]);

        /// <summary>
        /// Creates a vector from a bitstring
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, BitString src)
            => src.TakeUInt8();

        /// <summary>
        /// Creates an 8-bit bitvector from 4 explicit bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, bit b0, bit b1, bit b2, bit b3)
            => bit.pack(b0, b1, b2, b3);

        /// <summary>
        /// Creates an 8-bit bitvector from 8 explicit bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, bit b0, bit b1, bit b2, bit b3, bit b4, bit b5, bit b6, bit b7)
            => bit.pack(b0, b1, b2, b3, b4, b5, b6, b7);

        /// <summary>
        /// Creates an 8-bit bitvector from a byte
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, byte src)
            => new BitVector8(src);

        /// <summary>
        /// Creates an 8-bit bitvector from the least 8 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, int src)
            => new BitVector8((byte)src);

        /// <summary>
        /// Creates an 8-bit bitvector from the least 8 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, uint src)
            => new BitVector8((byte)src);

        /// <summary>
        /// Creates an 8-bit bitvector from the least 8 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector8 create(N8 n, ulong src)
            => new BitVector8((byte)src);

        /// <summary>
        /// Creates a 16-bit bitvector from a bitstring
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 create(N16 n, BitString src)
            => src.TakeUInt16();

        /// <summary>
        /// Creates a 16-bit bitvector from hi and lo parts
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="lo">The lo bits</param>
        /// <param name="hi">The hi bits</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 create(N16 n, byte lo, byte hi)
            => new BitVector16((ushort)((ushort)hi << 8 | (ushort)lo));

        /// <summary>
        /// Creates a 16-bit bitvector from the least 16 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector16 create(N16 n, ulong src)
            => new BitVector16((ushort)src);

        /// <summary>
        /// Creates a 32-bit bitvector from the totality of the source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, uint src)
            => new BitVector32(src);

        /// <summary>
        /// Creates a 32-bit bitvector from the totality of the source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, int src)
            => new BitVector32((uint)src);

        /// <summary>
        /// Creates a 32-bit bitvector from the least 32 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, long src)
            => new BitVector32((uint)src);

        /// <summary>
        /// Creates a 32-bit bitvector from the least 32 source bits
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, ulong src)
            => new BitVector32((uint)src);

        /// <summary>
        /// Creates a 32-bit bitvector from a bitstring
        /// </summary>
        /// <param name="n">The target width selector</param>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, BitString src)
            => src.TakeUInt32();

        /// <summary>
        /// Creates a vector from a bitstring
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, byte x0, byte x1, byte x2, byte x3)
            => new BitVector32(bits.join(x0,x1,x2,x3));

        /// <summary>
        /// Creates a vector from two unsigned 16-bit integers
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitVector32 create(N32 n, ushort lo, ushort hi)
            => create(n, (uint)hi << 16 | (uint)lo);

        /// <summary>
        /// Creates a generic bitvector from 4 explicit bytes
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, ushort x0, ushort x1, ushort x2, ushort x3)
            => bits.join(x0,x1,x2,x3);

        /// <summary>
        /// Creates a 64-bit bitvector where the first 8 bits a populated with a specified value and
        /// all others are zero
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, byte src)
            => new BitVector64(src);

        /// <summary>
        /// Creates a vector from a primal source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, ushort src)
            => new BitVector64(src);

        /// <summary>
        /// Creates a vector from a primal source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, uint src)
            => new BitVector64(src);

        /// <summary>
        /// Creates a vector from a primal source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, ulong src)
            => new BitVector64(src);

        /// <summary>
        /// Creates a vector from two unsigned 32-bit integers
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, uint lo, uint hi)
            => create(n,(ulong)hi << 32 | (ulong)lo);

        /// <summary>
        /// Creates a vector from a bitstring
        /// </summary>
        /// <param name="src">The source bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitVector64 create(N64 n, BitString src)
            => src.TakeUInt64();
    }
}