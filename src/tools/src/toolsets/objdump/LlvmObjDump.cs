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

    class LlvmObjDump : WfAppCmd<LlvmObjDump>
    {       
        readonly FilePath Tool;

        public LlvmObjDump()
        {
            Tool = AppSettings.LlvmSettings().Tool("llvm-objdump");
        }

        [CmdOp("llvm-objdump/disasm")]
        void Run(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var index = FS.index(Archives.modules(src.Root).Unmanaged());
            var entries = index.Distinct().ToQueue();
            var output = EnvDb.Nested(Tool.FileName.WithoutExtension.Format(), src.Root).Clear();
            while(entries.TryDequeue(out var entry))
            {                
                var cmdargs = Cmd.args(entry.Path.Format(PathSeparator.FS), "--x86-asm-syntax=intel", "--disassemble", "--symbolize-operands", "--demangle");
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FileKind.Asm);
                var dst = output.Path(filename);
                var process = ObjDumpProcess.init(Channel, entry.Path, dst);
                process.Start(cmdargs);
            }
        }
    }
}

