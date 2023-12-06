//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static NativeSigs;

using gp32 = Asm.AsmRegTokens.Gp32Reg;

class AsmChecks : WfAppCmd<AsmChecks>
{
    class CheckNames
    {
        public const string CheckDirectives = "asm/check/directives";        

        public const string CheckExec = "asm/check/exec";

        public const string CheckVex = "asm/check/vex";
    }


    ReadOnlySpan<byte> Input => new byte[]{0x44, 0x01, 0x58,0x04};

    const string InputBitsA = "0100 0100 0000 0001 0101 1000 0000 0100";

    const uint InputBitsB = 0b0100_0100_0000_0001_0101_1000_0000_0100;

    static ReadOnlySpan<byte> x7ffaa76f0ae0
        => new byte[32]{0x0f,0x1f,0x44,0x00,0x00,0x48,0x8b,0xd1,0x48,0xb9,0x50,0x0f,0x24,0xa5,0xfa,0x7f,0x00,0x00,0x48,0xb8,0x30,0xdd,0x99,0xa6,0xfa,0x7f,0x00,0x00,0x48,0xff,0xe0,0};

    void RunCheck(string name)
    {
        var events = list<IEvent>();
        var checker = AsmChecker.create(Wf, GetType(), CmdRunner);
        checker.RunCheck(name, e => events.Add(e));
        iter(events, e => Channel.Raise(e));            
    }

    

    [CmdOp("asm/check/all")]
    void CheckAll()
    {
        RunCheck(CheckNames.CheckDirectives);
        RunCheck(CheckNames.CheckVex);
    }

    void CheckHex1()
    {
        var input = "66 66 2e 0f 1f 84 00 00 00 00 00 00";
        var buffer = ByteBlock16.Empty;
        var size = (byte)Hex.parse(input, buffer.Bytes).Require();
        var data = slice(buffer.Bytes,0,size);
        buffer[15] = size;
        var dst = new AsmHexCode(@as<ByteBlock16,Cell128>(buffer));
        Channel.Write(dst.Format());
    }

    [CmdOp("asm/check/tokens")]
    void CheckAsmTokens()
    {
        var result = AsmSigs.parse("adc r16, r16", out AsmSig sig);
        if(result.Fail)
            Channel.Error(result.Message);
        else
            Channel.Row(sig);
    }

    [CmdOp("hex/gen/blocks")]
    void GenHexStrings()
    {
        var dst = text.emitter();
        HexBlocks.render(dst);
        Channel.Row(dst.Emit());
    }

    [CmdOp("asm/check/res")]
    void CheckStringRes()
    {
        var resources = TextAssets.strings(typeof(AsciText)).View;
        iter(resources, r => Channel.Write(r.Format()));
    }

    [CmdOp("asm/check/bitparsers")]
    void CheckBitParser()
    {
        var input = "0110";
        BitParser.parse(text.slice(input,0,1), 1, out byte b0);
        Demand.eq(bit.Off, (bit)b0);
        BitParser.parse(text.slice(input,1,1), 1, out byte b1);
        Demand.eq(bit.On, (bit)b1);
        BitParser.parse(text.slice(input,2,1), 1, out byte b2);
        Demand.eq(bit.On, (bit)b2);
        BitParser.parse(text.slice(input,3,1), 1, out byte b3);
        Demand.eq(bit.Off, (bit)b3);
    }

    [CmdOp("asm/check/bitpacks")]
    Outcome CheckBitPacks()
    {
        var count = 0;
        var a0 = "0b10111";
        var a1 = (byte)0b10111;
        Span<bit> a2 = array<bit>(1,1,1,0,1);
        count = BitParser.parse(a0, out Span<bit> a3);
        if(count < 0)
            return false;

        Outcome result = a3.Length == a2.Length;
        if(result.Fail)
            return (false, string.Format("Unexpected length: {0} != {1}", a3.Length, a2.Length));

        for(var i=0; i<a3.Length; i++)
        {
            result = skip(a2, i) == skip(a3,i);
            if(result.Fail)
                break;
        }

        if(result.Fail)
            return (false, string.Format("Parsed bitstring value incorrect: {0} != {1}", a2.FormatPacked(), a3.FormatPacked()));

        var a4 = gpack.scalar<byte>(a3);
        result = (a4 == a1);
        if(result.Fail)
            return (false, string.Format("Incorrect scalar extracted: {0} != {1}", a4, a1));


        return result;
    }

