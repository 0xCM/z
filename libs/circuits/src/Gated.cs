//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Generic vectorized intrinsics
    /// </summary>
    [ApiHost]
    public partial class Gated
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static FlowGateInfo gate(FlowGateKind kind, byte width, byte ins, byte outs)
            => new FlowGateInfo(kind, width, ins, outs);

        [MethodImpl(Inline), Op]
        public static FlowWire wire(byte width)
            => new FlowWire(width);

        [MethodImpl(Inline), Op]
        public static AndGate and()
            => default(AndGate);

        [MethodImpl(Inline), Op]
        public static XOrGate xor()
            => default(XOrGate);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AndGate<T> and<T>()
            where T : unmanaged
                => default(AndGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static OrGate<T> or<T>()
            where T : unmanaged
                => default(OrGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static XOrGate<T> xor<T>()
            where T : unmanaged
                => default(XOrGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NotGate<T> not<T>()
            where T : unmanaged
                => default(NotGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NandGate<T> nand<T>()
            where T : unmanaged
                => default(NandGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NorGate<T> nor<T>()
            where T : unmanaged
                => default(NorGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static XnorGate<T> xnor<T>()
            where T : unmanaged
                => default(XnorGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static MuxGate<T> mux<T>()
            where T : unmanaged
                => default(MuxGate<T>);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HalfAdder<T> half<T>()
            where T : unmanaged
                => default(HalfAdder<T>);

        /// <summary>
        /// Implements a carry-save adder that deposits the bitwise sum of three input scalars into two output scalars
        /// </summary>
        /// <param name="a">The first input vector</param>
        /// <param name="b">The second input vector</param>
        /// <param name="c">The third input vector</param>
        /// <param name="lo">The lo part of the result</param>
        /// <param name="hi">THe hi part of the result</param>
        /// <typeparam name="T">The primal type</typeparam>
        /// <remarks>See:
        /// https://arxiv.org/pdf/1611.07612.pdf
        /// https://github.com/WojciechMula/sse-popcount
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void csa<T>(T a, T b, T c, out T lo, out T hi)
            where T : unmanaged
        {
            var u = gmath.xor(a,b);
            lo = gmath.xor(u,c);
            hi = gmath.or(gmath.and(a,b), gmath.and(u,c));
        }

        /// <summary>
        /// Implements a carry-save adder that deposits the bitwise sum of three input vectors into two output vectors
        /// </summary>
        /// <param name="a">The first input vector</param>
        /// <param name="b">The second input vector</param>
        /// <param name="c">The third input vector</param>
        /// <param name="lo">The lo part of the result</param>
        /// <param name="hi">THe hi part of the result</param>
        /// <typeparam name="T">The primal type</typeparam>
        /// <remarks>See:
        /// https://arxiv.org/pdf/1611.07612.pdf
        /// https://github.com/WojciechMula/sse-popcount
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static Vector512<T> vcsa<T>(Vector256<T> a, Vector256<T> b, Vector256<T> c)
            where T : unmanaged
        {
            var u = gcpu.vxor(a,b);
            var lo = gcpu.vxor(u,c);
            var hi = gcpu.vor(gcpu.vand(a,b), gcpu.vand(u,c));
            return(lo,hi);
        }
    }
}