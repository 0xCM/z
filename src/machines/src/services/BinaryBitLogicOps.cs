//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static math;

    using K = BinaryBitLogicKind;

    [ApiHost]
    public readonly struct BinaryBitLogicOps
    {
        public static ReadOnlySpan<Eval> canonical(W1 w)
        {
            var src = inputs(w1);
            var dst = alloc<Eval>(64);
            eval(src, dst);
            return dst;
        }

        public static ReadOnlySpan<Eval> canonical(W1 w, ReadOnlySpan<Input> src)
        {
            var dst = alloc<Eval>(64);
            eval(src, dst);
            return dst;
        }

        public static ReadOnlySpan<Input> inputs(W1 w)
        {
            var m=0u;
            var count = 64;
            var dst = alloc<Input>(count);
            for(var i=0; i<16; i++)
            {
                var op = (K)i;
                for(var j=0; j<2; j++)
                {
                    var a = (bit)j;
                    for(var k=0; k<2; k++)
                    {
                        var b = (bit)k;
                        seek(dst, m++) = input(op, a, b);
                    }
                }
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static Input input(K kind, bit a, bit b)
            => new Input(kind,a,b);

        [MethodImpl(Inline)]
        public static void eval(ReadOnlySpan<Input> src, Span<Eval> dst)
        {
            var count = math.min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = eval(skip(src,i));
        }

        [Op]
        public static Eval eval(Input src)
        {
            var a = src.LeftInput;
            var b = src.RightInput;
            var x = (byte)a;
            var y = (byte)b;
            var f = (byte)src.Operator;
            switch(src.Operator)
            {
                case K.False:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.@false(a, b), TIx));
                case K.And:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.and(a, b), TIx));
                case K.CNonImpl:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.cnonimpl(a, b), TIx));
                case K.Left:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.left(a, b), TIx));
                case K.NonImpl:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.nonimpl(a, b), TIx));
                case K.Right:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.right(a, b), TIx));
                case K.Xor:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.xor(a, b), TIx));
                case K.Or:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.or(a, b), TIx));
                case K.Nor:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.nor(a, b), TIx));
                case K.Xnor:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.xnor(a,b), TIx));
                case K.RNot:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.rnot(a,b), TIx));
                case K.Impl:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.impl(a,b), TIx));
                case K.LNot:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.lnot(a,b), TIx));
                case K.CImpl:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.cimpl(a,b), TIx));
                case K.Nand:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.nand(a,b), TIx));
                case K.True:
                    return or(f, sll(x, LIx), sll(y, RIx), sll(bit.@true(a,b), TIx));
                default:
                    return default;
            }
        }

        public enum FormatOption : byte
        {
            Default,

            Functional,

            Bitstrings
        }

        public class OpFormatter
        {
            public static OpFormatter service()
                => new OpFormatter();

            static Symbols<K> OpSymbols;

            static OpFormatter()
            {
                OpSymbols = Symbols.index<K>();
            }

            public static string format(Eval src, FormatOption option = default)
            {
                Span<char> dst = stackalloc char[16];
                var i=0u;
                var length = Render(src, ref i, dst, option);
                return text.format(slice(dst,0,length));
            }

            public static string format(Input src, FormatOption option = default)
            {
                Span<char> dst = stackalloc char[16];
                var i=0u;
                var length = Render(src, ref i, dst, option);
                return text.format(slice(dst,0,length));
            }

            public static string bitstring(K src)
            {
                Span<char> dst = stackalloc char[4];
                BitRender.render4((byte)src, dst);
                return new string(dst);
            }

            static uint Functional(Eval src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                Functional(src.Input, ref i, dst);
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = Chars.Eq;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.Output;
                return i - i0;
            }

            static uint Functional(Input src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                text.copy(OpSymbols[src.Operator].Expr.Text, ref i, dst);
                seek(dst,i++) = Chars.LParen;
                seek(dst,i++) = src.LeftInput;
                seek(dst,i++) = Chars.Comma;
                seek(dst,i++) = src.RightInput;
                seek(dst,i++) = Chars.RParen;
                return i - i0;
            }

            static uint BitStrings(Input src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                text.copy(bitstring(src.Operator), ref i, dst);
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.LeftInput;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.RightInput;
                return i - i0;
            }

            static uint BitStrings(Eval src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                text.copy(bitstring(src.Operator), ref i, dst);
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.LeftInput;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.RightInput;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.Output;
                return i - i0;
            }

            static uint Render(Input src, ref uint i, Span<char> dst, FormatOption option = default)
            {
                switch(option)
                {
                    case FormatOption.Functional:
                        return Functional(src, ref i, dst);
                    case FormatOption.Bitstrings:
                        return BitStrings(src, ref i, dst);
                    default:
                        return BitStrings(src, ref i, dst);
                }
            }

            static uint Render(Eval src, ref uint i, Span<char> dst, FormatOption option = default)
            {
                switch(option)
                {
                    case FormatOption.Functional:
                        return Functional(src, ref i, dst);
                    case FormatOption.Bitstrings:
                        return BitStrings(src, ref i, dst);
                    default:
                        return BitStrings(src, ref i, dst);
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Input
        {
            readonly byte Storage;

            public K Operator
            {
                [MethodImpl(Inline)]
                get => (K)(0xF & Storage);
            }

            public bit LeftInput
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, LIx);
            }

            public bit RightInput
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, RIx);
            }

            [MethodImpl(Inline)]
            public Input(K f, bit x, bit y)
            {
                Storage = or((byte)f, sll((byte)x, LIx), sll((byte)y, RIx));
            }

            public string Format()
                => OpFormatter.format(this);

            public string Format(FormatOption option)
                => OpFormatter.format(this, option);

            public override string ToString()
                => Format();
        }

        const byte LIx = 4;

        const byte RIx = 5;

        const byte TIx = 6;

        /// <summary>
        /// c  | b |  a | 0000
        /// </summary>
        public readonly struct Eval
        {
            readonly byte Storage;

            [MethodImpl(Inline)]
            public Eval(byte data)
            {
                Storage = data;
            }

            public K Operator
            {
                [MethodImpl(Inline)]
                get => (K)(0xF & Storage);
            }

            public bit LeftInput
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, LIx);
            }

            public bit RightInput
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, RIx);
            }

            public Input Input
            {
                [MethodImpl(Inline)]
                get => new Input(Operator, LeftInput, RightInput);
            }

            public bit Output
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, TIx);
            }

            public string Format()
                => OpFormatter.format(this);

            public string Format(FormatOption option)
                => OpFormatter.format(this, option);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Eval(byte src)
                => new Eval(src);
        }
    }
}