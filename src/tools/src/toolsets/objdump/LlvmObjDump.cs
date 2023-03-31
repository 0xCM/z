//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    class ObjDumpFlow : ToolFlow<ObjDumpFlow>
    {
        public ObjDumpFlow()
            : base("llvm-objdump")
        {}

    }
    
    public abstract record class ObjDumpCmd<C>
        where C : ObjDumpCmd<C>,new()
    {
        public enum CommandKind : byte
        {
            None,

            EmitSymbols,

            Disassemble
        }

    }

    class LlvmObjDump : ToolWfCmd<LlvmObjDump,ObjDumpFlow>
    {       
        protected override FilePath ToolPath 
            => AppSettings.LlvmSettings().Tool("llvm-objdump");

        protected override bool Include(FilePath src)
            => src.Is(FileKind.Exe) || src.Is(FileKind.Obj) || src.Is(FileKind.Dll);

        public LlvmObjDump()
        {

        }

        [CmdOp("llvm/objdump/symbols")]
        void EmitSymbols(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var dst = EnvDb.Nested("llvm-objdump", src.Root).Clear();
            iter(Sources(args), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("symtables"));
                Run(Cmd.args(entry.Path.Format(PathSeparator.FS), "--syms", "--demangle"),entry.Path, dst.Path(filename));
            }, true);
        }

        [CmdOp("llvm/objdump/disasm")]
        void Disassemble(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var dst = EnvDb.Nested("llvm-objdump", src.Root).Clear();
            iter(Sources(args), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FileKind.Asm);
                Run(Cmd.args(entry.Path.Format(PathSeparator.FS), "--x86-asm-syntax=intel", "--disassemble", "--symbolize-operands", "--demangle"), entry.Path, dst.Path(filename));
            }, true);
        }
    }
}