    [CmdOp("asm/check/vfind")]
    Outcome CheckV(CmdArgs args)
    {
        const byte count = 32;
        const byte Target = 0x48;
        var input = vcpu.vload(w256,x7ffaa76f0ae0);
        var mask = vcpu.vindices(input, Target);
        var bits = recover<bit>(bytes(new Cell256<byte>()));
        SpanPack.unpack1x32x8(mask, bits);
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

    [CmdOp("asm/check/seqprod")]
    Outcome SeqProd(CmdArgs args)
    {
        var a = Intervals.closed(2u, 12u).Partition().ToSeq();
        var b = Intervals.closed(33u, 41u).Partition().ToSeq();
        var c = Seq.product(a,b);
        Channel.Write(c.Format());
        return true;
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

    [CmdOp("asm/check/impl")]
    void FindImplMaps(CmdArgs args)
    {
        var impl = Clr.impl(typeof(Calc64),typeof(ICalc64));
        Channel.Write(impl.Format());
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

        Channel.Status(string.Format("Verifified {0} lookup operations", rows*cols));

        return true;
    }

    [CmdOp("check/range")]
    Outcome CheckRange(CmdArgs args)
    {
        Span<byte> buffer = stackalloc byte[32];
        var emitter = text.buffer();
        points(new BitRange(0, 2), buffer,emitter);
        Channel.Write(emitter.Emit());
        points(new BitRange(5, 3), buffer,emitter);
        Channel.Write(emitter.Emit());
        points(new BitRange(6, 7), buffer,emitter);
        Channel.Write(emitter.Emit());
        points(new BitRange(1, 4), buffer,emitter);
        Channel.Write(emitter.Emit());
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
    [Op]
    public static uint bitstring(ReadOnlySpan<byte> src, Span<char> dst)
    {
        var i=0u;
        return BitRender.render8x4(src, ref i, dst);
    }

    // [CmdOp("asm/check/vmask")]
    // unsafe void TestVCpu()
    // {
    //     var v0 = vmask.veven<byte>(w128, n2, n2);
    //     var v0bits = v0.ToBitSpan();
    //     var options = BitFormatter.configure();
    //     options.BlockWidth = 8;
    //     Write(v0bits.Format(options));
    //     var v1 = vmask.veven<byte>(w256, n2, n2);
    //     var v1bits = v1.ToBitSpan();
    //     Write(v1bits.Format(options));
    // }

    [CmdOp("asm/check/bitstrings")]
    Outcome CheckBitstrings(CmdArgs args)
    {
        var block1 = CharBlock128.Null;
        var count = bitstring(Input, block1.Data);
        var chars = slice(block1.Data,0,count);
        var bits = text.format(chars);
        Channel.Write(InputBitsA);
        Channel.Write(bits);

        var block2 = CharBlock128.Null;
        count = bitstring(bytes(InputBitsB), block2.Data);
        bits = text.format(chars);
        Channel.Write(bits);

        var v = vpack.vunpack32x8(0xF0F0F0F0);
        Channel.Write(v.FormatBlockedBits(8));

        //CheckBitSpans();
        CheckBitFormatter();
        return true;
    }

    // void CheckBitSpans()
    // {
    //     var result = Outcome.Success;
    //     var options = BitFormat.Default.WithBlockWidth(8);
    //     var v1 = vmask.vmsb<byte>(w128, n8, n7);
    //     var b1 = v1.ToBitSpan();
    //     Write(b1.Format(options));
    // }

    void CheckBitFormatter()
    {
        var block = CharBlock128.Null;
        var buffer = block.Data;
        var input = 0b1100_0111_0101u;
        var n = 12u;
        var data = bytes(input);
        ref readonly var b0 = ref skip(data,0);
        ref readonly var b1 = ref skip(data,1);
        var i=0u;
        BitRender.render(b0, ref i, 8, buffer);
        seek(buffer,i++) = Chars.Underscore;
        BitRender.render(b1, ref i, 4, buffer);
        Channel.Write(block.Format());
    }

    [CmdOp("gen/hex-kind")]
    void GenHex8()
    {
        var dst = text.emitter();
        var indent = 4u;
        dst.IndentLineFormat(indent, "[SymSource(\"{0}\")]", "asm.opcodes");
        dst.IndentLineFormat(indent, "public enum {0} : byte", "Hex8Kind");
        dst.IndentLine(indent,"{");
        indent+=4;
        for(var i=0u; i<256; i++)
        {
            dst.IndentLineFormat(indent, "[Symbol(\"{0:X2}\")]", i);
            dst.IndentLineFormat(indent, "x{0:X2},", i);
            dst.AppendLine();
        }
        indent-=4;
        dst.IndentLine(indent,"}");
        Channel.Write(dst.Emit());
    }


    [CmdOp("asm/check/hexlines")]
    void CheckHexLines()
    {
        var lines = Lines.lines(DataSource);
        var count = lines.Length;
        for(var i=0; i<count; i++)
        {
            ref readonly var line = ref skip(lines,i);
            AsmBytes.parse(line, out var code);
            Channel.Write(code.Format());
        }
    }

    const string DataSource = @"66 2e 0f 1f 84 00 00 00 00 00
c4 e2 7d 24 01
c3
66 2e 0f 1f 84 00 00 00 00 00
c4 e2 7d 25 01
c3
66 2e 0f 1f 84 00 00 00 00 00
c5 f8 77
c5 f8 99 c8";

    [CmdOp("asm/check/sigs")]
    Outcome CheckSigs(CmdArgs args)
    {
        using var dispenser = Alloc.create();
        var specs = new Operand[3];
        seek(specs,0) = NativeSigs.ptr("op0", NativeSigs.u8());
        seek(specs,1) = NativeSigs.@const("op1", NativeSigs.i16());
        seek(specs,2) = NativeSigs.@out("op2", NativeSigs.u32());
        var sig = dispenser.Sig("funcs","f2", NativeSigs.i32(), specs);
        Channel.Write(sig.Format(SigFormatStyle.C));
        sig = dispenser.Sig("funcs","f1", NativeSigs.i32(), specs);

        ref readonly var ret = ref sig.Return;
        ref readonly var op0 = ref sig[0];
        ref readonly var op1 = ref sig[1];
        ref readonly var op2 = ref sig[2];
        ref readonly var name = ref sig.Name;
        ref readonly var scope = ref sig.Scope;

        var x0 = string.Format("{0}:{1}", op0.Name, op0.Type);
        var x1 = string.Format("{0}:{1}", op1.Name, op1.Type);
        var x2 = string.Format("{0}:{1}", op2.Name, op2.Type);
        Channel.Write(sig.Format(SigFormatStyle.C));

        return true;
    }

    [CmdOp("asm/check/cases")]
    Outcome EmitAsmCases(CmdArgs args)
    {
        var src = AsmCases.mov();
        Channel.TableEmit(src, AppDb.ApiTargets().Table<AsmEncodingCase>());
        return true;
    }

    [CmdOp("asm/check/bitfields")]
    void CheckBitFields()
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
                var seg = Bitfields.segment(cell, offset, segwidth);
                Channel.Write(seg.Format());
            }
        }            
    }


