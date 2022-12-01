//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static sys;

    partial class ImageMemory
    {
        public static Task<ExecToken> modules(IWfChannel channel, CmdArgs args, IDbArchive dst)
        {
            ExecToken run()
            {
                var flow = channel.Running();
                var buffer = bag<ProcessId>();
                if(args.Count != 0)
                    iter(args, arg =>  ProcessId.parse(args, buffer));                    
                else
                    buffer.Add(ExecutingPart.Process.Id);

                iter(buffer, id => modules(id, channel, dst), true);
                return channel.Ran(flow);
            }

            return sys.start(run);
        }

        public static void modules(ProcessAdapter src, IWfChannel channel, IDbArchive dst)
            => channel.TableEmit(modules(src), uri(src, dst));

        [Op]
        public static ReadOnlySeq<ProcessModuleRow> modules(ProcessAdapter src)
        {
            var modules = src.Modules;
            var count = modules.Count;
            var buffer = Seq.create<ProcessModuleRow>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var module = ref modules[i];
                ref var dst = ref buffer[i];
                dst.Seq = i;
                dst.ImageName = module.ModuleName;
                dst.BaseAddress = module.BaseAddress;
                dst.EntryAddress = module.EntryPointAddress;
                dst.MaxAddress = dst.BaseAddress + module.ModuleMemorySize;
                dst.MemorySize = module.ModuleMemorySize;
                dst.Version = ((uint)module.FileVersionInfo.FileMajorPart, (uint)module.FileVersionInfo.FileMinorPart);
                dst.ImagePath = module.Path;
            }
            return buffer.Sort().Resequence();
        }
    }
}