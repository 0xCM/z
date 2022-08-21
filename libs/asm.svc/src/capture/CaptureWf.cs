//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class CaptureWf : WfSvc<CaptureWf>
    {
        public class SettingsStore : Repository<FS.FilePath, CaptureWfSettings, FS.FilePath>
        {
            public override CaptureWfSettings Load(FS.FilePath key)
            {
                throw new NotImplementedException();
            }

            public override void Store(CaptureWfSettings src, FS.FilePath dst)
            {
                
            }
        }

        public void RunChecks(IApiPack src)
        {
            CaptureWfChecks.run(src, Emitter);            
        }

        static CaptureWfRunner runner(IWfRuntime wf, CaptureWfSettings settings, IApiPack dst, CaptureTransport transport)
            => new CaptureWfRunner(wf, settings, dst, transport);

        // void CollectSelected(CmdArgs args, CaptureTransport transport, IApiPack dst)
        // {
        //     var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
        //     var settings = new CaptureWfSettings();
        //     var parts = hashset<PartId>();
        //     iter(args, arg => {
        //         if(PartNames.parse(arg.Value, out var name))
        //             parts.Add(name);
        //         else
        //             Warn($"{arg.Value} is not a part");
        //     });

        //     settings.Parts = parts.ToSeq();

        //     var location = FS.path(ExecutingPart.Assembly.Location).FolderPath;
        //     var assemblies = ApiRuntime.assemblies(location).Where(a => parts.Contains(a.Id()));
        //     var catalog = ApiRuntime.catalog(assemblies);
        //     runner(Wf, settings, dst, transport).Run(catalog);
        // }

        public static ReadOnlySeq<ApiEncoded> run(IWfRuntime wf, CmdArgs args)
        {
            var collected = ReadOnlySeq<ApiEncoded>.Empty;
            var channel = wf.Emitter;
            var dst = ApiPacks.create(sys.timestamp());
            var catalog = default(IApiCatalog);
            using var transport = new CaptureTransport(Dispense.composite(), wf.Emitter);
            var settings = new CaptureWfSettings();
            if(args.Count != 0)
            {
                var src = FS.path(ExecutingPart.Assembly.Location).FolderPath;
                var parts = hashset<PartId>();
                iter(args, arg => {
                    if(PartNames.parse(arg.Value, out var name))
                        parts.Add(name);
                    else
                        channel.Warn($"{arg.Value} is not a part");
                });

                settings.Parts = parts.ToSeq();
                catalog = ApiRuntime.catalog(ApiRuntime.colocated(ExecutingPart.Assembly));
            }
            else
            {
                catalog = ApiRuntime.catalog(ApiRuntime.colocated(ExecutingPart.Assembly));
            }
            collected = runner(wf, settings, dst, transport).Run(catalog);
            return collected;
        }

        public void Run(CmdArgs args)
        {
            run(Wf,args);
            // var dst = ApiPacks.create(sys.timestamp());
            // using var transport = new CaptureTransport(Dispense.composite(), Emitter);
            // var settings = new CaptureWfSettings();
            // if(args.Count != 0)
            //     CollectSelected(args, transport,dst);
            // else
            // {
            //     var location = FS.path(ExecutingPart.Assembly.Location).FolderPath;
            //     var assemblies = ApiRuntime.assemblies(location);
            //     var catalog = ApiRuntime.catalog(assemblies);
            //     runner(Wf,settings, dst, transport).Run(catalog);
            // }
        }

        static SettingsStore Store = new();

        public static CaptureWfSettings settings()   
            => new();

        public static CaptureWfSettings settings(FS.FilePath src)   
            => Store.Load(src);

        public static void store(CaptureWfSettings src, FS.FilePath dst)
            => Store.Store(src,dst);
    }
}