    public class TableInfo
    {
        public ulong Count;

        public uint M;

        public uint N;
    }

    [CmdOp("asm/check/arrays")]
    unsafe void CheckMdArrays(CmdArgs args)
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
                    Channel.Write(string.Format("{0} {1} {2}x{3}={4}", loc, loc - @base, i, j, a));
                }
            }
        }

        var dst = Unsafe.As<TableInfo>(data);
        Channel.Write(string.Format("{0}={1}x{2}", dst.Count, dst.M, dst.N));
    }


    [CmdOp("asm/check/blocks")]
    Outcome CheckBlockSize(CmdArgs args)
    {
        CheckTrimmedBlocks();
        CheckBlockPartitions();
        return true;
    }

    void CheckTrimmedBlocks()
    {
        var output = EmptyString;
        var input = ByteBlock4.Empty;

        input = 0xFF000000;
        output = TrimmedBlocks.trim(input).Format();

        input = 0xFF0000;
        output = TrimmedBlocks.trim(input).Format();

        input = 0xFF00;
        output = TrimmedBlocks.trim(input).Format();

        input = 0xFF;
        output = TrimmedBlocks.trim(input).Format();

        input = 0x0;
        output = TrimmedBlocks.trim(input).Format();
    }

    void CheckBlockPartitions()
    {
        var formatter = CsvTables.formatter<BlockPartition>();
        Channel.Write(formatter.FormatHeader());
        Channel.Write(formatter.Format(BlockPartition.calc(1024, 256, 11)));
        Channel.Write(formatter.Format(BlockPartition.calc(9591191, 256, 128)));
    }

    [CmdOp("asm/check/specs")]
    void CheckAsmSpecs()
    {
        const string Oc0 = "81 /4 id";
        const string Oc1 = "REX.W + 05 id";

        var asm0 = AsmSpecs.and(gp32.edx, 0xC1C1);
        Channel.Write($"{asm0}");

        var opcode = AsmOpCodeSpec.Empty;
        var result = SdmOpCodes.parse(Oc0, out opcode);
        Channel.Write($"{Oc0} -> {opcode}");
    }

    void CheckHex2()
    {
        const string Data = "38D10F9FC00FB6C0C338D10F97C00FB6C0C36639D10F9FC00FB6C0C36639D10F97C00FB6C0C339D10F9FC00FB6C0C339D10F97C0C34839D10F9FC00FB6C0C34839D10F97C00FB6C0C3";
        var result = Outcome.Success;
        var input = span(Data);
        var count = Data.Length;
        var dst = alloc<HexDigitValue>(count);
        result = Hex.map(Data,dst);
        if(result.Fail)
        {
            Channel.Row(result.Message, FlairKind.Error);
            return;
        }
        
        for(var i=0; i<count; i++)
        {
            if(Hex.upper(skip(dst,i)) != skip(input,i))
            {
                Channel.Row($"NotEqual", FlairKind.Error);
                // (false, "Not Equal");

            }
        }

        var buffer = alloc<byte>(count/2);
        var size = Digital.pack(dst,buffer);
        var output = buffer.FormatHex(HexOptionData.CompactHexOptions);
        Channel.Write(Require.equal(Data,output));
    }

    [CmdOp("asm/check/hex")]
    unsafe void CheckHex(CmdArgs args)
    {
        CheckHex1();
        CheckHex2();
        CheckAsmHexCode();
    }

    [CmdOp("asm/check/mem")]
    public void CheckAsmMem()
    {
        var result = true;
        var results = AsmCases.check(AsmCases.MemOpCases());
        for(var i=0; i<results.Count; i++)
        {
            ref readonly var r = ref results[i];
            Channel.Write(r.Format());
        }
    }

    [CmdOp("asm/check/exec")]
    void CheckCodeExec()
    {
        AsmCheckExec.run(Emitter);        
    }


    [CmdOp("asm/check/widths")]
    Outcome TestAsmWidths()
    {
        var result = bit.On;
        var pass = bit.Off;
        var test = default(AsmSizeCheck);
        var inputs = Symbols.index<NativeSizeCode>().Kinds;
        var count = inputs.Length;
        for(var i=0; i<count; i++)
        {
            ref readonly var input = ref skip(inputs,i);
            test.Input = input;
            pass = AsmSizeCheck.check(ref test);
            result &= pass;
            Channel.Write(test, pass ? FlairKind.Status : FlairKind.Error);
        }

        BitWidth w8 = 8;
        BitWidth w16 = 16;
        BitWidth w32 = 32;
        BitWidth w64 = 64;

        var sz8 = Sized.native(w8);
        var sz16 = Sized.native(w16);
        var sz32 = Sized.native(w32);
        var sz64 = Sized.native(w64);
        Channel.Write(sz8);
        Channel.Write(sz16);
        Channel.Write(sz32);
        Channel.Write(sz64);

        return (result, result ? "Pass" : "Fail");
    }

    void CheckDisp32_1()
    {
        const ulong Base = 0x7ffc56862280;
        const ushort Offset = 0x25;
        const uint Disp = 0xfc632176;
        const ulong IP = Base + Offset;
        var rip = AsmRel.rip(IP, 5);
        var call = AsmRel.call(rip, (Disp32)Disp);
        Channel.Write(call.Format());
    }

    void CheckDisp32_2()
    {
        const string Asm = "call 7fff92427890h";
        const string Encoding = "e8 25 e4 b2 5f";
        const byte InstSize = CallRel32.InstSize;
        const long Base = 0x7fff328f9430;
        const ushort Offset = 0x36;
        const long Source = Base + Offset;
        const long Target = 0x7fff92427890;
        const long RIP = Source + InstSize;
        const uint Disp = 0x5FB2E425;
        const string RenderPattern = "{0,-12}: {1}";
        var code = asm.asmhex(Encoding).Bytes;
        var disp1 = AsmRel.disp32(code);
        var disp2 = asm.disp(code,1, NativeSizeCode.W32);
        Require.equal(disp1,disp2);
        var target = (MemoryAddress)(RIP + disp1);
        if(target == Target && disp1 == Disp)
        {
            var dst = text.buffer();
            dst.AppendLineFormat(RenderPattern, nameof(Asm), Asm);
            dst.AppendLineFormat(RenderPattern, nameof(Encoding), Encoding);
            dst.AppendLineFormat(RenderPattern, nameof(Base), (MemoryAddress)Base);
            dst.AppendLineFormat(RenderPattern, nameof(Offset), (Address16)Offset);
            dst.AppendLineFormat(RenderPattern, nameof(Source), (MemoryAddress)Source);
            dst.AppendLineFormat(RenderPattern, nameof(RIP), (MemoryAddress)RIP);
            dst.AppendLineFormat(RenderPattern, nameof(Target), (MemoryAddress)Target);
            dst.AppendLineFormat(RenderPattern, "Disp",  disp1);

            Channel.Write(dst.Emit(), FlairKind.StatusData);
        }
        else
        {
            Channel.Error("Computed target did not match expected target");
        }
    }


    [CmdOp("asm/check/calls")]
    void CheckAsmCalls()
    {
        CheckDisp32_1();
        CheckDisp32_2();
    }

    void CheckAsmHexCode()
    {
        // 4080C416                add spl,22
        var buffer = span<char>(20);
        var input1 = "40 80 c4 16";
        var input2 = "4080C416";
        var input4 = "[0xc4,0xe2,0x7d,0x1a,0x01]";
        var expect4 = "c4 e2 7d 1a 01";
        Hex.parse64u(input2, out var input3);

        var code1 = asm.asmhex(input1);
        var code2 = asm.asmhex(input2);
        var code3 = asm.asmhex(input3);
        var code4 = asm.asmhex(input4);

        var text1 = code1.Format();
        var text2 = code2.Format();
        var text3 = code3.Format();
        Require.equal(code4.Format(),expect4);

        var check1 = CheckEquality(text1,text2);
        if(check1.Fail)
            Channel.Error(check1.Message);
        else
            Channel.Status(check1.Message);

        var check2 = CheckEquality(text1,text3);
        if(check2.Fail)
            Channel.Error(check2.Message);
        else
            Channel.Status(check2.Message);            
    }

    static Outcome CheckEquality(string a, string b)
    {
        var same = a.Equals(b);
        return (same, string.Format("{0} {1} {2}", a, same ? "==" : "!=", b));
    }

    [CmdOp("asm/check/shapes")]
    void CheckShapes()
    {
        var data = array<byte>(1,2,3,4,5,6);
        var actual = shape(data);
        var expect = shape(n4:1, n2:1);
        Require.equal(actual,expect);
    }

    [CmdOp("asm/check/regs")]
    void CheckRegstore()
    {
        var grid = RegGrid8x64.Empty;
        var regs = RegStore8x64.Empty;
        var names = recover<AsmRegName>(ByteBlock64.Empty.Bytes);
        var pairs = recover<AsmRegValue<ulong>>(ByteBlock128.Empty.Bytes);

        for(byte i=0; i<7; i++)
        {
            regs[i] = i;
            seek(names,i) = RegClasses.Mask.RegName(i);
            grid[i] = asm.regval(skip(names,i), regs[i]);
        }

        for(byte i=0; i<7; i++)
        {
            ref readonly var name = ref skip(names,i);
            ref readonly var value = ref regs[i];
            var output = grid[i].Format();
            Channel.Row(output);
        }

        var input = (ulong)PermLits.Perm16Identity;
        for(byte i=0; i<7; i++)
        {
            regs[i] = input << i*3;
            Channel.Row(asm.regval(skip(names,i), regs[i]));
        }           
    }

    [CmdOp("asm/check/parsers")]
    void CheckParsers()
    {
        CheckDigitParsers();
    }

    void CheckDigitParsers()
    {
        var input = "01001101";
        CheckDigitParser(base2);
        CheckDigitParser(base10);
        CheckDigitParser(base16);
    }

    void CheckDigitParser(Base10 @base)
    {
        var parser = DigitParsers.chars(@base);
        var input = span("346610");
        var buffer = CharBlock32.Null;
        var count = parser.Parse(input, buffer.Data);
        var parsed = slice(buffer.Data,0,count);
        Channel.Write(text.format(Demand.eq(input,parsed)));
    }

    void CheckDigitParser(Base16 @base)
    {
        var parser = DigitParsers.chars(@base);
        var input = span("FA34CA");
        var buffer = CharBlock32.Null;
        var count = parser.Parse(input, buffer.Data);
        var parsed = slice(buffer.Data,0,count);
        Channel.Write(text.format(Demand.eq(input,parsed)));
    }

    void CheckDigitParser(Base2 @base)
    {
        var parser = DigitParsers.chars(@base);
        var input = span("11001101");
        var buffer = CharBlock32.Null;
        var count = parser.Parse(input, buffer.Data);
        var parsed = slice(buffer.Data,0,count);
        Channel.Write(text.format(Demand.eq(input,parsed)));
    }        
}
