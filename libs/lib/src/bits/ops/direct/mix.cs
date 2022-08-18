//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;

    partial class bits
    {
        /// <summary>
        /// Blends alternating even operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static byte mix(N0 parity, byte x, byte y)
        {
            var mask = Even8;
            var xE = scatter(gather(x, mask), Even8);
            var yE = scatter(gather(y, mask), Odd8);
            var xEy = xE | yE;
            return (byte)xEy;
        }

        /// <summary>
        /// Blends alternating odd operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static byte mix(N1 parity, byte x, byte y)
        {
            var mask = Odd8;
            var xO = scatter(gather(x, mask), Even8);
            var yO = scatter(gather(y, mask), Odd8);
            var xOy = xO | yO;
            return (byte)xOy;
        }

        /// <summary>
        /// Blends alternating even operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static ushort mix(N0 parity, ushort x, ushort y)
        {
            var mask = Even16;
            var xE = scatter(gather(x, mask), Even16);
            var yE = scatter(gather(y, mask), Odd16);
            var xEy = xE | yE;
            return (ushort)xEy;
        }

        /// <summary>
        /// Blends alternating odd operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static ushort mix(N1 parity, ushort x, ushort y)
        {
            var mask = Odd16;
            var xO = scatter(gather(x, mask), Even16);
            var yO = scatter(gather(y, mask), Odd16);
            var xOy = xO | yO;
            return (ushort)xOy;
        }

        /// <summary>
        /// Blends alternating even operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static uint mix(N0 parity, uint x, uint y)
        {
            var mask = Even32;
            var xE = scatter(gather(x,mask),  Even32);
            var yE = scatter(gather(y,mask),  Odd32);
            var xEy = xE | yE;
            return xEy;
        }

        /// <summary>
        /// Blends alternating odd operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static uint mix(N1 parity, uint x, uint y)
        {
            var mask =  Odd32;
            var xO = scatter(gather(x, mask),  Even32);
            var yO = scatter(gather(y, mask),  Odd32);
            var xOy = xO | yO;
            return xOy;
        }

        /// <summary>
        /// Blends alternating even operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static ulong mix(N0 parity, ulong x, ulong y)
        {
            var mask = Even64;
            var xE = scatter(gather(x,mask), Even64);
            var yE = scatter(gather(y,mask), Odd64);
            var xEy = xE | yE;
            return xEy;
        }

        /// <summary>
        /// Blends alternating odd operand bits
        /// </summary>
        /// <param name="parity">The parity selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Mix]
        public static ulong mix(N1 parity, ulong x, ulong y)
        {
            var mask = Odd64;
            var xO = scatter(gather(x, mask), Even64);
            var yO = scatter(gather(y, mask), Odd64);
            var xOy = xO | yO;
            return xOy;
        }

        /// <summary>
        /// Blends alternating operand bits
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <param name="parity">The parity selector</param>
        [MethodImpl(Inline), Mix]
        public static byte mix(byte x, byte y, byte parity)
            => parity == 0 ? mix(n0, x, y) : mix(n1, x, y);

        /// <summary>
        /// Blends alternating operand bits
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <param name="parity">The parity selector</param>
        [MethodImpl(Inline), Mix]
        public static ushort mix(ushort x, ushort y, ushort parity)
            => parity == 0 ? mix(n0, x, y) : mix(n1, x, y);

        /// <summary>
        /// Blends alternating operand bits
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <param name="parity">The parity selector</param>
        [MethodImpl(Inline), Mix]
        public static uint mix(uint x, uint y, uint parity)
            => parity == 0 ? mix(n0, x, y) : mix(n1, x, y);

        /// <summary>
        /// Blends alternating operand bits
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        /// <param name="parity">The parity selector</param>
        [MethodImpl(Inline), Mix]
        public ulong mix(ulong x, ulong y, ulong parity)
            => parity == 0 ? mix(n0, x, y) : mix(n1, x, y);
    }
}