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
        {}

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
            var command = Tooling.command(ToolPath, 
                Tooling.flag("--syms"), 
                Tooling.flag("--demangle")
                );
            iter(Sources(args), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FS.ext("symtables"));
                Run(command, dst.Path(filename));
            }, true);
        }

        [CmdOp("llvm/objdump/disasm")]
        void Disassemble(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var dst = EnvDb.Nested("llvm-objdump", src.Root).Clear();
            var command = Tooling.command(ToolPath, 
                Tooling.flag("--disassemble"), 
                Tooling.flag("--symbolize-operands"),
                Tooling.flag("--demangle"),
                Tooling.option(ArgPrefixKind.Dashes, "x86-asm-syntax", ArgSepKind.Eq, "intel")
                );

            iter(Sources(args), entry => {
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FileKind.Asm);
                Run(command, dst.Path(filename));
            }, true);
        }
    }
}
