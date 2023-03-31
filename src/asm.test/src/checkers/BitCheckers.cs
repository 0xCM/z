//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Char5;

    public class BitCheckers
    {        
        public static void run(IWfRuntime wf, bool pll = true)
        {
            var checkers = new BitCheckers(wf);
            checkers.Run(Checkers.target(wf.Channel), pll);
        }

        public void Run(IEventTarget log, bool pll)
        {
            Checkers.run(pll,GetType(), log,
                (nameof(CheckBitNumbers), CheckBitNumbers),
                (nameof(CheckBitReplication), CheckBitReplication),
                (nameof(CheckSegVars), CheckSegVars),
                (nameof(CheckBitfields), CheckBitfields),
                (nameof(CheckBv256), CheckBv256),
                (nameof(CheckPack64x1), CheckPack64x1),
                (nameof(CheckUnpack4x1), CheckUnpack4x1)
            );

        }

        IWfRuntime Wf;

        static Outcome outcome(string @case, string expect, string actual)
        {
            var match = actual.Equals(expect);
            return (match, match ? @case + ": Pass" : @case + string.Format(": Fail {0} != {1}", actual, expect));
        }

        static Union<T> union<T>(params T[] src)
            where T : IExpr
                => new Union<T>(src);

        public Outcome Case1()
        {
            const string Case = "Literal Union";
            const string Expect = "[l0:1 | l1:2 | l2:4]";
            var l0 = Literals.literal("l0", 1);
            var l1 = Literals.literal("l1", 2);
            var l2 = Literals.literal("l2", 4);
            var u = union(l0,l1,l2);
            return outcome(Case, u.Format(), Expect);
        }

        public BitCheckers(IWfRuntime wf)
        {
            Wf = wf;
        }


        static BitVector256<T> bv256<T>()
            where T : unmanaged
                => default;

        void CheckBitfields(IEventTarget log)
        {
            var checks = BitfieldChecks.create(Wf);
            checks.Run(log);
        }

        void CheckBv256(IEventTarget log)
        {
            var width = 256;
            var storage = ByteBlock32.Empty;
            var dst = recover<uint>(storage.Bytes);
            var src = bv256<byte>();

            Span<char> bitstring = stackalloc char[92];
            for(var i=0; i<width; i++)
                src.Enable((byte)i);

            src.Store(recover<byte>(dst));

            var j=0u;
            for(var i=0; i<dst.Length; i++)
            {
                j=0;
                var count = BitRender.render32x4(Chars.Space, skip(dst,i), ref j, bitstring);
                log.Deposit(Events.row(text.format(slice(bitstring,0,count))));
            }
        }

        void CheckBitReplication(IEventTarget log)
        {
            const byte PW = 4;

            const byte P0 = 0b0111;

            const byte E0 = P0 | P0 << PW;

            const ushort P1 = 0b0111;

            const ushort E1 = (ushort)E0 | (ushort)E0 << PW*2;

            const uint P2 = 0b0111;

            const uint E2 = (uint)E1 | (uint)E1 << PW*4;

            const ulong P3 = 0b0111;

            const ulong E3 = (ulong)E2 | (ulong)E2 << PW*8;

            var A0 = gbits.replicate(P0, 0, 3, 8/PW);
            var R0 = Require.equal(E0,A0);
            log.Deposit(Events.row(R0.FormatBits()));

            var A1 = gbits.replicate(P1, 0, 3, 16/PW);
            var R1 = Require.equal(E1,A1);
            log.Deposit(Events.row(R1.FormatBits()));

            var A2 = gbits.replicate(P2, 0, 3, 32/PW);
            var R2 = Require.equal(E2,A2);
            log.Deposit(Events.row(R2.FormatBits()));

            var A3 = gbits.replicate(P3, 0, 3, 64/PW);
            var R3 = Require.equal(E3,A3);
            log.Deposit(Events.row(R3.FormatBits()));
        }

        void CheckBitNumbers(IEventTarget log)
        {
            var dst = text.emitter();
            BitNumber.validate(n3, (byte)0b0000_0111, dst);
            BitNumber.validate(n6, (byte)0b0011_1000, dst);

            BitNumber.validate(n3, (ushort)0b0000_0111, dst);
            BitNumber.validate(n6, (ushort)0b0011_1000, dst);

            BitNumber.validate(n3, (uint)0b0000_0111, dst);
            BitNumber.validate(n6, (uint)0b0011_1000, dst);
            log.Deposit(Events.row(dst.Emit()));
        }

        void CheckSegVars(IEventTarget log)
        {
            var a = Code.A;
            var b = Code.B;
            var c = Code.C;
            var _ = Code.Underscore;
            var d = Code.D;

            var v0 = new SegVar(a, b, c, _, d);
            var v1 = new SegVar(Code.W, Code.R, Code.X, Code.B);
            log.Deposit(Events.row(v0.Format()));
            log.Deposit(Events.row(v1.Format()));

            var input = "ss_ii_bbbb";
            var v2 = SegVar.parse(input);
            var output = v2.Format();
            var result = Require.equal(input,output);
            log.Deposit(Events.row(result));
        }

        void CheckUnpack4x1(IEventTarget log)
        {
            const byte a0 = 0b1111;
            const byte a1 = 0b1110;
            const byte a2 = 0b1101;
            const byte a3 = 0b1011;
            const byte a4 = 0b0111;
            const byte RenderWidth = 64;
            const char sep = Chars.Space;
            var i = 0u;
            var count = 0u;
            var storage = 0u;
            var src = z8;
            var input = 0u;
            var output = 0u;
            var bitstring = EmptyString;

            var emitter = text.emitter();
            Span<char> dst = stackalloc char[RenderWidth];
            Span<bit> buffer = stackalloc bit[4];

            i=0;
            src = a0;
            input = src;
            count = BitRender.render32x4(sep, src, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendFormat("{0} => ", bitstring);

            i=0;
            storage = 0;
            buffer.Clear();
            BitPack.unpack4x1(src,buffer);
            output = BitPack.scalar<uint>(buffer);
            Require.equal(input,output);
            count = BitRender.render32x4(sep, storage, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendLine(bitstring);

            i=0;
            src = a1;
            input = src;
            count = BitRender.render32x4(sep, src, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendFormat("{0} => ", bitstring);

            i=0;
            storage = 0;
            buffer.Clear();
            BitPack.unpack4x1(src, buffer);
            output = BitPack.scalar<uint>(buffer);
            Require.equal(input,output);
            count = BitRender.render32x4(sep, storage, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendLine(bitstring);

            i=0;
            src = a2;
            input = src;
            count = BitRender.render32x4(sep, src, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendFormat("{0} => ", bitstring);

            i=0;
            storage = 0;
            buffer.Clear();
            BitPack.unpack4x1(src,buffer);
            output = BitPack.scalar<uint>(buffer);
            Require.equal(input,output);
            count = BitRender.render32x4(sep, storage, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendLine(bitstring);

            i=0;
            src = a3;
            input = src;
            count = BitRender.render32x4(sep, src, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendFormat("{0} => ", bitstring);

            i=0;
            storage = 0;
            buffer.Clear();
            BitPack.unpack4x1(src,buffer);
            output = BitPack.scalar<uint>(buffer);
            Require.equal(input,output);
            count = BitRender.render32x4(sep, storage, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendLine(bitstring);

            i=0;
            src = a4;
            input = src;
            count = BitRender.render32x4(sep, src, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendFormat("{0} => ", bitstring);

            i=0;
            storage = 0;
            buffer.Clear();
            BitPack.unpack4x1(src,buffer);
            output = BitPack.scalar<uint>(buffer);
            Require.equal(input,output);
            count = BitRender.render32x4(sep, storage, ref i, dst);
            bitstring = text.format(slice(dst, 0, count));
            emitter.AppendLine(bitstring);
            log.Deposit(Events.row(emitter.Emit()));
        }

        static void render(ulong src, W4 seg, ITextEmitter dst)
        {
            var storage = CharBlock128.Null;
            var buffer = storage.Data;
            var i=0u;
            var length = BitRender.render64x4(Chars.Space, src, ref i, buffer);
            dst.Append(slice(buffer,0,length));
        }

        void CheckPack64x1(BitVector64 input)
        {
            var storage = ByteBlock64.Empty;
            var unpacked = recover<bit>(storage.Bytes);
            BitPack.unpack64x1((ulong)input, unpacked);
            BitVector64 packed = Bitfields.pack64x1(unpacked);

            Require.equal(input, packed);
            for(var i=z8; i<64; i++)
                Require.equal(packed[i], skip(unpacked,i));
        }

        void CheckPack64x1(IEventTarget dst)
        {
            var a = 0xAAAAAAAAAAAAAAAAul;
            var emitter = text.emitter();
            CheckPack64x1(a);
            emitter.Append(a.FormatHex(uppercase:true));
            emitter.Append(" => ");
            render(a, w4, emitter);
            emitter.Append(Eol);

            var b = 0xFF00ul;
            CheckPack64x1(b);

            emitter.Append(((ulong)b).FormatHex(uppercase:true));
            emitter.Append(" => ");
            render(b, w4, emitter);
            emitter.Append(Eol);
            dst.Deposit(Events.row(emitter.Emit()));
        }
    }
}