//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public sealed class CaptureWfRunner
    {
        readonly IWfRuntime Wf;

        readonly IApiPack Target;

        public readonly CaptureWfSettings Settings;

        readonly IWfChannel Channel;

        readonly CaptureTransport Transport;

        public CaptureWfRunner(IWfRuntime wf, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
        {
            Wf = wf;
            Target = dst;
            Settings = settings;
            Channel = wf.Channel;
            Transport = transport;
            Wf.RedirectEmissions(Loggers.emission(Target.Path("capture.emissions", FileKind.Csv)));
        }

        public ReadOnlySeq<ApiEncoded> Run(IApiCatalog src)
        {
            var collected = Capture(src);
            var blocks = collected.SelectMany(x => x.Blocks).Sort();
            EmitMemberIndex(blocks, Target);

            if(Settings.EmitCatalog)
            {
                var members = Transport.Resolved(ApiQuery.members(collected.SelectMany(x => x.Resolved.Members)));
                var rebased = Transport.Rebased(ApiCatalog.entries(members));
                var path = Target.Table<ApiCatalogEntry>();
                Channel.TableEmit(rebased, path, UTF8);
                Transport.Reloaded(ApiCatalog.entries(Channel, path));
            }

            if(Settings.EmitRegions)
                Regions.EmitRegions(Process.GetCurrentProcess(), Target);

            if(Settings.EmitContext)
                Env.context(Channel, Target.Timestamp, Target);

            if(Settings.RunChecks)
            {
                
            }

            ApiPacks.Link(Target);
            return blocks;
        }

        ICompositeDispenser Dispenser
            => Transport.Dispenser;

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCodeSvc => Wf.ApiCode();

        ApiPacks ApiPacks => Channel.Channeled<ApiPacks>();

        ProcessMemory Regions => Channel.Channeled<ProcessMemory>();

        Ecma Cli => Wf.Ecma();

        ExecToken EmitMemberIndex(ReadOnlySeq<ApiEncoded> src, IApiPack dst)
        {
            var count = src.Count;
            var buffer = sys.alloc<EncodedMember>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = ApiCode.member(src[i]);
            var rebase = min(buffer.Select(x => (ulong)x.EntryAddress).Min(), buffer.Select(x => (ulong)x.TargetAddress).Min());
            for(var i=0; i<count; i++)
            {
                seek(buffer,i).EntryRebase = skip(buffer,i).EntryAddress - rebase;
                seek(buffer,i).TargetRebase = skip(buffer,i).TargetAddress - rebase;
            }

            return Channel.TableEmit(Transport.Transmit(buffer).View, dst.Table<EncodedMember>());
        }

        Seq<CollectedHost> Capture(IApiCatalog src)
        {            
            var dst = sys.bag<CollectedHost>();
            var parts = src.PartCatalogs.Select(x => x as IApiPartCatalog);
            var running = Channel.Running($"Running capture workflow: {parts.Select(x => x.Component.PartName()).Delimit()}");
            iter(parts, p => Capture(p, Dispenser, dst, Channel), Settings.PllExec);            
            var collected = Transport.Transmit(dst.ToSeq());        
            Channel.Ran(running, $"Captured {collected.Count} hosts");
            return collected;
        }

        void Capture(IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, IWfChannel channel)
        {
            var tmp = sys.bag<CollectedHost>();
            ApiCode.gather(channel, src, dispenser, tmp, Settings.PllExec);
            var code = tmp.ToArray();
            ApiCodeSvc.Emit(code, Target, Settings.PllExec);
            EmitAsm(dispenser, code);
            iter(tmp, x =>  {                
                Cli.EmitMsil(x,Target.Scoped("extracts"));
                dst.Add(x);
                }
            );
            Transport.Transmit(src.Component);
        }

        void EmitAsm(ICompositeDispenser symbols, ReadOnlySeq<CollectedHost> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var host = ref src[i];
                var path = Target.AsmExtractPath(host.Host);
                var flow = Channel.EmittingFile(path);
                var size = ByteSize.Zero;
                using var writer = path.AsciWriter();
                for(var j=0; j<host.Blocks.Count; j++)
                {
                    ref readonly var blocks = ref host.Blocks[j];
                    var routine = AsmDecoder.Decode(blocks);
                    var asm = routine.AsmRender(routine);
                    size += (ulong)asm.Length;
                    writer.AppendLine(asm);
                }
                Channel.EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,path));
            }
        }
   }
}