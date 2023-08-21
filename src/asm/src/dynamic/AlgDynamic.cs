//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static AlgDynamic.CalcBytes;
using static ApiClasses;

using C = AlgDynamic.CalcBytes;
using I = AlgDynamic.OpIndex;
using K = ApiClasses;

public class AlgDynamic
{
    [ApiHost]
    public readonly struct CSlots
    {
        [Op]
        public static byte exec(byte a, byte b)
        {
            var s0 = new Slots_n16x8x8x8();
            var s1 = new Slots_n16x8x8x8();
            var x = s0.Slot0(a,b);
            var y = s1.Slot0(a,b);
            var z = s0.Slot1(x,y);
            x = s1.Slot1(x,y);
            y = s0.Slot2(z,y);
            x = s0.Slot3(x,y);
            y = s1.Slot4(z,y);
            x = s0.Slot5(x,y);
            y = s1.Slot6(z,y);
            x = s0.Slot7(x,y);
            y = s1.Slot8(z,y);
            x = s0.Slot9(x,y);
            y = s1.SlotA(z,y);
            x = s0.SlotB(x,y);
            y = s1.SlotC(z,y);
            x = s0.SlotD(x,y);
            y = s1.SlotE(z,y);
            z = s0.SlotF(z, s1.SlotF(z,b));
            return z;
        }

        [ApiComplete]
        public readonly struct Slots_n16x8x8x8
        {
            [Op]
            public static byte exec1(byte a, byte b)
            {
                var s0 = new Slots_n16x8x8x8();
                var s1 = new Slots_n16x8x8x8();
                var x = s0.Slot0(a,b);
                var y = s0.Slot1(x,b);
                var z = s0.Slot2(y,a);
                y = s0.Slot3(z,y);
                x = s0.Slot4(x,y);
                x = s0.Slot5(x,z);
                x = s0.Slot6(x,y);
                x = s0.Slot7(x,y);
                x = s0.Slot8(x,z);
                x = s0.Slot9(x,y);
                x = s0.SlotA(x,y);
                x = s0.SlotB(x,y);
                x = s0.SlotC(x,z);
                x = s0.SlotD(y,x);
                x = s0.SlotE(x,y);
                z = s0.SlotF(z,b);
                return z;
            }

            [MethodImpl(NotInline)]
            public byte Slot0(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot1(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot2(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot3(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot4(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot5(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot6(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot7(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot8(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte Slot9(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte SlotA(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte SlotB(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte SlotC(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte SlotD(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte SlotE(byte a, byte b)
                => filler(a,b);

            [MethodImpl(NotInline)]
            public byte SlotF(byte a, byte b)
                => filler(a,b);

            [MethodImpl(Inline)]
            static byte filler(byte a, byte b)
            {
                var x = Bytes.add(a, b);
                var y = Bytes.xor(x, b);
                var z = Bytes.xnor(y,a);
                return Bytes.cnonimpl(x,z);
            }
        }
    }
        
    internal readonly struct CalcBytes
    {
        /// <summary>
        /// X86-executable code obtained by disassembling <see cref="eval(Add, byte, byte)"/>
        /// </summary>
        public static ReadOnlySpan<byte> add_ᐤ8iㆍ8iᐤ
            => new byte[20]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x0f,0xbe,0xc1,0x48,0x0f,0xbe,0xd2,0x03,0xc2,0x48,0x0f,0xbe,0xc0,0xc3};

        /// <summary>
        /// X86-executable code obtained by disassembling <see cref="eval(Sub, byte, byte)"/>
        /// </summary>
        public static ReadOnlySpan<byte> sub_ᐤ8uㆍ8uᐤ
            => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x2b,0xc2,0x0f,0xb6,0xc0,0xc3};

        /// <summary>
        /// X86-executable code obtained by disassembling <see cref="eval(Mul, byte, byte)"/>
        /// </summary>
        public static ReadOnlySpan<byte> mul_ᐤ8uㆍ8uᐤ
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x0f,0xaf,0xc2,0x0f,0xb6,0xc0,0xc3};

        /// <summary>
        /// X86-executable code obtained by disassembling <see cref="eval(Div, byte, byte)"/>
        /// </summary>
        public static ReadOnlySpan<byte> div_ᐤ8uㆍ8uᐤ
            => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xca,0x99,0xf7,0xf9,0x0f,0xb6,0xc0,0xc3};

        /// <summary>
        /// X86-executable code obtained by disassembling <see cref="eval(BLK.And, byte, byte)"/>
        /// </summary>
        public static ReadOnlySpan<byte> and_ᐤ8uㆍ8uᐤ
            => new byte[17]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x23,0xc2,0x0f,0xb6,0xc0,0xc3};
    }

    public static void runA(Action<string> emitter)
    {
        var src = dynops();
        var count = src.Count;
        var buffer = alloc<MsilCompilation>(count);
        ref var dst = ref first(buffer);
        for(var i=0; i<count; i++)
        {
            ref readonly var op = ref src[i];
            ref var result = ref seek(dst,i);
            result = ClrDynamic.compilation(op.Definition);
            emitter(string.Format("{0}: {1}", result.EntryPoint, result.Msil.Encoded.Format()));
        }
    }

    public static void runB(Action<string> emitter)
    {
        var name = nameof(mul_8u_8u_8u);
        var code = mul_8u_8u_8u;
        var dynop = BinaryOpDynamics.dynop<byte>(name, code);
        var fx = dynop.Delegate;
        var il = ClrDynamic.compilation(dynop.Definition);
        emitter(string.Format("{0}: {1}", il.EntryPoint, il.Msil.Encoded.Format()));
        for(byte i=0; i<20; i++)
        {
            var a = i;
            var b = (byte)(a*2);
            var c = fx(a,b);
            emitter(string.Format("{0}({1},{2})={3}", name, a, b, c));
        }
    }

    public static void runC(Action<string> emitter)
    {
        compute();
        var dst = text.buffer();
        run(dst);
        emitter(dst.Emit());
    }

    static ReadOnlySpan<byte> mul_8u_8u_8u
        => new byte[18]{0x0f,0x1f,0x44,0x00,0x00,0x0f,0xb6,0xc1,0x0f,0xb6,0xd2,0x0f,0xaf,0xc2,0x0f,0xb6,0xc0,0xc3};

    public static BinaryOperators<T> index<T>()
        => new (new BinaryOp<T>[256]);

    public static BinaryOperators<byte> arithmetic()
    {
        var dst = index<byte>();
        dst[I.Add] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.add_ᐤ8iㆍ8iᐤ)), C.add_ᐤ8iㆍ8iᐤ);
        dst[I.Sub] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.sub_ᐤ8uㆍ8uᐤ)), C.sub_ᐤ8uㆍ8uᐤ);
        dst[I.Mul] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.mul_ᐤ8uㆍ8uᐤ)), C.mul_ᐤ8uㆍ8uᐤ);
        dst[I.Div] = BinaryOpDynamics.create<byte>(OpIdentity.define(nameof(C.div_ᐤ8uㆍ8uᐤ)), C.div_ᐤ8uㆍ8uᐤ);
        return dst;
    }

