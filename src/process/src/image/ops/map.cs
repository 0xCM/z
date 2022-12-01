//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ImageMemory
    {
        public static ProcessImageMap map()
            => map(Process.GetCurrentProcess());

        public static void map(IWfChannel channel, CmdArgs args, IDbArchive dst)
        {
            var buffer = bag<ProcessId>();
            if(args.Count != 0)
                ProcessId.parse(args, buffer);
            else
                buffer.Add(ExecutingPart.Process.Id);

            iter(buffer, id =>  map(ProcessAdapter.adapt(id), channel, dst));
        }

        public static void map(ProcessAdapter src, IWfChannel channel, IDbArchive dst)
            => channel.FileEmit(map(src).Format(), new FileUri($"{dst.Root.Format(PathSeparator.FS)}{src.ProcessName}.{src.Id}.{sys.timestamp()}.image.map"));

        public static ProcessImageMap map(ProcessAdapter process)
        {
            var src = locations(process);
            var count = src.Count;
            var addresses = alloc<MemoryAddress>(count);
            for(var i=0u; i<count; i++)
                seek(addresses, i) = src[i].BaseAddress;
            var state = new ProcessMemoryState();
            fill(process, ref state);
            return new ProcessImageMap(state, src, addresses.Sort(), modules(process));
        }
    }
}