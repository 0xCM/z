//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.Diagnostics.Runtime;
    using Microsoft.Diagnostics.Runtime.DacInterface;

    public sealed class ClrMdSvc : IDisposable
    {
        public static ClrMdSvc create(IWfRuntime wf, ProcessId? process  = null)
            => new ClrMdSvc(wf, process ?? Process.GetCurrentProcess().Id);

        [MethodImpl(Inline)]
        public static bool hot(ClrMethod src)
        {
            var hc = src.HotColdInfo;
            return hc.HotSize > 0 && hc.HotStart > 0;
        }

        /// <summary>
        /// Adapted from dotnet/BenchmarkDotNet/src/BenchmarkDotNet.Disassembler.x64/ClrMdDisassembler.cs
        /// </summary>
        /// <param name="method"></param>
        public static ReadOnlySeq<IlEncodingMap> map(ClrMethod method)
        {
            // it's better to use one single map rather than few small ones
            // it's simply easier to get next instruction when decoding ;)
            var dst = sys.empty<IlEncodingMap>();
            if (hot(method))
            {
                var hotColdInfo = method.HotColdInfo;
                dst = hotColdInfo.ColdSize <= 0
                    ? new[] {new IlEncodingMap(0xFFFF, hotColdInfo.HotStart, hotColdInfo.HotStart + hotColdInfo.HotSize)}
                    : new[]
                      {
                            new IlEncodingMap(0xFFFF, hotColdInfo.HotStart, hotColdInfo.HotStart + hotColdInfo.HotSize),
                            new IlEncodingMap(0xFFFF, hotColdInfo.ColdStart, hotColdInfo.ColdStart + hotColdInfo.ColdSize)
                      };
            }

            dst = method.ILOffsetMap
                    .Where(map => map.StartAddress < map.EndAddress) // some maps have 0 length?
                    .OrderBy(map => map.StartAddress) // we need to print in the machine code order, not IL! #536
                    .Select(x => new IlEncodingMap(x.ILOffset, x.StartAddress, x.EndAddress))
                    .Array();

            return dst;
        }

        DataTarget Target;

        ClrRuntime Runtime;

        ProcessId ProcId;

        Process Proc;

        bool Attached => Target != null && Runtime != null;

        IWfChannel Channel;

        IWfRuntime Wf;
        
        public ClrMdSvc(IWfRuntime wf, ProcessId procid)
        {
            Wf = wf;
            Channel = wf.Channel;
            ProcId = procid;
            Proc = Process.GetProcessById((int)ProcId);
            //ChildProcessTracker.AddProcess(Proc);
            Attach();            
        }


        public void Attach()
        {
            if(Attached)
                return;

            Channel.Babble(string.Format("Attaching to {0}", ProcId));
            Target = DataTarget.CreateSnapshotAndAttach((int)ProcId);
            Runtime = Target.ClrVersions.Single().CreateRuntime();
            Channel.Babble("Attached");
        }

        public void Detach()
        {
            if(Attached)
            {
                Channel.Babble(string.Format("Detaching from {0}", ProcId));
                Runtime.Dispose();
                Runtime = null;
                Target.Dispose();
                Target = null;
                Channel.Babble("Detached");
            }
        }

        public void Collect()
        {
            foreach (var thread in Runtime.Threads)
            {
                Channel.Row($"{thread.OSThreadId:x}:");
                foreach (var frame in thread.EnumerateStackTrace())
                    Channel.Row($"    {frame}");
            }
        }

        public void ParseDump(FilePath src)
            => Channel.Channeled<DumpParser>().ParseDump(src);

        public ClrMethod? Method(ClrHandle handle)
            => Runtime.GetMethodByHandle(handle.Address);

        public IEnumerable<ClrHandle> Handles()
            => Runtime.EnumerateHandles();

        public IEnumerable<ModuleInfo> Modules()
            => ClrInfo().DataTarget.EnumerateModules();

        public IEnumerable<ClrModule> ClrModules()
            => Runtime.EnumerateModules();

        public ClrType ClrType(MemoryAddress methods)
            => Runtime.GetTypeByMethodTable(methods);
            
        public ClrInfo ClrInfo()
            => Runtime.ClrInfo;

        public void Dispose()
        {
            Detach();
        }
    }
}