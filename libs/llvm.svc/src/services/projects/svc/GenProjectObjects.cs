//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectSvc
    {
        public void GenProjectObjects(IProjectWorkspace project)
        {
            var context = FlowContext.create(project);
            var catalog = context.Files;
            var files = catalog.Docs(FileKind.Obj, FileKind.O);
            var count = files.Count;
            var emitter = text.emitter();
            var offset = 0u;
            emitter.IndentLine(offset, "namespace Z0");
            emitter.IndentLine(offset, Chars.LBrace);
            offset += 4;
            emitter.IndentLineFormat(offset, "public readonly struct {0}", project.Name);
            emitter.IndentLine(offset, Chars.LBrace);
            offset += 4;
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var code = dict<MemoryRange,BinaryCode>();
                var obj = Coff.LoadObj(file);
                var sections = Coff.CalcObjSections(context, file);
                for(var j=0; j<sections.Count; j++)
                {
                    ref readonly var section = ref sections[j];
                    if(section.SectionKind == CoffSectionKind.Text)
                    {
                        var range = new MemoryRange(section.RawDataAddress, section.RawDataSize);
                        code[range] = obj.Data;
                        var data = obj.Bytes(range);
                        var identifier = file.Path.FileName.WithoutExtension.Format().Replace(Chars.Dot, Chars.Underscore).Replace(Chars.Dash,Chars.Underscore);
                        var hex = data.FormatHex(Chars.Comma,true);
                        var gen = string.Format("public static ReadOnlySpan<byte> {0} = new byte[{1}]", identifier, (uint)section.RawDataSize);
                        var statement = gen + "{" + hex + "};";
                        emitter.IndentLine(offset, statement);
                        emitter.AppendLine();
                    }
                }
            }

            offset -= 4;
            emitter.IndentLine(offset, Chars.RBrace);

            offset -= 4;
            emitter.IndentLine(offset, Chars.RBrace);

            FileEmit(emitter.Emit(), count, AppDb.Logs().Path(FS.file(project.Name, FS.Cs)));
        }
    }
}