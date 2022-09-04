//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        AsmDocs AsmDocs => Wf.AsmDocs();

        void CheckHexExec()
        {
            HexCodeRunner.slots(Emitter);
            var runner = new HexCodeRunner(Wf,Emitter);
            runner.RunAlgs();
        }

        void EmitBitMasks()
        {
            var dst = AppDb.AppData(ApiAtomic.logs).Path("bitmasks", FileKind.Csv);
            var src = BitMask.masks(typeof(BitMaskLiterals));
            var formatter = Tables.formatter<BitMaskInfo>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var mask = ref src[i];
                Row(formatter.Format(mask));
                Write(mask.Text);
            }
            TableEmit(src,dst,TextEncodingKind.Unicode);

        }

        [CmdOp("calcs/check")]
        void Hello()
        {
            CheckHexExec();
            EmitBitMasks();
        }

        Outcome AsmExe(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = arg(args,0).Value;
            var script = FilePath.Empty;
            result = BuildAsmExe(id,script);
            if(result.Fail)
                return result;
            //var exe = AsmWs.ExePath(id);
            var exe = FilePath.Empty;
            var clock = Time.counter(true);
            var process = Process.Start(exe.Format());
            process.WaitForExit();
            var duration = clock.Elapsed();
            Write(string.Format("runtime:{0}", duration));
            return result;
        }

        Outcome AsmConfig(CmdArgs args)
        {
            var result = OmniScript.Run(FolderPath.Empty + FS.file("log-config",FileKind.Cmd), out var response);
            if(result.Fail)
                return result;

            var src = Settings.parse(response, Chars.Colon);
            var count = src.Length;
            var vars = new CmdVar[count];
            for(var i=0; i<count; i++)
            {
                ref readonly var facet = ref src[i];
                seek(vars,i) = Cmd.var(facet.Name, facet.Value);
            }

            iter(vars, v => Write(v.Name,
                v.Evaluated ? string.Format("{0} (Evaluated)", v.Value) : string.Format("{0} (Symbolic)", v.Value))
                );

            return result;
        }

        void CheckMullo(IBoundSource Source)
        {
            var @class = ApiClassKind.MulLo;
            var count = 12;
            var left = Source.Array<uint>(count,100,200);
            var right = Source.Array<uint>(count,100,200);
            var buffer = alloc<uint>(count);
            ref readonly var x = ref first(left);
            ref readonly var y = ref first(right);
            ref var dst = ref first(buffer);
            var results = alloc<TextBlock>(count);
            var output = alloc<uint>(count);
            ref var expected = ref first(output);
            ref var calls = ref first(results);
            for(var i=0; i<count; i++)
            {
                ref readonly var a = ref skip(x,i);
                ref readonly var b = ref skip(y,i);
                ref var actual = ref seek(dst,i);
                ref var expect = ref seek(expected,i);
                actual = cpu.mullo(a,b);
                expect = math.mul(a,b);
                //seek(calls, i) = ApiCalls.result(@class,a,b,actual);
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var call = ref skip(calls,i);
                ref readonly var expect = ref skip(expected,i);
                Wf.Data(call.Format() + " ?=? " + expect.ToString());
            }
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

            var ts = TokenStrings.define(spec);
            Write(ts.TokenCount);

            return result;
        }

        Outcome GenBitSeq(CmdArgs args)
        {
            const byte CellWidth = 8;
            const uint CellCount = 512;
            Span<char> buffer = stackalloc char[CellWidth];
            var dst = AppDb.CgStage().Root + FS.file("bitseq", FS.Cs);
            var flow = EmittingFile(dst);
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

        MsgPattern<Count,_FileUri> EmittedInstructions
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

        void GenMatcher(IDbTargets root, string scope)
        {
            var input = root.Targets(scope).Path(FS.file("matcher-a", FS.Txt));
            var lines = input.ReadNumberedLines();
            var LineCount = lines.Length;
            var histo = dict<char,uint>();
            var LineLengths = alloc<uint>(LineCount);
            var Terms = dict<string,uint>();
            for(var i=0; i<LineCount; i++)
            {
                ref readonly var line = ref lines[i];
                var content = line.Content.Trim();
                Terms[content] = (uint)content.Length;
                var term = span(content);
                var length = (uint)content.Length;
                seek(LineLengths,i) = length;

                for(var j=0; j<length; j++)
                {
                    ref readonly var c = ref skip(term,j);
                    if(histo.TryGetValue(c, out var n))
                        histo[c] = n + 1;
                    else
                        histo[c] = 1;
                }
            }

            var targets = root.Targets("targets");
            var counts = histo.Map(x => (x.Key,x.Value)).OrderBy(x => x.Key);
            void EmitTargets()
            {
                var dst = targets.Path(input.FileName.ChangeExtension(FS.ext("hist")));
                var emitting = EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                for(var i=0; i<counts.Length; i++)
                {
                    ref readonly var bucket = ref skip(counts,i);
                    writer.WriteLine(string.Format("{0} | {1}", bucket.Key, bucket.Value));
                }
                EmittedFile(emitting, counts.Length);
            }

            void EmitTerms()
            {
                var sorted = Terms.Map(x => (x.Key, x.Value)).OrderBy(x => x.Value);
                var max = gcalc.max(sorted.Select(x => x.Value).ToReadOnlySpan());
                var dst = targets.Path(input.FileName.ChangeExtension(FS.ext("terms")));
                var emitting = EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                var s0 = text.slot(0, math.negate((short)(max)));
                var s1 = text.slot(1);
                var pattern = string.Concat(s0," | ", s1);
                iter(sorted, s => writer.WriteLine(string.Format(pattern, s.Key, s.Value)));
                EmittedFile(emitting, sorted.Length);
            }

            void EmitBuckets()
            {
                var buckets = Buckets.bucketize(lines.Select(x => x.Content.Trim()));
                Write(buckets.Format());
            }
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

        void DescribeHeaps()
        {
            var src = Wf.ApiCatalog.Components.View;
            var heaps = Cli.strings(src).View;
            var count = heaps.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var heap = ref skip(heaps,i);
                var data = heap.Data;

                var size = heap.Size;
                var dst = text.emitter();
                dst.Append(heap.BaseAddress.Format());
                for(var j=0; j<size; j++)
                {
                    ref readonly var b = ref skip(data,j);
                    dst.AppendFormat(" {0:X2}", b);
                }

                Write(dst.Emit());

            }
        }

        void ResolveApi(params PartId[] parts)
        {
            var resolver = Wf.ApiResolver();
            resolver.ResolveParts(parts);
        }

        public void ParseDump()
        {
            using var clrmd = ClrMdSvc.create(Wf);
            clrmd.ParseDump(AppDb.Logs().Path("dump", FileKind.Log));
        }


        Cli Cli => Wf.Cli();

        void EmitDependencyGraph()
        {
            var svc = Wf.CliEmitter();
            var refs = Cli.ReadAssemblyRefs();
            var dst = AppDb.Logs().Path("dependencies", FileKind.Dot);
            var flow = Wf.EmittingFile(dst);
            var count = refs.Length;
            // var parts = Wf.ApiCatalog.ComponentNames.ToHashSet();
            // using var writer = dst.Writer();
            // writer.WriteLine("digraph dependencies{");
            // writer.WriteLine(string.Format("label={0}", text.dquote("Assembly Dependencies")));
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var x = ref refs[i];
            //     if(parts.Contains(x.Target.Format()))
            //     {
            //         var source = x.Source.Format().Replace(Chars.Dot, Chars.Underscore);
            //         var target = x.Target.Format().Replace(Chars.Dot, Chars.Underscore);
            //         var arrow = string.Format("{0}->{1}", source, target);
            //         writer.WriteLine(arrow);
            //     }
            // }
            // writer.WriteLine("}");
            // Wf.EmittedFile(flow, count);
        }

        void GenSlnScript()
        {
            const string Pattern = "dotnet sln add {0}";
            var src = FS.dir(@"C:\Dev\z0");
            var dst = AppDb.Logs().Path("create-sln", FileKind.Cmd);
            var projects = src.Files(FS.CsProj, true);
            var flow = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            iter(projects,project => writer.WriteLine(string.Format(Pattern, project.Format(PathSeparator.BS))));
            Wf.EmittedFile(flow,projects.Length);
        }


        public void CheckClrKeys()
        {
            var types = Wf.ApiCatalog.Components.Storage.Types();
            var unique = hashset<Type>();
            var count = unique.Include(types).Where(x => x).Count();
            Wf.Data($"{types.Length} ?=? {count}");
            var fields = Wf.ApiCatalog.Components.Storage.DeclaredStaticFields();
            iter(fields, f => Wf.Data(f.Name + ": " + f.FieldType.Name));
        }


        void CheckFlags()
        {
            var flags = Clr.@enum<MinidumpType>();
            var summary = flags.Describe();
            var count = summary.FieldCount;
            var details = summary.LiteralDetails;

            if(count == 0)
                Wf.Error("No flags");

            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref skip(details,i);
                var description = string.Format("{0,-12} | {1,-48} | {2}", detail.Position, detail.Name, detail.ScalarValue.FormatHex());
                Wf.Data(description);
            }
        }

        static string FormatAttributes(IXmlElement src)
            => src.Attributes.Select(x => string.Format("{0}={1}",x.Name, x.Value)).Delimit(Chars.Comma).Format();

        void ConvertPdbXml()
        {
            var dir = FolderPath.Empty;
            var file = PartId.AsmCore.Component(FS.Pdb, FS.Xml);
            var srcPath = dir + file;
            var buffer = text.buffer();

            var dstPath = FilePath.Empty;
            using var writer = dstPath.Writer();

            const string Pattern = "{0}/{1}:{2}";

            void HandleFiles(IXmlElement src)
                => writer.WriteLine(string.Format(Pattern, src.Ancestor, src.Name, FormatAttributes(src)));

            void HandleMethods(IXmlElement src)
                => writer.WriteLine(string.Format(Pattern, src.Ancestor, src.Name, FormatAttributes(src)));

            void HandleSequencePointEntry(IXmlElement src)
                => writer.WriteLine(string.Format(Pattern, src.Ancestor, src.Name, FormatAttributes(src)));


            var handlers = new ElementHandlers();
            handlers.AddHandler("file", HandleFiles);
            handlers.AddHandler("method", HandleMethods);
            handlers.AddHandler("entry", HandleMethods);

            var flow = Wf.EmittingFile(dstPath);
            using var xml = XmlSource.create(srcPath);
            xml.Read(handlers);
            Wf.EmittedFile(flow,1);
        }

        public void RunPipes()
        {
            using var flow = Wf.Running(nameof(RunPipes));
            //var data = Wf.Polysource.Span<ushort>(2400);

            // var input = Pipes.pipe<ushort>();
            // var incount = Pipes.flow(data, input);
            // var output = Pipes.pipe<ushort>();
            // var outcount = Pipes.flow(input,output);

            //Wf.Ran(flow, $"Ran {incount} -> {outcount} values through pipe");
        }

        MemoryAddress GetKernel32Proc(string name = "CreateDirectoryA")
        {
            var flow = Running();
            using var kernel = NativeModules.kernel32();
            Write(kernel);

            var f = NativeModules.func<OS.Delegates.GetProcAddress>(kernel, nameof(OS.Delegates.GetProcAddress));
            Write(f);

            var address = (MemoryAddress)f.Invoke(kernel, name);
            Write(address);

            Ran(flow);

            return address;
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
                    var location = address - delta;
                    Wf.Status($"Jmp RAX found at {location.Format()}");
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