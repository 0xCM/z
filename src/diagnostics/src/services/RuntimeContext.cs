//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RuntimeContext
    {
        public static void dump(IWfChannel channel, CmdArgs args, IDbArchive dst)
        {
            var ids = sys.list<ProcessId>();
            if(args.Count != 0)
            {
                sys.iter(args, arg => {
                    if(DataParser.parse(arg.Value, out int id))
                        ids.Add(id);
                });
            }
            else
            {
                ids.Add(ExecutingPart.Process.Id);
            }

            sys.iter(ids, id => dump(channel, ProcessAdapter.adapt(id), dst));
        }

        public static ExecToken dump(IWfChannel channel, ProcessAdapter src, IDbArchive dst)
        {
            var map = ImageMemory.map(src);
            var targets = dst.Scoped($"{src.ProcessName}.{src.Id}");
            channel.FileEmit(map.ToString(), targets.Path("process.image", FileKind.Map));            
            channel.TableEmit(ImageMemory.modules(src), dst.Table<ProcessModuleRow>());
            return dump(channel, src, targets.Path("process",FileKind.Dmp));
        }

        static ExecToken dump(IWfChannel channel, ProcessAdapter src, FilePath dst)
        {
            var running = channel.EmittingFile(dst);
            DumpEmitter.dump(src, dst);
            return channel.EmittedBytes(running, dst.Size);
        }

        public static void env(IWfChannel channel, IDbArchive dst)
        {
            Env.emit(channel,EnvVarKind.Process, dst.Scoped("context"));
            Env.emit(channel,EnvVarKind.User, dst.Scoped("context"));
            Env.emit(channel,EnvVarKind.Machine, dst.Scoped("context"));
        }

        public static ExecToken emit(IWfChannel channel, Timestamp ts, IDbArchive dst)
        {
            env(channel,dst);
            var map = ImageMemory.map();
            channel.FileEmit(map.ToString(), dst.Scoped("context").Path("process.image", FileKind.Map));            
            return emit(channel, Process.GetCurrentProcess(), ts, dst);
        }

        static ExecToken emit(IWfChannel channel, ProcessAdapter src, Timestamp ts, IDbArchive dst)
        {
            var running = channel.Running($"Emiting context for process {src.Id} based at {src.BaseAddress} from {src.Uri}");
            modules(channel, src, dst);
            var file = ProcDumpName.path(src, ts, dst);
            var dumping = channel.EmittingFile(file);
            DumpEmitter.dump(src, file);
            channel.EmittedBytes(dumping, file.Size);
            return channel.Ran(running, $"Emitted context for process {src.Id}");   
        }
        
        static ExecToken modules(IWfChannel channel, Process src, IDbArchive dst)
            => channel.TableEmit(ImageMemory.modules(src), dst.Scoped("context").Path("process.modules",FileKind.Csv));
    }
}