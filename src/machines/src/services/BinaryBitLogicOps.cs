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
        public static ReadOnlySpan<OpEval> canonical(W1 w)
        {
            var src = inputs(w1);
            var dst = alloc<OpEval>(64);
            eval(src,dst);
            return dst;
        }

        public static ReadOnlySpan<OpEval> canonical(W1 w, ReadOnlySpan<OpInput> src)
        {
            var dst = alloc<OpEval>(64);
            eval(src,dst);
            return dst;
        }

        public static ReadOnlySpan<OpInput> inputs(W1 w)
        {
            var m=0u;
            var count = 64;
            var dst = alloc<OpInput>(count);
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
        public static OpInput input(K kind, bit a, bit b)
            => new OpInput(kind,a,b);

        [MethodImpl(Inline)]
        public static void eval(ReadOnlySpan<OpInput> src, Span<OpEval> dst)
        {
            var count = math.min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = eval(skip(src,i));
        }

        [Op]
        public static OpEval eval(OpInput src)
        {
            const byte AIx = LeftInputIndex;
            const byte BIx = RightInputIndex;
            const byte RIx = ResultIndex;
            var a = src.LeftInput;
            var b = src.RightInput;
            var x = (byte)a;
            var y = (byte)b;
            var f = (byte)src.Operator;
            switch(src.Operator)
            {
                case K.False:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.@false(a,b), RIx));
                case K.And:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.and(a,b), RIx));
                case K.CNonImpl:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.cnonimpl(a,b), RIx));
                case K.Left:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.left(a,b), RIx));
                case K.NonImpl:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.nonimpl(a,b), RIx));
                case K.Right:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.right(a,b), RIx));
                case K.Xor:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.xor(a,b), RIx));
                case K.Or:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.or(a,b), RIx));
                case K.Nor:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.nor(a,b), RIx));
                case K.Xnor:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.xnor(a,b), RIx));
                case K.RNot:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.rnot(a,b), RIx));
                case K.Impl:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.impl(a,b), RIx));
                case K.LNot:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.lnot(a,b), RIx));
                case K.CImpl:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.cimpl(a,b), RIx));
                case K.Nand:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.nand(a,b), RIx));
                case K.True:
                    return or(f, sll(x, AIx), sll(y, BIx), sll(bit.@true(a,b), RIx));
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

            Symbols<K> OpSymbols;

            public OpFormatter()
            {
                OpSymbols = Symbols.index<K>();
            }

            public string Format(OpEval src, FormatOption option = default)
            {
                Span<char> dst = stackalloc char[16];
                var i=0u;
                var length = Render(src, ref i, dst, option);
                return text.format(slice(dst,0,length));
            }

            public string Format(OpInput src, FormatOption option = default)
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

            uint Functional(OpEval src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                Functional(src.Input, ref i, dst);
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = Chars.Eq;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.Result;
                return i - i0;
            }

            uint Functional(OpInput src, ref uint i, Span<char> dst)
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

            uint BitStrings(OpInput src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                text.copy(bitstring(src.Operator), ref i, dst);
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.LeftInput;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.RightInput;
                return i - i0;
            }

            uint BitStrings(OpEval src, ref uint i, Span<char> dst)
            {
                var i0 = i;
                text.copy(bitstring(src.Operator), ref i, dst);
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.LeftInput;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.RightInput;
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = src.Result;
                return i - i0;
            }

            public uint Render(OpInput src, ref uint i, Span<char> dst, FormatOption option = default)
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

            public uint Render(OpEval src, ref uint i, Span<char> dst, FormatOption option = default)
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
        public readonly struct OpInput
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
                get => bit.test(Storage, LeftInputIndex);
            }

            public bit RightInput
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, RightInputIndex);
            }

            [MethodImpl(Inline)]
            public OpInput(K f, bit x, bit y)
            {
                Storage = or((byte)f, sll((byte)x, LeftInputIndex), sll((byte)y, RightInputIndex));
            }

            public string Format()
                => OpFormatter.service().Format(this);

            public string Format(FormatOption option)
                => OpFormatter.service().Format(this, option);

            public override string ToString()
                => Format();
        }

        const byte LeftInputIndex = 4;

        const byte RightInputIndex = 5;

        const byte ResultIndex = 6;

        /// <summary>
        /// c  | b |  a | 0000
        /// </summary>
        public readonly struct OpEval
        {
            readonly byte Storage;

            [MethodImpl(Inline)]
            public OpEval(byte data)
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
                get => bit.test(Storage, LeftInputIndex);
            }

            public bit RightInput
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, RightInputIndex);
            }

            public OpInput Input
            {
                [MethodImpl(Inline)]
                get => new OpInput(Operator, LeftInput,RightInput);
            }

            public bit Result
            {
                [MethodImpl(Inline)]
                get => bit.test(Storage, ResultIndex);
            }

            public string Format()
                => OpFormatter.service().Format(this);

            public string Format(FormatOption option)
                => OpFormatter.service().Format(this, option);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OpEval(byte src)
                => new OpEval(src);
        }
    }
}