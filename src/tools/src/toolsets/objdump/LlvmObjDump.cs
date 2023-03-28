//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    sealed class ObjDumpProcess : WfProcess<ObjDumpProcess>
    {


    }

    class LlvmObjDump : WfAppCmd<LlvmObjDump>
    {       
        readonly FilePath Tool;

        public LlvmObjDump()
        {
            Tool = AppSettings.LlvmSettings().Tool("llvm-objdump");
        }

        [CmdOp("llvm/objdump")]
        void Run(CmdArgs args)
        {
            var src = FS.archive(args[0]);
            var index = FS.index(Archives.modules(src.Root).Unmanaged());
            var entries = index.Distinct().ToQueue();
            var tokens = cdict<ExecToken,ExecToken>();
            var finished = cdict<ExecToken,ExecToken>();
            var output = EnvDb.Nested(Tool.FileName.WithoutExtension.Format(), src.Root).Clear();
            void Running(ExecToken token)
            {
                if(!tokens.TryAdd(token,token))
                {
                    Channel.Warn($"{token} already exists in index");
                }
            }

            void Ran(ExecToken token)
            {
                finished.TryAdd(token,token);
            }

            while(entries.TryDequeue(out var entry))
            {                
                var cmdargs = Cmd.args(Tool, entry.Path.Format(PathSeparator.FS), "--x86-asm-syntax=intel", "--disassemble", "--symbolize-operands", "--demangle");
                var filename = FS.file(entry.Path.FileName.Format() + "." + entry.Path.Hash.Format(false), FileKind.Asm);
                var dst = output.Path(filename);
                var process = ObjDumpProcess.init(Channel, cmdargs, dst);
                process.Start();
            }

            void Spin()
            {
                
                var remaining = entries.Count - finished.Count;
                if(remaining == 0)
                {
                    Channel.Status("All processes finished");
                    return;                    
                }
                else
                {
                    Channel.Babble($"{remaining} processes outstanding");
                    sys.delay(1000);
                }                
            }

            sys.start(Spin).Wait();
        }
    }
}