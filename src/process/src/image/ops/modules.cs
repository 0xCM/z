//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using static sys;

    partial class ImageMemory
    {
        public static void modules(CmdArgs args, IWfChannel channel, DbArchive dst)
        {
            var buffer = bag<ProcessId>();
            if(args.Count != 0)
                ProcessId.parse(args, buffer);
            else
                buffer.Add(ExecutingPart.Process.Id);

            iter(buffer, id => modules(ProcessAdapter.adapt(id), channel, dst));
        }

        public static void modules(ProcessAdapter src, IWfChannel channel, DbArchive dst)
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