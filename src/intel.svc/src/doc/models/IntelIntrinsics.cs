//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Xml;

    using dsl.intel;

    using static IntrinsicsDoc;
    using static sys;

    public class IntelInx : WfSvc<IntelInx>
    {
        IDbSources Sources()
            => AppDb.DbIn("intel");

        IDbTargets Targets()
            => AppDb.AsmDb("intrinsics");

        FilePath XmlSource()
            => Sources().Path(XmlFile);

        FilePath DeclPath()
            => Targets().Path(DeclFile);

        FilePath AlgPath()
            => Targets().Path(AlgFile);

        XmlDoc LoadDocXml()
            => XmlSource().ReadUtf8();

        Index<IntrinsicDef> ParseDoc()
        {
            var flow = Emitter.Running($"Reading intrinsics definitions from {XmlSource().ToUri()}");
            var defs =  read(LoadDocXml());
            Emitter.Ran(flow, $"Read {defs.Count} definitions");
            return defs;
        }

        public static void render(ReadOnlySpan<IntrinsicDef> src, ITextEmitter dst)
        {
            for(var i=0; i<src.Length; i++)
            {
                if(i!=0)
                    dst.AppendLine();

                ref readonly var def = ref skip(src,i);
                overview(def,dst);
                dst.AppendLine(def.Sig());
                body(def,dst);
            }
        }

        static void body(IntrinsicDef src, ITextEmitter dst)
        {
            dst.AppendLine("{");
            emit(src.operation, dst);
            dst.AppendLine("}");
        }

        static void emit(Operation src, ITextEmitter dst)
        {
            if(src.IsNonEmpty)
                iter(src.Content, x => dst.AppendLine("  " + x.Content));
        }

        static void overview(IntrinsicDef src, ITextEmitter dst)
        {
            dst.AppendLine(string.Format("# Intrinsic: {0}", src.Sig()));

            if(nonempty(src.tech))
                dst.AppendLineFormat("# Tech: {0}", src.tech);

            if(src.CPUID.IsNonEmpty)
                dst.AppendLineFormat("# CpuId: {0}", src.CPUID);

            if(src.category.IsNonEmpty)
                dst.AppendLineFormat("# Category: {0}", src.category);

            iter(src.instructions, x => {
                dst.AppendLineFormat("# Instruction: {0}", x);
                dst.AppendLineFormat("# IForm: {0}", x.xed);
            });

            dst.AppendLineFormat("# Description: {0}", src.description);
        }

        public void EmitAlgorithms(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = text.emitter();
            render(src,dst);
            FileEmit(dst.Emit(), AlgPath(), TextEncodingKind.Utf8);
        }

        public void EmitDeclarations(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = DeclPath();
            var flow = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(string.Format("{0};", skip(src,i).Sig()));
            EmittedFile(flow, count);
        }

        public Index<IntelIntrinsicRecord> EmitRecords(Index<IntrinsicDef> src)
        {
            var dst = alloc<IntelIntrinsicRecord>(src.Count);
            records(src, Emitter, dst);
            TableEmit(dst.Sort().Resequence(), Targets().Table<IntelIntrinsicRecord>());
            return dst;
        }

        public static void records(ReadOnlySpan<IntrinsicDef> src, WfEmit channel, Span<IntelIntrinsicRecord> dst)
        {
            for(var i=0; i< src.Length; i++)
                record(skip(src,i), channel, out seek(dst,i));
        }

        static void record(in IntrinsicDef src, WfEmit channel,  out IntelIntrinsicRecord dst)
        {
            dst = default;
            try
            {
                dst.Key = 0;
                dst.Name = src.name;
                dst.CpuId = src.CPUID;
                dst.Types = src.types;
                dst.Category = src.category;
                dst.Signature = src.Sig();

                if(instruction(src, out var inst))
                {
                    dst.InstSig = inst;
                    dst.InstForm = inst.xed;
                    dst.FormId = (ushort)inst.xed;
                    dst.InstClass = inst.InstClass;
                }
                else
                {
                    dst.InstClass = AmsInstClass.Empty;
                    dst.InstSig = Instruction.Empty;
                    dst.InstForm = InstForm.Empty ;
                    dst.FormId = 0;
                }
            }
            catch (Exception e)
            {
                channel.Error(e);
            }
        }

        static bool instruction(in IntrinsicDef src, out Instruction dst)
        {
            var instructions = src.instructions;
            if(instructions.Count != 0)
            {
                dst = instructions[0];
                return true;
            }
            else
            {
                dst = Instruction.Empty;
                return false;
            }
        }

        public Index<IntrinsicDef> RunEtl()
        {
            Targets().Clear();
            var parsed = ParseDoc();
            EmitAlgorithms(parsed);
            var records = EmitRecords(parsed);
            EmitDeclarations(parsed);
            return parsed;
        }


        const int MaxDefCount = Pow2.T13;

        public static Index<IntrinsicDef> read(XmlDoc src)
        {
            var entries = new IntrinsicDef[MaxDefCount];
            var i = -1;
            using var reader = XmlReader.Create(new StringReader(src.Content));
            while (reader.Read() && i<MaxDefCount - 1)
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    switch(reader.Name)
                    {
                        case IntrinsicDef.ElementName:
                            i++;
                            entries[i] = IntrinsicDef.Empty;
                            entries[i].content = reader.Value;
                            entries[i].tech = reader[nameof(IntrinsicDef.tech)];
                            entries[i].name = reader[nameof(IntrinsicDef.name)];
                        break;

                        case Operation.ElementName:
                            read(reader, ref entries[i].operation);
                        break;

                        case Description.ElementName:
                            read(reader, ref entries[i].description);
                        break;

                        case Return.ElementName:
                            read(reader, ref entries[i].@return);
                        break;

                        case CpuId.ElementName:
                            read(reader, entries[i].CPUID);
                        break;

                        case Category.ElementName:
                            read(reader, ref entries[i].category);
                        break;

                        case Instruction.ElementName:
                            read(reader, entries[i].instructions);
                        break;

                        case InstructionType.ElementType:
                            read(reader, entries[i].types);
                        break;

                        case IntrinsicsDoc.Parameter.ElementName:
                            read(reader, entries[i].parameters);
                        break;
                        case Header.ElementName:
                            read(reader, ref entries[i].header);
                        break;
                    }
                }
            }

            return slice(span(entries),0,i).ToArray().Sort();
        }

        static void read(XmlReader reader, ref Operation dst)
        {
            const string amp = "&amp;";
            var content = reader.ReadInnerXml().Replace(XmlEntities.gt, ">").Replace(XmlEntities.lt, "<").Replace(amp, "&");
            foreach(var line in Lines.read(content,trim:false))
                dst.Content.Add(line);
        }

        static void read(XmlReader reader, CpuIdMembership dst)
            => dst.Add(reader.ReadInnerXml());

        static void read(XmlReader reader, ref Category dst)
            => dst = reader.ReadInnerXml();

        static void read(XmlReader reader, ref Header dst)
            => dst = reader.ReadInnerXml();

        static void read(XmlReader reader, ref Description dst)
            => dst =  reader.ReadInnerXml().Replace("\n", " ");

        static void read(XmlReader reader, ref Return dst)
        {
            dst.varname = reader[nameof(Return.varname)];
            dst.etype = reader[nameof(Return.etype)];
            dst.type = reader[nameof(Return.type)];
            dst.memwidth =  reader[nameof(Return.memwidth)];
        }

        static void read(XmlReader reader, Parameters dst)
        {
            var target = new IntrinsicsDoc.Parameter();
            target.varname = reader[nameof(target.varname)] ?? EmptyString;
            target.etype = reader[nameof(target.etype)] ?? EmptyString;
            target.type = reader[nameof(target.type)] ?? EmptyString;
            target.memwidth = reader[nameof(target.memwidth)] ?? EmptyString;
            target.immwidth = reader[nameof(target.immwidth)] ?? EmptyString;
            dst.Add(target);
        }

        static void read(XmlReader reader, InstructionTypes dst)
            => dst.Add(reader.ReadInnerXml());

        static void read(XmlReader reader, Instructions dst)
            => dst.Add(new (
                name: reader[nameof(Instruction.name)],
                form: reader[nameof(Instruction.form)],
                xed: Enums.parse(reader[nameof(Instruction.xed)], default(InstFormType)))
                );

        const string intrinsics = "intel.intrinsics";

        const string sep = ".";

        const string refs = intrinsics + sep + nameof(refs);

        const string checks = intrinsics + sep + nameof(checks);

        const string specs = intrinsics + sep + nameof(specs);

        const string algs = intrinsics + sep + nameof(algs);

        const string sigs = intrinsics + sep + nameof(sigs);

        public static FileName AlgFile => FS.file(algs, FS.Txt);

        public static FileName DataFile => FS.file(intrinsics, FS.Csv);

        public static FileName XmlFile => FS.file(intrinsics, FS.Xml);

        public static FileName DeclFile = FS.file(intrinsics, FS.H);
    }
}