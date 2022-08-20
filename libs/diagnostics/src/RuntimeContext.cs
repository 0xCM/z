//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class RuntimeContext
    {
        public static ExecToken emit(ProcessAdapter src, WfEmit channel, IDbArchive dst)
        {
            var map = ImageMemory.map(src);
            channel.FileEmit(map.ToString(), dst.Path("process.image", FileKind.Map));            
            modules(src, channel, dst);
            return dump(src,channel,dst);
        }

        static ExecToken modules(ProcessAdapter src, WfEmit channel, IDbArchive dst)
            => channel.TableEmit(ImageMemory.modules(src), dst.Table<ProcessModuleRow>());

        public static ExecToken dump(ProcessAdapter src, WfEmit channel, IDbTargets dst)
        {
            var name = $"{src.ProcessName}.{src.Id}.{core.timestamp()}";
            var path = dst.Path(name, FileKind.Dmp);
            var running = channel.EmittingFile(path);
            DumpEmitter.emit(src, path);
            return channel.EmittedBytes(running, path.Size);
        }

        public static void env(WfEmit channel, IApiPack dst)
        {
            Env.emit(channel,EnvVarKind.Process, dst.Context().Root);
            Env.emit(channel,EnvVarKind.User, dst.Context().Root);
            Env.emit(channel,EnvVarKind.Machine, dst.Context().Root);
        }

        public static ExecToken emit(WfEmit channel, IApiPack dst)
        {
            env(channel,dst);
            var map = ImageMemory.map();
            channel.FileEmit(map.ToString(), dst.Context().Path("process.image", FileKind.Map));            
            return emit(Process.GetCurrentProcess(), dst, channel);
        }

        static ExecToken emit(ProcessAdapter src, IApiPack dst, WfEmit channel)
        {
            var running = channel.Running($"Emiting context for process {src.Id} based at {src.BaseAddress} from {src.Uri}");
            modules(src, dst, channel);
            dump(src, dst,channel);
            return channel.Ran(running);           
        }

        static ExecToken modules(Process src, IApiPack dst, WfEmit channel)
            => channel.TableEmit(ImageMemory.modules(src), dst.ProcessModules());

        static ExecToken dump(Process src, IApiPack dst, WfEmit channel)
        {
            var path = dst.DumpPath(src);
            var running = channel.EmittingFile(path);
            DumpEmitter.emit(src, path);
            return channel.EmittedBytes(running, path.Size);
        }
    }
}