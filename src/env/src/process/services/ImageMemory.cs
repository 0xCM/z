//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;
    using static ImageRegions;

    [ApiHost,Free]
    public class ImageMemory
    {
        [Op, MethodImpl(Inline)]
        public static Traverser traverser(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
            => new Traverser(src, live);

        [Op, MethodImpl(Inline)]
        public static unsafe ByteSize run(Traverser traverser, delegate* unmanaged<in ProcessMemoryRegion,void> dst)
            => traverser.Traverse(dst);

        [Op]
        public static unsafe Index<ProcessMemoryRegion> filter(ReadOnlySpan<ProcessMemoryRegion> src, PageProtection protect)
        {
            var dst  = alloc<ProcessMemoryRegion>((uint)src.Length);
            var filter = new MemoryRegionFilter(dst, protect);
            var size = traverser(src,false).Traverse(filter);
            return filter.Emit();
        }

        [Op]
        public static ReadOnlySeq<ProcessPartition> partitions(ReadOnlySeq<ImageLocation> src)
        {
            var count = src.Count;
            var buffer = Seq.create<ProcessPartition>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var image = ref src[i];
                ref var dst = ref buffer[i];
                dst.MinAddress = image.BaseAddress;
                dst.MaxAddress = image.MaxAddress;
                dst.Size = image.Size;
                dst.ImageName = image.ImageName;
            }

            return buffer.Sort();
        }

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

        [Op]
        public static ImageLocation location(ProcessModule src)
            =>  new ImageLocation(
                src.Path.FileName.WithoutExtension.Format(),
                (MemoryAddress)src.EntryPointAddress,
                src.BaseAddress,
                src.ModuleMemorySize,
                src.Path
                );

        [Op]
        public static ReadOnlySeq<ImageLocation> loaded(ProcessAdapter src)
        {
            var dst = bag<ImageLocation>();
            iter(src.Modules, m => dst.Add(location(m)), AppData.get().PllExec());
            return dst.Array().Sort();
        }

        [Op]
        public static MemoryAddress @base(Assembly src)
            => @base(Path.GetFileNameWithoutExtension(src.Location));

        [MethodImpl(Inline), Op]
        public static MemoryAddress @base(string procname)
        {
            var module = ImageMemory.modules(Process.GetCurrentProcess()).Where(m => Path.GetFileNameWithoutExtension(m.ImagePath.ToFilePath().Name) == procname).First;
            return module.BaseAddress;
        }

        public static FileUri uri(ProcessAdapter src, IDbArchive dst)
            => new FileUri($"{dst.Root.Format(PathSeparator.FS)}/{src.ProcessName}.{src.Id}.{sys.timestamp()}.modules.{FileKind.Csv.Format()}");

        public static PEReader pe(Stream src)
            => new PEReader(src);

        static ExecToken dump(IWfChannel channel, ProcessAdapter src, FilePath dst)
        {
            var running = channel.EmittingFile(dst);
            DumpEmitter.dump(src, dst);
            return channel.EmittedBytes(running, dst.Size);
        }

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
            var src = loaded(process);
            //var count = src.Count;
            // var addresses = alloc<MemoryAddress>(count);
            // for(var i=0u; i<count; i++)
            //     seek(addresses, i) = src[i].BaseAddress;
            var state = new ProcessMemoryState();
            fill(process, ref state);
            return new ProcessImageMap(state, src, modules(process));
        }

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
                dst.Size = module.ModuleMemorySize;
                dst.Version = ((uint)module.FileVersionInfo.FileMajorPart, (uint)module.FileVersionInfo.FileMinorPart);
                dst.ImagePath = module.Path;
            }
            return buffer.Sort().Resequence();
        }

        [Op]
        public static ReadOnlySeq<ProcessMemoryRegion> regions(Process src)
            => regions(MemoryNode.snapshot(src.Id).Describe());

        [Op]
        public static ReadOnlySeq<ProcessMemoryRegion> regions()
            => regions(MemoryNode.snapshot().Describe());

        [Op]
        public static ReadOnlySeq<ProcessMemoryRegion> regions(int procid)
            => regions(MemoryNode.snapshot(procid).Describe());

        public static ReadOnlySeq<ProcessMemoryRegion> regions(ReadOnlySpan<MemoryRangeInfo> src)
        {
            var count = src.Length;
            var buffer = alloc<ProcessMemoryRegion>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                fill(skip(src,i), i, out seek(dst,i));
            return buffer.Resequence();
        }

        /// <summary>
        /// Captures state information about a specified process
        /// </summary>
        /// <param name="src">The source process</param>
        [MethodImpl(Inline), Op]
        public static ProcessMemoryState state(Process src)
        {
            var dst = new ProcessMemoryState();
            fill(src, ref dst);
            return dst;
        }

        [Op]
        static ref ProcessMemoryState fill(Process src, ref ProcessMemoryState dst)
        {
            dst.ImageName = src.ProcessName;
            dst.ProcessId = (uint)src.Id;
            dst.BaseAddress = src.MainModule.BaseAddress;
            dst.MinWorkingSet =(ulong)src.MinWorkingSet;
            dst.MaxWorkingSet = (ulong)src.MaxWorkingSet;
            dst.Affinity = (ulong)src.ProcessorAffinity;
            dst.StartTime = src.StartTime;
            dst.TotalRuntime = src.TotalProcessorTime;
            dst.UserRuntime = src.UserProcessorTime;
            dst.ImagePath = FS.path(src.MainModule.FileName);
            dst.MemorySize = src.MainModule.ModuleMemorySize;
            dst.ImageVersion = ((uint)src.MainModule.FileVersionInfo.FileMajorPart, (uint)src.MainModule.FileVersionInfo.FileMinorPart);
            dst.EntryAddress = src.MainModule.EntryPointAddress;
            dst.VirtualSize = src.VirtualMemorySize64;
            dst.MaxVirtualSize = src.PeakVirtualMemorySize64;
            return ref dst;
        }

        static _FileUri Nul => FolderPath.Empty +  FS.file("dev",FS.ext("null"));

        static ProcessMemoryRegion fill(in MemoryRangeInfo src, uint index, out ProcessMemoryRegion dst)
        {
            var owner = src.Owner;
            dst.Seq = index;
            if(text.nonempty(owner))
            {
                dst.ImagePath = FS.path(owner);
                if(owner.Contains("."))
                    dst.ImageName = Path.GetFileName(owner);
                else
                    dst.ImageName = owner.Substring(0, min(owner.Length, 12));
            }
            else
            {
                dst.ImageName = "unknown";
                dst.ImagePath = Nul;
            }

            dst.BaseAddress = src.StartAddress;
            dst.MaxAddress = src.EndAddress;
            dst.Size = src.Size;
            dst.Protection = src.Protection;
            dst.Type = src.Type;
            dst.State = src.State;
            return dst;
        }
    }
}