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

        ICompositeDispenser Dispenser
            => Transport.Dispenser;

        ApiMd ApiMd => Wf.ApiMd();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCodeSvc ApiCodeSvc => Wf.ApiCode();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiPacks ApiPacks => Wf.ApiPacks();

        ImageRegions Regions => Wf.ImageRegions();

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

        Seq<CollectedHost> Capture(IApiCatalog catalog, ReadOnlySeq<Assembly> src)
        {
            var dst = sys.bag<CollectedHost>();
            var ids = Settings.Parts.IsEmpty ? src.Select(x => x.Id()).Where(x => x != 0).ToSeq() : Settings.Parts;
            var running = Emitter.Running($"Running capture workflow: {ids.Delimit()}");
            Capture(catalog, ids.View, dst);
            var collected = Transport.Transmit(dst.ToSeq());
            Emitter.Ran(running, $"Captured {collected.Count} hosts");
            return collected;
        }

        Seq<CollectedHost> Capture(IApiCatalog src)
        {
            var dst = sys.bag<CollectedHost>();
            var parts = src.PartCatalogs;
            var ids = parts.Select(x => x.PartId);
            var running = Emitter.Running($"Running capture workflow: {ids.Delimit()}");
            Capture(src, ids.View, dst);
            var collected = Transport.Transmit(dst.ToSeq());
            Emitter.Ran(running, $"Captured {collected.Count} hosts");
            return collected;
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
                ApiMd.Emitter().Emit(Target);
                CliEmitter.Emit(Settings.CliEmissions, Target);
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

        ExecToken Capture(IApiCatalog catalog, ReadOnlySpan<PartId> src, ConcurrentBag<CollectedHost> dst)
        {
            const string On = "concurrent execution enabled";
            const string Off = "concurrent execution disabled";
            var pll = Settings.PllExec;
            var pllmsg = pll ? On : Off;
            var running = Emitter.Running($"Capturing {src.Length} parts with concurrent execution {pllmsg}:{src.Delimit().Format()}");
            iter(src, id => Capture(catalog, id, dst), pll);
            return Emitter.Ran(running);
        }

        void Capture(IApiCatalog src, PartId id, ConcurrentBag<CollectedHost> dst)
        {        
            var result = find(src, id, out var pc);
            if(result)
                Capture(pc, Dispenser, dst, Emitter);
            else
                Emitter.Warn($"Part identifier {id} not found");
        }


        void Capture(IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, WfEmit log)
        {
            var tmp = sys.bag<CollectedHost>();
            ApiCode.gather(src, dispenser, tmp, log, Settings.PllExec);
            var code = tmp.ToArray();
            ApiCodeSvc.Emit(src.PartId, code, Target, Settings.PllExec);
            EmitAsm(dispenser, code);

            iter(tmp, x =>  {
                
                Cli.EmitMsil(x,Target);
                dst.Add(x);

                }
            );
            Transport.Transmit(src.Component);
        }

        static bool find(IApiCatalog src, PartId id, out IApiPartCatalog dst)
        {
            var matched = src.PartCatalogs.Where(x => x.PartId == id).ToSeq();
            if(matched.IsNonEmpty)
                dst = matched.First;
            else
                dst = null;

            return dst != null;
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