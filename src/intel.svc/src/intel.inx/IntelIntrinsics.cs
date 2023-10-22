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

    static FileName TypeDeclFile => FS.file("intel.intrinsics.types", FS.H);

    static HashSet<string> DeclSkip = sys.hashset(new string[]{
        "_BitScanForward",
        "_BitScanForward64",
        "_BitScanReverse",
        "_BitScanReverse64",
        "_bittest",
        "_bittest64",
        "_bittestandcomplement",
        "_bittestandcomplement64",
        "_bittestandreset",
        "_bittestandreset64",
        "_bittestandset",
        "_bittestandset64",
        "_get_ssp",
        "_mm_prefetch",
        "_mm_clflush",
    });

    public ExecToken RunEtl()
    {
        var db = IntelPaths.Service.InxDb();
        var running = Channel.Running();
        db.Targets().Clear();
        var xml = LoadSourceDoc();
        var parsed = ParseSouceDoc(xml);
        EmitAlgorithms(parsed);
        EmitRecords(parsed);
        EmitTypeDecls();
        EmitScripts();
        EmitMethodDecls(parsed);
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

    public void EmitScripts()
    {
        var dst = text.emitter();
        dst.AppendLine("@echo off");
        dst.AppendLine($"clang %~dp0{TypeDeclFile} -Xclang -ast-dump-all >%~dp0{TypeDeclFile}.ast");
        dst.AppendLine($"clang %~dp0{TypeDeclFile} -Xclang -ast-dump-all=json >%~dp0{TypeDeclFile}.ast.json");
        dst.AppendLine($"clang %~dp0{DeclFile} -Xclang -ast-dump-all >%~dp0{DeclFile}.ast");
        dst.AppendLine($"clang %~dp0{DeclFile} -Xclang -ast-dump-all=json >%~dp0{DeclFile}.ast.json");
        Channel.FileEmit(dst.Emit(), Targets.Path("emit-ast", FileKind.Cmd));
    }

    public void EmitTypeDecls()
    {
        var dst = Targets.Path(TypeDeclFile);
        var content = IntrinsicAssets.Instance.TypeDeclarations();
        Utf8.decode(content.ResBytes, out var _decoded);
        Channel.FileEmit(_decoded, dst);
    }

    public void EmitMethodDecls(ReadOnlySpan<IntrinsicDef> src)
    {
        var dst = Targets.Path(DeclFile);
        var flow = Channel.EmittingFile(dst);
        var count = src.Length;
        using var writer = dst.Writer();
        writer.WriteLine("#pragma once");
        writer.WriteLine(string.Format("#include {0}", text.dquote(TypeDeclFile.Format())));
        writer.WriteLine();
        for(var i=0; i<count; i++)
        {
            ref readonly var decl = ref skip(src,i);
            var sig = decl.Sig();
            var name = Require.equal(decl.name.Format(), sig.Name.Format());

            if(DeclSkip.Contains(name))
                continue;

            if(decl.CPUID != null && decl.CPUID.IsNonEmpty)
                writer.WriteLine($"// {decl.CPUID}");

            foreach(var inst in decl.instructions)
            {
                if(inst.xed != 0)
                    writer.WriteLine($"// {inst.xed}");

                if(inst.name.IsNonEmpty && inst.form.IsNonEmpty)
                    writer.WriteLine($"// {inst.name} {inst.form}"); 
            }

            if(decl.description.IsNonEmpty)
                writer.WriteLine($"// {decl.description}");

            writer.WriteLine(string.Format("{0};", sig));
            writer.WriteLine();
        }
        Channel.EmittedFile(flow, count);
    }

    public static ReadOnlySeq<IntelIntrinsicRecord> records(ReadOnlySeq<IntrinsicDef> src)
    {
        var dst = alloc<IntelIntrinsicRecord>(src.Count);
        for(var i=0; i<src.Length; i++)
            record(src[i], out seek(dst,i));            
        return dst.Sort().Resequence();
    }

    public void EmitRecords(ReadOnlySeq<IntrinsicDef> src)
        => Channel.TableEmit(records(src), Targets.Table<IntelIntrinsicRecord>());

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

        if(src.instructions.Count != 0)
        {
            if(src.instructions.Count > 1)
            {
                dst.AppendLine("# Instructions:");
                var i=0;
                iter(src.instructions, x => 
                    dst.AppendLineFormat("# {0} {{sig:{1} {2}, iform:{3} }}", i++, x.name, x.form, x.xed)
                );
            }
            else
            {
                var x = src.instructions[0];
                dst.AppendLineFormat("# Instruction {{sig:{0} {1}, iform:{2} }}", x.name, x.form, x.xed);
            }
        }

        dst.AppendLineFormat("# Description: {0}", src.description);
    }

    static void record(in IntrinsicDef src, out IntelIntrinsicRecord dst)
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
            term.error(e);
            term.error(src.ToString());
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
