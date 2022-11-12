//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class RuntimeContext
    {
        public static void emit(CmdArgs args, IWfChannel channel, IDbArchive dst)
        {
            var ids = sys.list<ProcessId>();
            if(args.Count != 0)
            {
                iter(args, arg => {
                    if(DataParser.parse(arg.Value, out int id))
                        ids.Add(id);
                });
            }
            else
            {
                ids.Add(ExecutingPart.Process.Id);
            }

            iter(ids, id => {
                var process = ProcessAdapter.adapt(id);
                emit(process, channel, dst);
            });
        }

        public static ExecToken emit(ProcessAdapter src, IWfChannel channel, IDbArchive dst)
        {
            var id = src.Id;
            var name = src.ProcessName;
            var map = ImageMemory.map(src);
            var targets = dst.Scoped($"{name}.{id}.{sys.timestamp()}");
            channel.FileEmit(map.ToString(), targets.Path("process.image", FileKind.Map));            
            modules(src, channel, targets);
            return dump(src,channel, targets.Path("process",FileKind.Dmp));
        }

        static ExecToken modules(ProcessAdapter src, IWfChannel channel, IDbArchive dst)
            => channel.TableEmit(ImageMemory.modules(src), dst.Table<ProcessModuleRow>());

        public static ExecToken dump(ProcessAdapter src, IWfChannel channel, IDbArchive dst)
        {
            var name = $"{src.ProcessName}.{src.Id}.{core.timestamp()}";
            var path = dst.Path(name, FileKind.Dmp);
            var running = channel.EmittingFile(path);
            DumpEmitter.emit(src, path);
            return channel.EmittedBytes(running, path.Size);
        }

        public static ExecToken dump(ProcessAdapter src, IWfChannel channel, FilePath dst)
        {
            var running = channel.EmittingFile(dst);
            DumpEmitter.emit(src, dst);
            return channel.EmittedBytes(running, dst.Size);
        }

        public static void env(IWfChannel channel, IApiPack dst)
        {
            Env.emit(channel,EnvVarKind.Process, dst.Context().Root);
            Env.emit(channel,EnvVarKind.User, dst.Context().Root);
            Env.emit(channel,EnvVarKind.Machine, dst.Context().Root);
        }

        public static ExecToken emit(IWfChannel channel, IApiPack dst)
        {
            env(channel,dst);
            var map = ImageMemory.map();
            channel.FileEmit(map.ToString(), dst.Context().Path("process.image", FileKind.Map));            
            return emit(Process.GetCurrentProcess(), dst, channel);
        }

        static ExecToken emit(ProcessAdapter src, IApiPack dst, IWfChannel channel)
        {
            var running = channel.Running($"Emiting context for process {src.Id} based at {src.BaseAddress} from {src.Uri}");
            modules(src, dst, channel);
            dump(src, dst,channel);
            return channel.Ran(running);           
        }

        static ExecToken modules(Process src, IApiPack dst, IWfChannel channel)
            => channel.TableEmit(ImageMemory.modules(src), dst.ProcessModules());

        static ExecToken dump(Process src, IApiPack dst, IWfChannel channel)
        {
            var path = dst.DumpPath(src);
            var running = channel.EmittingFile(path);
            DumpEmitter.emit(src, path);
            return channel.EmittedBytes(running, path.Size);
        }
    }
}