 //-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Xml;

using static IntrinsicsDoc;
using static sys;

public class IntelIntrinsics : WfSvc<IntelIntrinsics>
{
    static IDbArchive Sources => IntelPaths.Service.InxDb().Scoped("sources");

    static IDbArchive Targets => IntelPaths.Service.InxDb().Scoped("targets");

    static FileName AlgFile => FS.file("intel.intrinsics", FS.ext("alg"));

    static FileName XmlFile => FS.file("intel.intrinsics", FS.Xml);

    static FileName DeclFile => FS.file("intel.intrinsics", FS.H);

    public ExecToken RunEtl()
    {
        var db = IntelPaths.Service.InxDb();
        var running = Channel.Running();
        db.Targets().Clear();
        var xml = LoadSourceDoc();
        var parsed = ParseSouceDoc(xml);
        EmitAlgorithms(parsed);
        var records = EmitRecords(parsed);
        EmitDeclarations(parsed);
        return Channel.Ran(running);
    }

    public XmlDoc LoadSourceDoc()
        => Sources.Path(XmlFile).ReadUtf8();

    public ReadOnlySeq<IntrinsicDef> ParseSouceDoc(XmlDoc src)
    {
        var flow = Channel.Running($"Parsing definitions from source document");
        var defs =  parse(src);
        Channel.Ran(flow, $"Parsed {defs.Count} definitions");
        return defs;
    }

    public void EmitAlgorithms(ReadOnlySpan<IntrinsicDef> src)
    {
        var dst = text.emitter();
        render(src, dst);
        Channel.FileEmit(dst.Emit(), Targets.Path(AlgFile), TextEncodingKind.Utf8);
    }

    public void EmitDeclarations(ReadOnlySpan<IntrinsicDef> src)
    {
        var dst = Targets.Path(DeclFile);
        var flow = Channel.EmittingFile(dst);
        var count = src.Length;
        using var writer = dst.Writer();
        for(var i=0; i<count; i++)
            writer.WriteLine(string.Format("{0};", skip(src,i).Sig()));
        Channel.EmittedFile(flow, count);
    }

    public ReadOnlySeq<IntelIntrinsicRecord> EmitRecords(ReadOnlySeq<IntrinsicDef> src)
    {
        var dst = alloc<IntelIntrinsicRecord>(src.Count);
        for(var i=0; i<src.Length; i++)
            record(src[i], Channel, out seek(dst,i));            
        dst.Sort();
        dst.Resequence();
        Channel.TableEmit(dst, Targets.Table<IntelIntrinsicRecord>());            
        return dst;
    }

    const int MaxDefCount = Pow2.T13;

    
    static ReadOnlySeq<IntrinsicDef> parse(XmlDoc src)
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
        var target = new Parameter();
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
            xed: Enums.parse(reader[nameof(Instruction.xed)], default(XedFormType)))
            );

    static void render(ReadOnlySpan<IntrinsicDef> src, ITextEmitter dst)
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
        
        if(src.header.IsNonEmpty)
            dst.AppendLineFormat("# Header: {0}", src.header);

        iter(src.instructions, x => {
            dst.AppendLineFormat("# Instruction: {0}", x);
            dst.AppendLineFormat("# IForm: {0}", x.xed);
        });

        dst.AppendLineFormat("# Description: {0}", src.description);
    }

    static void record(in IntrinsicDef src, IWfChannel channel, out IntelIntrinsicRecord dst)
    {
        dst = IntelIntrinsicRecord.Empty;
        try
        {
            dst.Key = 0;
            dst.Name = src.name;
            dst.CpuId = src.CPUID;
            dst.Types = src.types;
            dst.Category = src.category;
            dst.Signature = src.Sig();    
            if(instruction(src, out Instruction inst))
            {
                dst.InstSig = inst;
                dst.InstForm = inst.xed;
                dst.FormId = (ushort)inst.xed;
                // Not every intrinsic is associated with an instruction class
                XedParsers.parse(src.name, out dst.InstClass);
            }
        }
        catch (Exception e)
        {
            
            channel.Error(e);
            channel.Row(src.ToString());
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
}
