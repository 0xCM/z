//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public sealed class AsmCmdService : WfAppCmd<AsmCmdService>
    {
        AsmCallPipe AsmCalls => Wf.AsmCallPipe();

        AsmRegSets RegSets => Service(AsmRegSets.create);

        AsmTables AsmTables => Service(Wf.AsmTables);

        ApiPacks ApiPacks => Channel.Channeled<ApiPacks>();

        IPolyrand Random;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ReadOnlySeq<HostAsmRecord> HostAsm()
        {
            var pack = ApiPacks.Current();
            var paths = pack.Archive().Tables();
            return AsmTables.LoadHostAsmRows(paths.Root);
        }

        void EmitApiAsmBlocks(IApiPack Dst)
        {
            var result = Outcome.Success;
            var dst = Dst.Table<AsmDataBlock>();
            var hostasm = HostAsm();
            var blocks = AsmTables.DistillBlocks(hostasm);
            AsmTables.EmitBlocks(blocks, dst);
        }

        Outcome AsmQueryRex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.rex";
            var counter = 0u;
            var src = ProcessAsmBuffers.records(ApiPacks.Current());
            var buffer = span<ProcessAsmRecord>(src.Count);
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.rex(src, ref i, buffer);
            var filtered = slice(buffer,0,count);
            var dst = AppDb.AppData().Path(FS.file("asm.rex", FS.Csv));
            TableEmit(@readonly(filtered), dst);
            return result;
        }

        void EmitCallTable(IApiPack src)
        {
            var blocks = ApiCodeRows.apiblocks(src);
            AsmCalls.EmitRows(AsmDecoder.Decode(blocks.Storage), src.Analysis().Targets("calls").Root);
        }

        protected override void Initialized()
        {
            Random = Rng.wyhash64();
        }


        void EmitBitMasks()
        {
            var dst = AppDb.AppData(ApiAtomic.logs).Path("bitmasks", FileKind.Csv);
            var src = BitMask.masks(typeof(BitMaskLiterals));
            var formatter = CsvTables.formatter<BitMaskInfo>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var mask = ref src[i];
                Channel.Row(formatter.Format(mask));
                Write(mask.Text);
            }
            Channel.TableEmit(src,dst,TextEncodingKind.Unicode);

        }

        [CmdOp("calcs/check")]
        void Hello()
        {
            EmitBitMasks();
        }


        Outcome EmitTokenStrings(CmdArgs args)
        {
            // "----\0----\0----\0"
            var result = Outcome.Success;
            var dst = text.buffer();
            var spec = new char[12];
            var j=0u;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Null;

            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Null;

            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Dash;
            seek(spec,j++) = Chars.Null;

            var ts = Tokens.count(spec);
            Write(ts);

            return result;
        }

        Outcome GenBitSeq(CmdArgs args)
        {
            const byte CellWidth = 8;
            const uint CellCount = 512;
            Span<char> buffer = stackalloc char[CellWidth];
            var dst = AppDb.CgStage().Root + FS.file("bitseq", FS.Cs);
            var flow = Channel.EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine("    public readonly struct GeneratedBits");
            writer.WriteLine("    {");
            writer.Write(string.Format("        public static ReadOnlySpan<byte> SequencedBits = new byte[{0}]", CellCount));
            writer.Write("{");
            for(var i=0; i<CellCount; i++)
            {
                byte b = (byte)i;
                var data = text.format(render(b, CellWidth, buffer));
                writer.Write(string.Format("0b{0}, ", data));
            }
            writer.WriteLine("};");
            writer.WriteLine("    }");
            EmittedFile(flow, CellCount);
            return true;
        }

        [MethodImpl(Inline), Op]
        static Span<char> render(byte src, byte width, Span<char> dst)
        {
            for(var j=0; j<width; j++)
                seek(dst, j) = @char(@bool(bit.test(src, (byte)j)));
            dst.Reverse();
            return dst;
        }

        Outcome GenAsm(CmdArgs args)
        {
            const string mnemonic = "kandb";
            const string RenderPattern = mnemonic + " {0}";

            var dst = AppDb.Dev("asm.models").Targets("cg").Path(mnemonic,FileKind.Asm);
            using var writer = dst.AsciWriter();
            writer.WriteLine("bits 64");

            // a in RCX, b in RDX, c in R8, d in R9
            var counter = 0u;
            var r0 = RegSets.MaskRegs();
            var r1 = r0.Replicate();
            var r2 = r0.Replicate();
            for(var i=0u; i<r0.Count; i++)
            for(var j=0u; j<r1.Count; j++)
            for(var k=0u; k<r2.Count; k++)
            {
                if(i==0)
                    continue;

                if(i == j && j == k)
                    continue;

                var asm = string.Format(RenderPattern, format(r0[i], r1[j], r2[k]));
                writer.WriteLine(asm);
                counter++;
            }
            Write(EmittedInstructions.Format(counter,dst));
            return true;
        }

        MsgPattern<Count,FileUri> EmittedInstructions
            => "Emitted {0} instructions to {1}";

        Outcome GenAsm2(CmdArgs args)
        {
            const string AsmPattern = "{0} {1},{2}";
            const string LabelPattern = "{0}:";
            const string SectionPattern = "{0}";
            const string TextSection = ".text";
            const string CommentPattern = "# {0}";

            var ocinfo = "BSR(r16,r/m16) = 0F BD /r";
            var result = Outcome.Success;
            var asmid = "bsr";
            var label = "bsr_r16_r16";
            var syntax = "mc";
            var w0 = NativeSizeCode.W16;
            var w1 = NativeSizeCode.W16;
            var r0 = RegSets.GpRegs(w0);
            var r1 = RegSets.GpRegs(w1);
            var dst = AppDb.Dev("llvm.models/mc.models").Path(asmid,FileKind.Asm);
            var indent = 0u;
            var buffer = text.buffer();
            buffer.AppendLine(string.Format(SectionPattern, TextSection));
            buffer.AppendLine();
            buffer.AppendLineFormat(CommentPattern, ocinfo);
            buffer.AppendLine(string.Format(LabelPattern,label));

            indent += 4;
            for(var i=0u; i<r0.Count; i++)
            for(var j=0u; j<r1.Count; j++)
                buffer.IndentLine(indent, string.Format(AsmPattern, asmid, r0[i], r1[j]));

            indent -= 4;

            dst.Overwrite(buffer.Emit(), TextEncodingKind.Asci);

            return result;
        }

        static string format(RegOp op0, RegOp op1, RegOp op2)
            => string.Format("{0},{1},{2}", op0, op1, op2);

        Outcome UnpackRespack(CmdArgs args)
        {
            var unpacker = ApiResPackUnpacker.create(Wf);
            var dst = FolderPath.Empty;
            unpacker.Emit(dst);
            return true;
        }

        Outcome EmitApiAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var records = AsmTables.LoadHostAsmRows(Z0.Files.Empty);
            var blocks = AsmTables.DistillBlocks(records);
            AsmTables.EmitBlocks(blocks, AppDb.AppData().Table<AsmDataBlock>("api/asm"));
            return result;
        }


        Outcome Primes(CmdArgs args)
        {
            var result = Outcome.Success;
            var emitter = PrimeEmitter.create();
            var prime = 0ul;
            var buffer = list<ListItem<ulong>>();
            var limit = uint.MaxValue;
            DataParser.parse(arg(args,0).Value, out uint count);

            for(var i=0u; i<count; i++)
            {
                prime = emitter.Next();
                if(prime > limit)
                    break;

                buffer.Add((i, prime));
            }

            var dst = ItemLists.list(buffer.ToArray());
            iter(dst, item => Write(item.Value));

            return result;
        }

        Outcome RespackInfo(CmdArgs args)
        {
            var result = Outcome.Success;
            var provider = Wf.ApiResProvider();
            var path = provider.ResPackPath();
            var accessors = provider.ResPackAccessors();
            Write(string.Format("Count:{0}", accessors.Length));
            return result;
        }

        void GenSlnScript()
        {
            const string Pattern = "dotnet sln add {0}";
            var src = FS.dir(@"C:\Dev\z0");
            var dst = AppDb.Logs().Path("create-sln", FileKind.Cmd);
            var projects = src.Files(FS.CsProj, true);
            var flow = Channel.EmittingFile(dst);
            using var writer = dst.Writer();
            iter(projects,project => writer.WriteLine(string.Format(Pattern, project.Format(PathSeparator.BS))));
            Channel.EmittedFile(flow,projects.Length);
        }

        void CheckFlags()
        {
            var flags = Symbols.@enum<MinidumpType>();
            var summary = flags.Describe();
            var count = summary.FieldCount;
            var details = summary.LiteralDetails;

            if(count == 0)
                Channel.Error("No flags");

            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(details,i);
                var description = string.Format("{0,-12} | {1,-48} | {2}", detail.Position, detail.Name, detail.ScalarValue.FormatHex());
                Channel.Row(description);
            }
        }


        public void RunPipes()
        {
            using var flow = Channel.Running(nameof(RunPipes));
            // var data = Wf.Polysource.Span<ushort>(2400);

            // var input = Pipes.pipe<ushort>();
            // var incount = Pipes.flow(data, input);
            // var output = Pipes.pipe<ushort>();
            // var outcount = Pipes.flow(input,output);

            // Wf.Ran(flow, $"Ran {incount} -> {outcount} values through pipe");
        }

        static ReadOnlySpan<byte> JmpRaxCode
            => new byte[44]{0x0f,0x1f,0x44,0x00,0x00,0x49,0xb8,0x68,0xd5,0x9e,0x18,0x36,0x02,0x00,0x00,0x4d,0x8b,0x00,0x48,0xba,0x28,0xd5,0x9e,0x18,0x36,0x02,0x00,0x00,0x48,0x8b,0x12,0x48,0xb8,0x90,0x2c,0x8b,0x64,0xfe,0x7f,0x00,0x00,0x48,0xff,0xe0};

        public static bool TestJmpRax(ReadOnlySpan<byte> src, int offset, out byte delta)
        {
            delta = 0;
            if(offset >= 3)
            {
                ref readonly var s2 = ref skip(src,offset - 2);
                ref readonly var s1 = ref skip(src,offset - 1);
                ref readonly var s0 = ref skip(src,offset - 0);
                if(s2 == 0x48 && s1 == 0xff && s0 == 0xe0)
                {
                    delta = 2;
                    return true;
                }
            }
            return false;
        }

        public int TestJmpRax()
        {
            var tc = JmpRaxCode;
            var count = tc.Length;
            var address = MemoryAddress.Zero;
            for(var i=0; i<count; i++)
            {
                var result = TestJmpRax(tc, i, out var delta);
                if(result)
                {
                    var location = address - (uint)delta;
                    Channel.Status($"Jmp RAX found at {location.Format()}");
                    break;
                }
                address++;
            }
            return 0;
        }

        // void FilterApiBlocks()
        // {
        //     var blocks = Wf.ApiCatalogs().Correlate();
        //     var f1 = ApiCode.filter(blocks,ApiClassKind.And);
        //     iter(f1,f => Wf.Data(f.Uri));
        // }
    }
}