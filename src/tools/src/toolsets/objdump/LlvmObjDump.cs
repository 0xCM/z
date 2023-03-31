//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    sealed class ObjDumpProcess : ToolProcess<ObjDumpProcess>
    {
        protected override FilePath ToolPath 
            => AppSettings.LlvmSettings().Tool("llvm-objdump");
    }

    sealed class ReadObjProcess : ToolProcess<ReadObjProcess>
    {
        protected override FilePath ToolPath 
            => AppSettings.LlvmSettings().Tool("llvm-readobj");
    }

    public abstract class ToolWfCmd<T,P> : WfAppCmd<T>
        where T : ToolWfCmd<T,P>, new()
        where P : ToolProcess<P>, new()
    {
        protected static FileIndex index(IDbArchive src)
            => FS.index(Archives.modules(src).Unmanaged());

        protected Task<ExecToken> Start(CmdArgs args, FilePath src, FilePath dst)   
        {
            var process = ToolProcess<P>.init(Channel, src, dst);
            return process.Start(args);
        }
    }

    class LlvmReadObj : ToolWfCmd<LlvmReadObj, ReadObjProcess>
    {
        [CmdOp("llvm/readobj/coff-exports")]
        void CoffExports(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var dst = EnvDb.Nested("llvm-readobj", src.Root).Clear();
            iter(index(src).Distinct(), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("exports"));
                Start(Cmd.args(entry.Path.Format(PathSeparator.FS), "--coff-exports"), entry.Path, dst.Path(filename));
            }, true);
        }
    }

    class LlvmObjDump : ToolWfCmd<LlvmObjDump, ObjDumpProcess>
    {       

        public LlvmObjDump()
        {

        }

        [CmdOp("llvm/objdump/symbols")]
        void EmitSymbols(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var dst = EnvDb.Nested("llvm-objdump", src.Root).Clear();
            iter(index(src).Distinct(), entry => {
                var cmdargs = Cmd.args(entry.Path.Format(PathSeparator.FS), "--syms", "--demangle");
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("symtables"));
                Start(Cmd.args(entry.Path.Format(PathSeparator.FS), "--syms", "--demangle"),entry.Path, dst.Path(filename));
            }, true);
        }

        protected static FileIndex sources(IDbArchive src)
            => FS.index(Archives.modules(src).Unmanaged());

        [CmdOp("llvm/objdump/disasm")]
        void Disassemble(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var output = EnvDb.Nested("llvm-objdump", src.Root).Clear();            
            iter(index(src).Distinct(), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FileKind.Asm);
                Start(Cmd.args(entry.Path.Format(PathSeparator.FS), "--x86-asm-syntax=intel", "--disassemble", "--symbolize-operands", "--demangle"), 
                    entry.Path, output.Path(filename));
            },true);
        }
    }
}
