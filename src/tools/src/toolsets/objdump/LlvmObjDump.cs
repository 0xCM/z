//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    public record class ToolDef
    {
        public Name ToolName;


        
    }


    public class ToolDisatcher
    {

    }
    sealed class ObjDumpProcess : ToolProcess<ObjDumpProcess>
    {
        protected override FilePath ToolPath 
            => AppSettings.LlvmSettings().Tool("llvm-objdump");
    }

    class LlvmObjDump : WfAppCmd<LlvmObjDump>
    {       
        readonly FilePath Tool;

        public LlvmObjDump()
        {
            Tool = AppSettings.LlvmSettings().Tool("llvm-objdump");
        }

        [CmdOp("llvm/objdump/symbols")]
        void EmitSymbols(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var index = sources(src);
            var output = EnvDb.Nested(Tool.FileName.WithoutExtension.Format(), src.Root).Clear();
            iter(index.Distinct(), entry => {
                EmitSymbols(entry, output);
            }, true);
        }

        Task<ExecToken> EmitSymbols(FileIndexEntry entry, IDbArchive dst)
        {
            var cmdargs = Cmd.args(entry.Path.Format(PathSeparator.FS), "--syms", "--demangle");
            var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("symtables"));
            var process = ObjDumpProcess.init(Channel, entry.Path, dst.Path(filename));
            return process.Start(cmdargs);            
        }

        static FileIndex sources(IDbArchive src)
            => FS.index(Archives.modules(src).Unmanaged());

        [CmdOp("llvm/objdump/disasm")]
        void Disassemble(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var index = sources(src);
            var output = EnvDb.Nested(Tool.FileName.WithoutExtension.Format(), src.Root).Clear();            
            iter(index.Distinct(), entry => {
                var cmdargs = Cmd.args(entry.Path.Format(PathSeparator.FS), "--x86-asm-syntax=intel", "--disassemble", "--symbolize-operands", "--demangle");
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FileKind.Asm);
                var process = ObjDumpProcess.init(Channel, entry.Path, output.Path(filename));
                process.Start(cmdargs);
            },true);
        }
    }
}

