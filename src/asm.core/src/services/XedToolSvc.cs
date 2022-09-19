//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId)]
    public struct XedScriptSpec
    {
        public const string TableId = "xed.scripts";

        public string Name;

        public FilePath InputPath;

        public FilePath SummaryPath;

        public FilePath DetailPath;
    }

    public sealed partial class XedToolCmd : ToolService<XedToolCmd>
    {
        const string group = "xedtool";

        const string tool = "xed";

        public XedToolCmd()
            : base(tool)
        {

        }

        [CmdOp("xed/tools")]
        void ListDeployed()
            => iter(Deployment.Files(FS.Exe), file => Write(file.ToUri()));

        [CmdOp("xed/tool/case")]
        void DefineCaseScript(CmdArgs args)
            => DefineCaseScript(arg(args,0));

        FolderPath CaseDir<T>(T subject)
            => AppDb.AppData().Root + FS.folder(ApiAtomic.cases) + FS.folder(string.Format("{0}", subject));

        FolderPath CaseDir<T,D>(T subject, D discriminator)
            => CaseDir(subject) + FS.folder(string.Format("{0}", discriminator));

        public string DefineCaseScript(string opcode)
        {
            var dir = CaseDir("asm.assembled", opcode);
            var dst = dir + FS.file(string.Format("{0}.{1}", opcode, Id), FS.Cmd);
            var @case = DefineScript(opcode.ToString(), dir);
            var content = CreateScript(@case);
            return content;
        }

        public XedScriptSpec DefineScript(string name, FolderPath dst)
        {
            var @case = new XedScriptSpec();
            @case.Name = name;
            @case.InputPath = input(dst, binfile(name));
            @case.SummaryPath = output(dst, ToolFile(name, "summary", FileKind.Log));
            @case.DetailPath =  output(dst, ToolFile(name, "detail", FileKind.Log));
            return @case;
        }

        public void Render(XedScriptSpec src, ITextEmitter dst)
        {
            const string SummaryFlags = "-isa-set -64";
            const string DetailFlags = "-v 4 -isa-set -64";
            dst.AppendLine("@echo off");
            dst.AppendLineFormat("set tool={0}", format(ToolPath()));
            dst.AppendLineFormat("set case={0}", src.Name);
            dst.AppendLineFormat("set SummaryFlags={0}", SummaryFlags);
            dst.AppendLineFormat("set DetailFlags={0}", DetailFlags);
            dst.AppendLineFormat("set SrcPath={0}", format(src.InputPath));
            dst.AppendLineFormat("set DetailPath={0}", format(src.DetailPath));
            dst.AppendLineFormat("set SummaryPath={0}", format(src.SummaryPath));
            dst.AppendLine("set CmdSpec=%tool% %SummaryFlags% -ir %SrcPath%");
            dst.AppendLine("echo CmdSpec:%CmdSpec%");
            dst.AppendLine("%CmdSpec% > %SummaryPath%");
            dst.AppendLine("set CmdSpec=%tool% %DetailFlags% -ir %SrcPath%");
            dst.AppendLine("echo CmdSpec:%CmdSpec%");
            dst.AppendLine("%CmdSpec% > %DetailPath%");
        }

        public string CreateScript(XedScriptSpec src)
        {
            var buffer = text.buffer();
            Render(src, buffer);
            return buffer.Emit();
        }
    }
}