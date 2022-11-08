//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    using K = AsmOcTokenKind;
    using P = Pow2x32;

    partial class AsmCheckCmd
    {
       static ReadOnlySpan<byte> x7ffaa76f0ae0
            => new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x50,0x0f,0x24,0xa5,0xfa,0x7f,0x00,0x00,0x48,0xb8,0x30,0xdd,0x99,0xa6,0xfa,0x7f,0x00,0x00,0x48,0xff,0xe0,0};

        [CmdOp("asm/check/vfind")]
        Outcome CheckV(CmdArgs args)
        {
            const byte count = 32;
            const byte Target = 0x48;
            var input = cpu.vload(w256,x7ffaa76f0ae0);
            var mask = cpu.vindices(input, Target);
            var bits = recover<bit>(Cells.alloc(w256).Bytes);
            BitPack.unpack1x32x8(mask, bits);
            var buffer = ByteBlock32.Empty;
            var j=z8;
            for(byte i=0; i<count; i++)
            {
                if(skip(bits,i))
                    buffer[j++] = i;
            }

            var indices = slice(buffer.Bytes, 0, j);
            Require.equal(skip(indices,0), 5);
            Require.equal(skip(indices,1), 8);
            Require.equal(skip(indices,2), 18);
            Require.equal(skip(indices,3), 28);
            return true;
        }

        [CmdOp("check/seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = Seq.mul(a,b);
            Write(SeqProducts.format(c));
            return true;
        }

        public static Index<ushort> serialize(PointMapper<K,P> src)
        {
            var dst = alloc<ushort>(src.PointCount);
            serialize(src,dst);
            return dst;
        }

        [Op]
        public static uint serialize(PointMapper<K,P> src, Span<ushort> dst)
        {
            var points = src.Points;
            var count = points.Length;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                ref var t0 = ref @as<byte>(seek(dst,i));
                ref var t1 = ref @as<Log2x32>(seek(t0,1));
                t0 = u8(point.Left);
                t1 = Pow2.log(point.Right);
            }

            return 0;
        }

        [CmdOp("asm/stubs/check")]
        void CheckStubDispatch()
        {
            // var stubs = Jumps;
            // if(stubs.Create<ulong>(0))
            //     Write(stubs.EncodeDispatch(0).FormatHexData());

            var dispatcher = new X86Dispatcher(12);
            dispatcher.Create<ulong>(0);
            var encoded = dispatcher.Encode(0);
            Write(encoded.FormatHexData());
        }

        [Free]
        public interface ICalc64
        {
            ulong Add(ulong a, ulong b);

            ulong Sub(ulong a, ulong b);

            ulong Mul(ulong a, ulong b);

            ulong Mod(ulong a, ulong b);
        }

        public readonly struct Calc64 : ICalc64
        {
            [Op]
            public ulong Add(ulong a, ulong b)
                => math.add(a,b);

            [Op]
            public ulong Mod(ulong a, ulong b)
                => math.mod(a,b);

            [Op]
            public ulong Mul(ulong a, ulong b)
                => math.mul(a,b);

            [Op]
            public ulong Sub(ulong a, ulong b)
                => math.sub(a,b);
        }

        [CmdOp("asm/stubs/find")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            void Api()
            {
                using var symbols = Dispense.symbols();
                //var stubs = CodeCollector.LoadCaptured(symbols, ApiHostUri.from(typeof(cpu)));
                // foreach(var stub in stubs)
                // {

                // }
            }

            void Search()
            {
                //var stubs = CodeCollector.CollectLive(symbols,host);
                //Write(stubs.View, LiveMemberCode.RenderWidths);
                using var symbols = Dispense.symbols();
                Write(Clr.impl(typeof(Calc64),typeof(ICalc64)).Format());
            }

            Api();

            return true;
        }

        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;
        }

        [CmdOp("check/md/arrays")]
        unsafe Outcome CheckMdArrays(CmdArgs args)
        {
            var m = 0xF;
            var n = 0xA;
            var data = new ulong[m,n];
            for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                data[i,j] = (ulong)(i*j);


            fixed(ulong* pSrc = data)
            {
                MemoryAddress @base = pSrc;
                var pCurrent = pSrc;
                for(var i=0; i<m; i++)
                {
                    for(var j=0; j<n; j++)
                    {
                        MemoryAddress loc = pCurrent;
                        var a = *pCurrent++;
                        Require.equal(a, (ulong)(i*j));
                        Write(string.Format("{0} {1} {2}x{3}={4}", loc, loc - @base, i, j, a));
                    }
                }
            }

            var dst = Unsafe.As<TableInfo>(data);
            Write(string.Format("{0}={1}x{2}", dst.Count, dst.M, dst.N));

            return true;
        }

        ParserCache Parsers => new();

        [CmdOp("check/api/parsers")]
        Outcome CheckApiParsers(CmdArgs args)
        {
            var x = 32u;
            if(Parsers.Parse(x.ToString(), out uint dst))
            {
                Require.equal(x,dst);
            }
            return true;
        }

        [CmdOp("check/bitfields")]
        Outcome CheckBitFields(CmdArgs args)
        {
            var storage = ByteBlock32.Empty;
            var buffer = storage.Bytes;
            byte segwidth = 8;
            ReadOnlySpan<byte> indices = new byte[]{3,33,59,61,101,203};
            gbits.enable(buffer, indices);
            var segcount = buffer.Length;
            for(var i=z8; i<segcount; i++)
            {
                ref readonly var cell = ref skip(buffer,i);
                var offset = (byte)(i*segwidth);
                if(cell != 0)
                {
                    var seg = BitfieldSeg.define(cell, offset, segwidth);
                    Write(seg.Format());
                }
            }

            return true;
        }

        [CmdOp("check/expr/scopes")]
        Outcome TestScopes(CmdArgs args)
        {
            var result = Outcome.Success;

            ExprScope a = "a";

            Require.invariant(a.IsRoot);

            ExprScope b = "b";
            Require.invariant(b.IsRoot);

            var c = a + b;
            Require.equal(c, "a.b");

            var d = ExprScope.root("d");
            var e = c + d;
            Require.equal(e, "a.b.d");

            var fg = ExprScope.root("f") + ExprScope.root("g");
            var h = e + fg;
            Require.equal(h, "a.b.d.f.g");

            return result;
        }

        [CmdOp("check/lookups")]
        Outcome TestKeys(CmdArgs args)
        {
            var outcome = Outcome.Success;
            ushort rows = Pow2.T13;
            ushort cols = Pow2.T13;
            var keys = LookupTables.keys(rows,cols);
            var range = Intervals.closed(z16, (ushort)(rows - 1)).Partition();
            iter(range,i =>{
            for(var j=z16; j<cols; j++)
            {
                ref readonly var key = ref keys[i,j];
                LookupKey expect = (i,j);
                Require.invariant(expect.Equals(key));
            }
            },true);

            Status(string.Format("Verifified {0} lookup operations", rows*cols));

            return true;
        }

        [CmdOp("check/range")]
        Outcome CheckRange(CmdArgs args)
        {
            Span<byte> buffer = stackalloc byte[32];
            var emitter = text.buffer();
            points(new BitRange(0, 2), buffer,emitter);
            Write(emitter.Emit());
            points(new BitRange(5, 3), buffer,emitter);
            Write(emitter.Emit());
            points(new BitRange(6, 7), buffer,emitter);
            Write(emitter.Emit());
            points(new BitRange(1, 4), buffer,emitter);
            Write(emitter.Emit());
            return true;
        }

        static BitRange points(BitRange src, Span<byte> dst, ITextEmitter emitter)
        {
            var count = src.Values(dst,true);
            emitter.Append(src.Format());
            emitter.Append(Chars.LBrace);
            for(var i=0;i<count; i++)
            {
                if(i != 0)
                    emitter.Append(Chars.Comma);
                emitter.Append(skip(dst,i).ToString());
            }
            emitter.Append(Chars.RBrace);
            return src;
        }
    }
}