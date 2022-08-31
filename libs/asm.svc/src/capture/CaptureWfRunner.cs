//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public sealed class CaptureWfRunner
    {
        readonly IWfRuntime Wf;

        readonly IApiPack Target;

        public readonly CaptureWfSettings Settings;

        readonly WfEmit Emitter;

        readonly CaptureTransport Transport;

        public CaptureWfRunner(IWfRuntime wf, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
        {
            Wf = wf;
            Target = dst;
            Settings = settings;
            Emitter = wf.Emitter;
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
                var members = Transport.TransmitResolved(ApiQuery.members(collected.SelectMany(x => x.Resolved.Members)));
                var rebased = Transport.TransmitRebased(ApiCode.catalog(members));
                var path = Target.Table<ApiCatalogEntry>();
                Emitter.TableEmit(rebased, path, UTF8);
                Transport.TransmitReloaded(ApiCode.catalog(path, Emitter));
            }

            if(Settings.EmitMetadata)
            {
                ApiMd.Emitter().Emit(src, Target);
                CliEmitter.Emit(src, Settings.CliEmissions, Target);
            }

            if(Settings.EmitRegions)
                Regions.EmitRegions(Process.GetCurrentProcess(), Target);

            if(Settings.EmitContext)
                RuntimeContext.emit(Emitter,Target);

            if(Settings.RunChecks)
            {
                
            }

            ApiPacks.Link(Target);
            return blocks;
        }


        ICompositeDispenser Dispenser
            => Transport.Dispenser;

        ApiMd ApiMd => Wf.ApiMd();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCodeSvc => Wf.ApiCode();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiPacks ApiPacks => Wf.ApiPacks();

        ProcessMemory Regions => Wf.ProcessMemory();

        Cli Cli => Wf.Cli();

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

            return Emitter.TableEmit(Transport.Transmit(buffer).View, dst.Table<EncodedMember>());
        }

        Seq<CollectedHost> Capture(IApiCatalog src)
        {            
            var dst = sys.bag<CollectedHost>();
            var parts = src.PartCatalogs.Select(x => x as IApiPartCatalog);
            var running = Emitter.Running($"Running capture workflow: {parts.Select(x => x.Component.PartName()).Delimit()}");
            iter(parts, p => Capture(p, Dispenser, dst, Emitter), Settings.PllExec);            
            var collected = Transport.Transmit(dst.ToSeq());        
            Emitter.Ran(running, $"Captured {collected.Count} hosts");
            return collected;
        }

        void Capture(IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, WfEmit log)
        {
            var tmp = sys.bag<CollectedHost>();
            ApiCode.gather(src, dispenser, tmp, log, Settings.PllExec);
            var code = tmp.ToArray();
            ApiCodeSvc.Emit(src.PartName, code, Target, Settings.PllExec);
            EmitAsm(dispenser, code);

            iter(tmp, x =>  {                
                Cli.EmitMsil(x,Target);
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
                var flow = Emitter.EmittingFile(path);
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
                Emitter.EmittedFile(flow, AppMsg.EmittedBytes.Capture(size,path));
            }
        }
   }
}