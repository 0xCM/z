//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// An anti-succinct representation of a bit
    /// </summary>
    [ApiHost]
    public readonly struct Bit32 : ITextual
    {
        public const char Zero = '0';

        public const char One = '1';

        readonly uint State;

        [MethodImpl(Inline), Op]
        unsafe Bit32(bool src)
            => State  = *((byte*)(&src));

        [MethodImpl(Inline)]
        Bit32(uint src)
            => State = src;

        [MethodImpl(Inline), Op]
        public char ToChar()
            => (char)(State + 48);

        [MethodImpl(Inline), Op]
        public static Bit32 Parse(char c)
            => c == One;

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static T generic<T>(Bit32 src)
            => @as<Bit32,T>(src);

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Bit32 specific<T>(T src)
            => @as<T,Bit32>(src);

        /// <summary>
        /// Constructs a disabled bit
        /// </summary>
        public static Bit32 Off
        {
             [MethodImpl(Inline)]
             get  => new Bit32(0u);
        }

        /// <summary>
        /// Constructs an enabled bit
        /// </summary>
        public static Bit32 On
        {
             [MethodImpl(Inline)]
             get  => new Bit32(1u);
        }

        public static Bit32[] B01
        {
            [MethodImpl(Inline)]
            get => new Bit32[]{Off,On};
        }

        [MethodImpl(Inline), Op]
        public unsafe static Bit32 From(bool src)
        {
            uint state = *((byte*)(&src));
            return new Bit32(state);
        }

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(sbyte src, byte pos)
            => new Bit32((src & (1 << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(byte src, int pos)
            => Wrap(((uint)src >> pos) & 1);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(short src, int pos)
            => new Bit32((src & (1 << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(ushort src, int pos)
            => Wrap(((uint)src >> pos) & 1);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(int src, int pos)
            => new Bit32((src & (1 << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(long src, int pos)
            => new Bit32((src & (1L << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(uint src, int pos)
            => Wrap((src >> pos) & 1);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), Op]
        public static Bit32 test(ulong src, int pos)
            => Wrap((uint)((src >> pos) & 1));

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static sbyte set(sbyte src, byte pos, Bit32 state)
        {
            var c = ~(sbyte)state + 1;
            src ^= (sbyte)((c ^ src) & (1 << pos));
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static byte set(byte src, byte pos, Bit32 state)
        {
            var c = ~(byte)state + 1;
            src ^= (byte)((c ^ src) & (1 << pos));
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static short set(short src, byte pos, Bit32 state)
        {
            var c = ~(short)state + 1;
            src ^= (short)((c ^ src) & (1 << pos));
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static ushort set(ushort src, byte pos, Bit32 state)
        {
            var c = ~(ushort)state + 1;
            src ^= (ushort)((c ^ src) & (1 << pos));
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static int set(int src, byte pos, Bit32 state)
        {
            var c = ~(int)state + 1;
            src ^= (c ^ src) & (1 << pos);
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static uint set(uint src, byte pos, Bit32 state)
        {
            var c = ~(uint)state + 1u;
            src ^= (c ^ src) & (1u << pos);
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="pos">The source bit index</param>
        /// <param name="state">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static long set(long src, byte pos, Bit32 state)
        {
            var c = ~(long)state + 1L;
            src ^= (c ^ src) & (1L << pos);
            return src;
        }

        /// <summary>
        /// Aligns an index-identified source bit with with a suplied state
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="index">The source bit index</param>
        /// <param name="value">The state with which to align a source bit</param>
        [MethodImpl(Inline), Op]
        public static ulong set(ulong src, byte pos, Bit32 state)
        {
            var c = ~(ulong)state + 1ul;
            src ^= (c ^ src) & (1ul << pos);
            return src;
        }

        /// <summary>
        /// The identity function
        /// </summary>
        /// <param name="b">The source bit</param>
        [MethodImpl(Inline), Op]
        public static Bit32 identity(Bit32 b)
            => b;

        /// <summary>
        /// Computes c = a & b
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline), Op]
        public static Bit32 and(Bit32 a, Bit32 b)
            => Wrap(a.State & b.State);

        /// <summary>
        /// Computes c = a | b
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline), Op]
        public static Bit32 or(Bit32 a, Bit32 b)
            => Wrap(a.State | b.State);

        /// <summary>
        /// Computes c = a ^ b
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline), Op]
        public static Bit32 xor(Bit32 a, Bit32 b)
            => Wrap(a.State ^ b.State);

        /// <summary>
        /// Computes c := ~a = !a
        /// </summary>
        /// <param name="a">The source bit</param>
        [MethodImpl(Inline), Op]
        public static Bit32 not(Bit32 a)
            => SafeWrap(~a.State);

        /// <summary>
        /// Computes c := ~ (a & b)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static Bit32 nand(Bit32 a, Bit32 b)
            => SafeWrap(~(a.State & b.State));

        /// <summary>
        /// Computes c := ~ (a | b)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Logical_biconditional</remarks>
        [MethodImpl(Inline), Op]
        public static Bit32 nor(Bit32 a, Bit32 b)
            => SafeWrap(~(a.State | b.State));

        /// <summary>
        /// Computes c := ~ (a ^ b)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Logical_biconditional</remarks>
        [MethodImpl(Inline), Op]
        public static Bit32 xnor(Bit32 a, Bit32 b)
            => SafeWrap(~(a.State ^ b.State));

        /// <summary>
        /// Computes c := a -> b := a | ~b
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <remarks>See https://en.wikipedia.org/wiki/Material_conditional</remarks>
        [MethodImpl(Inline), Op]
        public static Bit32 impl(Bit32 a, Bit32 b)
            => or(a,  not(b));

        /// <summary>
        /// Computes the nonimplication c := a < -- b := ~(a | ~b) = ~a & b
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static Bit32 nonimpl(Bit32 a, Bit32 b)
            => and(not(a),  b);

        /// <summary>
        /// Computes the converse implication c := ~a | b
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static Bit32 cimpl(Bit32 a, Bit32 b)
            => or(not(a),  b);

        /// <summary>
        /// Computes the converse nonimplication c := a & ~b
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static Bit32 cnonimpl(Bit32 a, Bit32 b)
            => and(a, not(b));

        /// <summary>
        /// Computes the ternary select s := a ? b : c = (a & b) | (~a & c)
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        [MethodImpl(Inline), Op]
        public static Bit32 select(Bit32 a, Bit32 b, Bit32 c)
            => SafeWrap((a.State & b.State) | (~a.State & c.State));

        /// <summary>
        /// Returns true if the bit is enabled, false otherwise
        /// </summary>
        /// <param name="b">The bit to test</param>
        [MethodImpl(Inline), Op]
        public static bool operator true(Bit32 b)
            => b.State != 0;

        /// <summary>
        /// Returns false if the bit is disabled, true otherwise
        /// </summary>
        /// <param name="b">The bit to test</param>
        [MethodImpl(Inline), Op]
        public static bool operator false(Bit32 b)
            => b.State == 0;

        /// <summary>
        /// Implicitly constructs a bit from a bool
        /// </summary>
        /// <param name="state">The state of the bit to construct</param>
        [MethodImpl(Inline), Op]
        public static implicit operator Bit32(bool state)
            => new Bit32(state);

        /// <summary>
        /// Implicitly constructs a bool from a bit
        /// </summary>
        /// <param name="state">The state of the bit to construct</param>
        [MethodImpl(Inline), Op]
        public static implicit operator bool(Bit32 src)
            => src.State != 0;

        /// <summary>
        /// Defines an explicit bit -> byte conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator byte(Bit32 src)
            => (byte)src.State;

        /// <summary>
        /// Defines an explicit bit -> byte conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator sbyte(Bit32 src)
            => (sbyte)src.State;

        /// <summary>
        /// Defines an explicit byte -> bit conversion
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static explicit operator Bit32(byte src)
            => SafeWrap(src);

        /// <summary>
        /// Defines an explicit bit -> ushort conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator ushort(Bit32 src)
            => (ushort)src.State;

        /// <summary>
        /// Defines an explicit bit -> ushort conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator short(Bit32 src)
            => (short)src.State;

        /// <summary>
        /// Defines an explicit ushort -> bit conversion
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static explicit operator Bit32(ushort src)
            => SafeWrap(src);

        /// <summary>
        /// Defines an explicit bit -> int conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator int(Bit32 src)
            => (int)src.State;

        /// <summary>
        /// Defines an *implicit* int -> bit conversion to aid sanity retention
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static implicit operator Bit32(int src)
            => SafeWrap(src);

        /// <summary>
        /// Defines an explicit bit -> uint conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator uint(Bit32 src)
            => src.State;

        /// <summary>
        /// Defines an explicit bit -> long conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator long(Bit32 src)
            => src.State;

        /// <summary>
        /// Defines an explicit bit -> float conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator float(Bit32 src)
            => src.State;

        /// <summary>
        /// Defines an explicit bit -> double conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator double(Bit32 src)
            => src.State;

        /// <summary>
        /// Defines an explicit uint -> bit conversion
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static explicit operator Bit32(uint src)
            => SafeWrap(src);

        /// <summary>
        /// Defines an explicit bit -> ulong conversion
        /// </summary>
        /// <param name="src">The source bit</param>
        [MethodImpl(Inline), Op]
        public static explicit operator ulong(Bit32 src)
            => src.State;

        [MethodImpl(Inline), Op]
        public static implicit operator Bit32(BitState src)
            => new Bit32((byte)src);

        [MethodImpl(Inline), Op]
        public static implicit operator BitState(Bit32 src)
            => (BitState)(byte)src;

        [MethodImpl(Inline), Op]
        public static implicit operator bit(Bit32 src)
            => new bit((bool)src);

        [MethodImpl(Inline), Op]
        public static implicit operator Bit32(bit src)
            => new Bit32((bool)src);

        /// <summary>
        /// Defines an explicit ulong -> bit conversion
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Op]
        public static explicit operator Bit32(ulong src)
            => SafeWrap(src);

        /// <summary>
        /// Combines the states of the source bits
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline)]
        public static Bit32 operator + (Bit32 a, Bit32 b)
            => Wrap(a.State ^ b.State);

        /// <summary>
        /// Computes the bitwise AND between the operands
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline)]
        public static Bit32 operator & (Bit32 a, Bit32 b)
            => and(a,b);

        /// <summary>
        /// Computes the bitwise OR between the operands
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline)]
        public static Bit32 operator | (Bit32 a, Bit32 b)
            => or(a,b);

        /// <summary>
        /// Computes the bitwise XOR between the operands
        /// </summary>
        /// <param name="a">The left bit</param>
        /// <param name="b">The right bit</param>
        [MethodImpl(Inline)]
        public static Bit32 operator ^ (Bit32 a, Bit32 b)
            => xor(a,b);

        /// <summary>
        /// Inverts the state of the source bit
        /// </summary>
        /// <param name="a">The source bit</param>
        [MethodImpl(Inline)]
        public static Bit32 operator ~(Bit32 a)
            => not(a);

        /// <summary>
        /// Inverts the state of the source bit
        /// </summary>
        /// <param name="a">The source bit</param>
        [MethodImpl(Inline)]
        public static Bit32 operator !(Bit32 a)
            => not(a);

        [MethodImpl(Inline)]
        public static bool operator ==(Bit32 a, Bit32 b)
            => a.State == b.State;

        [MethodImpl(Inline)]
        public static bool operator !=(Bit32 a, Bit32 b)
            => a.State != b.State;

        [MethodImpl(Inline), Op]
        public bool Equals(Bit32 b)
            => State == b.State;

        public override bool Equals(object b)
            => b is Bit32 x && Equals(x);

        public override int GetHashCode()
            => (int)State;

        public string Format()
            => State.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline), Op]
        static Bit32 Wrap(uint state)
            => new Bit32(state);

        [MethodImpl(Inline), Op]
        static Bit32 SafeWrap(byte state)
            => new Bit32((uint)state & 1);

        [MethodImpl(Inline), Op]
        static Bit32 SafeWrap(ushort state)
            => new Bit32((uint)state & 1);

        [MethodImpl(Inline), Op]
        static Bit32 SafeWrap(uint state)
            => new Bit32(state & 1);

        [MethodImpl(Inline), Op]
        static Bit32 SafeWrap(int state)
            => new Bit32((uint)state & 1);

        [MethodImpl(Inline), Op]
        static Bit32 SafeWrap(ulong state)
            => new Bit32((uint)state & 1);
    }
}