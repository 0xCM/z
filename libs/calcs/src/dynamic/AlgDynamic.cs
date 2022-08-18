//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static AlgDynamic.CalcBytes;
    using static ApiClasses;

    using I = AlgDynamic.OpIndex;
    using K = ApiClasses;

    public partial class AlgDynamic
    {
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
}