    public static Index<DynamicOp<BinaryOp<byte>>> dynops()
    {
        var dst = alloc<DynamicOp<BinaryOp<byte>>>(4);
        dst[0] = BinaryOpDynamics.dynop<byte>(nameof(C.add_ᐤ8iㆍ8iᐤ), C.add_ᐤ8iㆍ8iᐤ);
        dst[1] = BinaryOpDynamics.dynop<byte>(nameof(C.sub_ᐤ8uㆍ8uᐤ), C.sub_ᐤ8uㆍ8uᐤ);
        dst[2] = BinaryOpDynamics.dynop<byte>(nameof(C.mul_ᐤ8uㆍ8uᐤ), C.mul_ᐤ8uㆍ8uᐤ);
        dst[3] = BinaryOpDynamics.dynop<byte>(nameof(C.div_ᐤ8uㆍ8uᐤ), C.div_ᐤ8uㆍ8uᐤ);
        return dst;
    }

    public ref struct BinaryOperators<T>
    {
        readonly Span<BinaryOp<T>> Operators;

        byte Offset;

        public BinaryOperators(Span<BinaryOp<T>> src)
        {
            Operators = src;
            Offset = 0;
        }

        public ref BinaryOp<T> this[I index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Operators,(byte)index);
        }
    }

    public enum OpIndex : byte
    {
        Add = 0,

        Sub = 1,

        Mul = 2,

        Div = 3,

        And = 4,
    }

    public readonly struct Slots
    {
        [Size(20), MethodImpl(NotInline)]
        public static byte add(byte x, byte y)
            => (byte)(x+y);

        [Size(17), MethodImpl(NotInline)]
        public static byte sub(byte x, byte y)
            => (byte)(x-y);

        [Size(18), MethodImpl(NotInline)]
        public static byte mul(byte x, byte y)
            => (byte)(x*y);

        [Size(18), MethodImpl(NotInline)]
        public static byte div(byte x, byte y)
            => (byte)(x/y);

        [Size(17), MethodImpl(NotInline)]
        public static byte and(byte x, byte y)
            => (byte)(x&y);
    }

    public readonly struct Native
    {
        /// <summary>
        /// Executes the code defined by <see cref="mul_ᐤ8uㆍ8uᐤ" over caller-supplied operands/>
        /// </summary>
        /// <param name="f">The function selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        public static byte eval(Mul f, byte x, byte y)
            => BinaryOpDynamics.eval("mul", mul_ᐤ8uㆍ8uᐤ, x,y);

        /// <summary>
        /// Executes the code defined by <see cref="sub_ᐤ8uㆍ8uᐤ" over caller-supplied operands/>
        /// </summary>
        /// <param name="f">The function selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        public static byte eval(Sub f, byte x, byte y)
            => BinaryOpDynamics.eval("sub", sub_ᐤ8uㆍ8uᐤ, x, y );

        /// <summary>
        /// Executes the code defined by <see cref="and_ᐤ8uㆍ8uᐤ" over caller-supplied operands/>
        /// </summary>
        /// <param name="f">The function selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        public static byte eval(And f, byte x, byte y)
            => BinaryOpDynamics.eval("and", and_ᐤ8uㆍ8uᐤ, x, y);
    }

    [ApiHost("calc.managed")]
    public readonly struct Managed
    {
        /// <summary>
        /// Computes the sum of two unsigned 8-bit integers
        /// </summary>
        /// <param name="f">The operation selector</param>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static byte eval(Add f, byte x, byte y)
            => (byte)(x+y);

        /// <summary>
        /// Computes the difference between two unsigned 8-bit integers
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static byte eval(Sub f, byte x, byte y)
            => (byte)(x-y);

        /// <summary>
        /// Computes the product of two unsigned 8-bit integers
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static byte eval(Mul f, byte x, byte y)
            => (byte)(x*y);

        /// <summary>
        /// Computes the quotient between two unsigned 8-bit integers
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static byte eval(Div f, byte x, byte y)
            => (byte)(x/y);

        /// <summary>
        /// Computes the bitwise and between two unsigned 8-bit integers
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static byte eval(And f, byte x, byte y)
            => (byte)(x&y);
    }

    void Display1()
    {
        var x = ScalarCast.uint8(4);
        var y = ScalarCast.uint8(16);
        var f = K.mul();
        var expect = Managed.eval(f, x, y);
        var actual = Native.eval(f, x, y);
        var message = describe(f, x,y, expect, actual);
        term.print(message);
    }

    void Display2()
    {
        var slots = ClrDynamic.slots(typeof(Slots));
        for(var i=0; i<slots.Length; i++)
        {
            ref readonly var slot = ref slots[i];
            term.print(slot);
        }
    }

    public static string apply<K,T>(K k, T x, T y)
        where K : IApiClass
            => $"{k.Format()}({x},{y})";

    public static string success<K,T>(K k, T x, T y, T result)
        where K : IApiClass
            => $"{k.Format()}({x},{y}) := {result}";

    public static string failure<K,T>(K k, T x, T y, T expect, T actual)
        where K : IApiClass
            => $"{apply(k,x,y)} := {actual} != {expect}";

    public static string describe<K,T>(K k, T x, T y, T result)
        where K : IApiClass
        where T : IEquatable<T>
            => $"{apply(k,x,y)} = {result}";

    public static string describe<K,T>(K k, T x, T y, T expect, T actual)
        where K : IApiClass
        where T : IEquatable<T>
            => expect.Equals(actual) ? success(k, x, y, actual) : failure(k, x, y, expect, actual);

    public static byte compute()
    {
        var ops = arithmetic();
        byte a = 1;
        byte b = 2;
        byte c = 0;
        byte d = 0;
        byte e = 0;
        for(byte i=0; i<50; i++)
        {
            c = ops[I.Add](a,i);
            d = ops[I.Mul](b,i);
            e = ops[I.Add](c,d);
            term.print($"i = {i} => e = {e}");

        }
        return e;
    }

    [MethodImpl(Inline),Op]
    public static byte compute(BinaryOperators<byte> ops, byte a, byte b)
    {
        var c = ops[I.Add](a,b);
        var d = ops[I.Mul](a,c);
        var e = ops[I.Sub](d,a);
        return ops[I.Add](e,b);
    }

    [Op]
    public static void run(Span<string> dst, ref byte offset)
    {
        var slots = ClrDynamic.slots<OpIndex>(typeof(Slots));
        ref readonly var add = ref slots[OpIndex.Add];
        ref readonly var sub = ref slots[OpIndex.Sub];
        ref readonly var mul = ref slots[OpIndex.Mul];
        ref readonly var div = ref slots[OpIndex.Div];

        var mulCode = CalcBytes.mul_ᐤ8uㆍ8uᐤ;
        var divCode = CalcBytes.div_ᐤ8uㆍ8uᐤ;
        var size = mulCode.Length;

        var x = ScalarCast.uint8(4);
        var y = ScalarCast.uint8(4);

        ref var mulRef = ref mul.Address.Ref<byte>();
        for(var i=0u; i<size; i++)
            seek(mulRef, i) = skip(divCode,i);

        var z1 = Slots.mul(x,y);
        seek(dst, offset++) = (describe(K.mul(), x,y, z1));

        ref var divRef = ref div.Address.Ref<byte>();
        for(var i=0; i<size; i++)
            seek(divRef, i) = skip(mulCode,i);

        var z2 = Slots.div(x,y);
        seek(dst, offset++) = describe(K.div(), x,y, z2);
    }

    [Op]
    public static void run(ITextBuffer dst)
    {
        var slots = ClrDynamic.slots<OpIndex>(typeof(Slots));
        ref readonly var add = ref slots[OpIndex.Add];
        ref readonly var sub = ref slots[OpIndex.Sub];
        ref readonly var mul = ref slots[OpIndex.Mul];
        ref readonly var div = ref slots[OpIndex.Div];

        var mulCode = CalcBytes.mul_ᐤ8uㆍ8uᐤ;
        var divCode = CalcBytes.div_ᐤ8uㆍ8uᐤ;
        var size = mulCode.Length;

        var x = ScalarCast.uint8(4);
        var y = ScalarCast.uint8(4);

        ref var mulRef = ref mul.Address.Ref<byte>();
        for(var i=0u; i<size; i++)
            seek(mulRef, i) = skip(divCode,i);

        var z1 = Slots.mul(x,y);
        dst.AppendLine((describe(K.mul(), x,y, z1)));

        ref var divRef = ref div.Address.Ref<byte>();
        for(var i=0; i<size; i++)
            seek(divRef, i) = skip(mulCode,i);

        var z2 = Slots.div(x,y);
        dst.AppendLine(describe(K.div(), x,y, z2));
    }
}
